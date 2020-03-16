using EMR.Web.Extension.Common;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Filter
{
    public class PowerAttribute : ActionFilterAttribute
    {
        #region 请求过滤器
        /// <summary>
        /// 请求过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            #region model验证处理
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                var item = filterContext.Controller.ViewData.ModelState.Values.ToList().Find(a => a.Errors.Count > 0);
                var error = item.Errors.Where(a => !string.IsNullOrEmpty(a.ErrorMessage)).Take(1).SingleOrDefault().ErrorMessage;
                filterContext.Result = new JsonResult
                {
                    Data = new { code = 1, msg = error },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return;
            }
            #endregion

            #region 权限验证
            foreach (var item in filterContext.ActionDescriptor.GetCustomAttributes(true).ToList())
            {
                if (item is AllowAnonymousAttribute)
                    return;
            }

            var token = filterContext.HttpContext.Request["token"];
            if (!string.IsNullOrEmpty(token) && UserTokenManager.IsExistToken(token))
                return;
            else
            {
                filterContext.Result = new JsonResult
                {
                    Data = new { code = 13, msg = "登录凭证失效，获取数据失败！" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                return;
            }
            #endregion
        }
        #endregion

        #region 结果过滤器
        /// <summary>
        /// 结果过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //压缩
            if (filterContext.HttpContext.Response.StatusCode == 200)
            {
                var acceptEncoding = filterContext.HttpContext.Request.Headers["Accept-Encoding"].ToLower();
                if (!string.IsNullOrEmpty(acceptEncoding))
                {
                    if (filterContext.HttpContext.Response.Headers.AllKeys.Contains("Content-encoding"))
                        filterContext.HttpContext.Response.Headers.Remove("Content-encoding");

                    if (acceptEncoding.Contains("gzip"))
                    {
                        filterContext.HttpContext.Response.AppendHeader("Content-encoding", "gzip");
                        filterContext.HttpContext.Response.Filter = new GZipStream(filterContext.HttpContext.Response.Filter, CompressionMode.Compress);
                    }
                    else if (acceptEncoding.Contains("deflate"))
                    {
                        filterContext.HttpContext.Response.AppendHeader("Content-encoding", "deflate");
                        filterContext.HttpContext.Response.Filter = new DeflateStream(filterContext.HttpContext.Response.Filter, CompressionMode.Compress);
                    }
                }
            }
        }
        #endregion

        #region 页面不缓存过滤器
        /// <summary>
        /// 页面不缓存过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //不缓存 页面
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
        }
        #endregion
    }
}