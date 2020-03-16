using FastUntility.Base;
using FastUntility.WinService;
using System.Web.Mvc;

namespace EMR.Web.Filter
{
    public class ErrorAttribute : HandleErrorAttribute
    {
        #region 出错处理
        /// <summary>
        /// 出错处理
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.ExceptionHandled = true;

            filterContext.Result = new ContentResult { Content = filterContext.Exception.StackTrace };

            BaseLog.SaveLog(string.Format("ip:{0}，错误内容:{1}", Win32PSI.IP(), filterContext.Exception.StackTrace), "web_error");
        }
        #endregion
    }
}