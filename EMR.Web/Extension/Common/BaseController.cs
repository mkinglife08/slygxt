using EMR.Core;
using EMR.Data;
using EMR.Data.CustomAttribute;
using EMR.Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace EMR.Web.Extension.Common
{
    public class BaseController : Controller
    {
        private string NoLoginPage = ConfigurationManager.AppSettings["NoLoginPage"];
        private const string FORBIDDEN_WORD = "";
        private string Globle_Message = "";
        bool IsTokenAuthorized = false;
        /// <summary>
        /// 带有string返回值的委托
        /// </summary>
        /// <returns></returns>
        public delegate string UI_Business_Logic_Handler();
        /// <summary>
        /// 用于WebApi_Result实体返回值的委托
        /// </summary>
        /// <returns></returns>
        public delegate WebApi_Result UI_Business_Logic_JsonResult_Handler();

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Filter();//防注入机制
            var CurPath = RouteData.Values["path"].ToString();
            var CurControl = RouteData.Values["controller"].ToString();
            bool havaPage = true;
        
            //过滤非法访问路径
            if (!havaPage)
            {
                Response.Write(ResponseJsonResult(new WebApi_Result() { code = 404, msg = "访问的页面不存在！" }));
                Response.End();
                return;
            }
            IsTokenAuthorized = IsAuthorized();
            IsTokenAuthorized = NoLoginPage.Split('|').Where(f => requestContext.HttpContext.Request.Url.ToString().Contains(f)).Count() > 0 || IsTokenAuthorized;
        }

        #region 带操作提示返回值的业务处理委托，自动返回处理结果提示信息。
        /// <summary>
        /// AJAX跨域调用接口时的业务处理委托
        /// </summary>
        /// <param name="actionName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public string ExecuteActionJsonResult_ForDomin(string actionName, UI_Business_Logic_JsonResult_Handler handler)
        {
            return Request["jsoncallback"] + "(" + ExecuteActionJsonResult(actionName, handler) + ")";
        }

        /// <summary>
        /// 带WebApi_Result实体返回值的业务处理委托。（用于非跨域的AJAX接口调用）
        /// </summary>
        /// <param name="actionName">操作名称</param>
        /// <param name="handler">业务处理委托</param>
        public string ExecuteActionJsonResult(string actionName, UI_Business_Logic_JsonResult_Handler handler)
        {
            try
            {
                var _WebApi_Result = new WebApi_Result() { code = 13, msg = "登录凭证失效，获取数据失败！" };
                if (IsTokenAuthorized)
                {
                    _WebApi_Result = handler();
                    _WebApi_Result.msg = _WebApi_Result.msg == null ? actionName + "成功！" : _WebApi_Result.msg;
                    _WebApi_Result.code = _WebApi_Result.code == null ? 0 : _WebApi_Result.code;
                }
                return ResponseJsonResult(_WebApi_Result);
            }
            catch (Exception err)
            {
                if (err.Message.Contains("ORA-12570"))
                    ExecuteActionJsonResult(actionName, handler);
                string strErrorContent = actionName + "失败！-------" + err.Message;
                if (string.IsNullOrWhiteSpace(Request["token"].GetUserToken().UserId))
                    strErrorContent += "----------用户ID：" + Request["token"].GetUserToken().UserId;
                FileLog.AddErrorLog(strErrorContent);
                Globle_Message = strErrorContent;
                return ResponseJsonResult(new WebApi_Result() { code = 6 });
            }
            finally
            {
                //Response.End();//Response.End必须放在finally里面执行，否则会报“正在中止线程”的错误 http://www.cnblogs.com/jintianhu/archive/2011/02/16/1952833.html
            }
        }

        #endregion

        #region ResponseJsonResult：向客户端输出JSON格式的返回值
        /// <summary>
        /// 向客户端输出JSON格式的返回值
        /// </summary>
        /// <param name="objResult">返回数据</param>
        /// <param name="Message">消息体</param>
        [Obsolete]
        public string ResponseJsonResult(object objResult = null, object Message = null)
        {
            WebApi_Result result = new WebApi_Result() { code = objResult == null ? 7 : 0, data = objResult, msg = Message };
            return ResponseJsonResult(result);
        }

        /// <summary>
        /// 向客户端输出JSON格式的返回值
        /// </summary>
        /// <param name="WebApi_Result">返回的WebApi_Result实体</param>
        public string ResponseJsonResult(WebApi_Result WebApi_Result)
        {
            WebApi_Result.msg = WebApi_Result.msg == null ? Globle_Message : WebApi_Result.msg;
            string strJsonResult = new JavaScriptSerializer().Serialize(WebApi_Result);
            //Response.Write(strJsonResult);
            return strJsonResult;
        }
        #endregion

        #region GetPageData：获取页面数据并转换成指定的实体
        /// <summary>
        /// 获取页面数据并转换成指定的实体。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="minValuePINum">最小有值字段数，若有值字段的数量小于该数字，将返回null</param>
        /// <returns></returns>
        public T GetPageData<T>(int minValuePINum = 2)
        {
            if (typeof(System.Web.Mvc.Filter).IsAssignableFrom(typeof(T)))//判断T是否继承了Filter
                minValuePINum = -1;
            T _t = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertys = _t.GetType().GetProperties();
            int haveValuePINum = 0;
            foreach (PropertyInfo pi in propertys)
            {
                string name = pi.Name;
                //如果参数是文件
                if (pi.GetCustomAttribute<FieldTypeAttribute>() != null && pi.GetCustomAttribute<FieldTypeAttribute>().fieldType == FieldTypeEnum.File)
                {
                    if (Request.Files[name] != null && Request.Files[name].ContentLength > 10)
                    {
                        //do save file 
                        string PostFileName = Request.Files[name].FileName;
                        string FileName = DateTime.Now.ToFileTime() + PostFileName.Substring(PostFileName.LastIndexOf("."));
                        string SavePath = "/UserFiles/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
                        if (!Directory.Exists(Request.MapPath(SavePath)))
                            Directory.CreateDirectory(Request.MapPath(SavePath));
                        Request.Files[name].SaveAs(Request.MapPath(SavePath + FileName));
                        pi.SetValue(_t, SavePath + FileName);
                        haveValuePINum++;
                    }
                }
                else if (pi.GetCustomAttribute<FieldTypeAttribute>() != null && pi.GetCustomAttribute<FieldTypeAttribute>().fieldType == FieldTypeEnum.Ignore)
                {
                }
                else
                {
                    if (Request[name] != null)
                    {
                        if (pi.PropertyType.FullName.ToLower().Contains("datetime"))
                        {
                            DateTime iTemp = DateTime.Now;
                            if (DateTime.TryParse(Request[name], out iTemp))
                                pi.SetValue(_t, iTemp);
                        }
                        else if (pi.PropertyType.FullName.ToLower().Contains("int"))
                        {
                            int iTemp = 0;
                            if (int.TryParse(Request[name], out iTemp))
                                pi.SetValue(_t, iTemp);
                        }
                        else if (pi.PropertyType.FullName.ToLower().Contains("decimal"))
                        {
                            decimal iTemp = 0;
                            if (decimal.TryParse(Request[name], out iTemp))
                                pi.SetValue(_t, iTemp);
                        }
                        else if (pi.PropertyType.FullName.ToLower().Contains("double"))
                        {
                            double iTemp = 0;
                            if (double.TryParse(Request[name], out iTemp))
                                pi.SetValue(_t, iTemp);
                        }
                        else if (pi.PropertyType.FullName.ToLower().Contains("byte"))
                        {
                            byte iTemp = 0;
                            if (byte.TryParse(Request[name], out iTemp))
                                pi.SetValue(_t, iTemp);
                        }
                        else if (pi.PropertyType.FullName.ToLower().Contains("bool"))
                        {
                            bool iTemp = false;
                            if (bool.TryParse(Request[name], out iTemp))
                                pi.SetValue(_t, iTemp);
                        }
                        else
                            pi.SetValue(_t, Request[name]);
                        haveValuePINum++;
                    }
                    else if (name == "CreateTime" || name == "ModifyTime" || name == "UpdateTime")
                        pi.SetValue(_t, DateTime.Now);
                    else if (name == "Creator" || name == "Updater")
                        pi.SetValue(_t, UserTokenManager.GetUId(Request["token"]));
                    else if (name.ToUpper() == "ORGANID")
                        pi.SetValue(_t, Request["MYORGANID"]);
                }
            }
            if (haveValuePINum <= minValuePINum)
                return default(T);
            return _t;
        }
        #endregion

        public void Log(string content, string username)
        {
            if (!string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(username))
            {
                FileLog.AddUserLog("msg:" + content + "------username:" + username);
                //hqyy_AppEntities db = new hqyy_AppEntities();
                //Log log = new Models.Log()
                //{
                //    AddTime = DateTime.Now,
                //    Event = content,
                //    username = username
                //};
                //db.Log.Add(log);
                //db.SaveChanges();
            }
        }

        public WebApi_Result GetPagedResult<T>(string Filter) where T : class
        {
            List<T> list = EntityOperate<T>.GetEntityListBySQL("select * from " + typeof(T).Name + " where " + Filter);
            if (list == null || list.Count() <= 0)
            {
                return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
            }
            int curpage = 0, limit = 3;
            int.TryParse(Request["page"], out curpage);
            int.TryParse(Request["limit"], out limit);
            var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
            return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
        }

        protected bool IsAuthorized()
        {
            // 验证token
            //var token = actionContext.Request.Headers.Authorization;
            var token = Request["token"];
            //var ts = actionContext.Request.Headers.Where(c => c.Key.ToLower() == "token").FirstOrDefault().Value;
            if (!string.IsNullOrWhiteSpace(token))
            {
                // 验证token
                if (!UserTokenManager.IsExistToken(token))
                {
                    return false;
                }
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                //把 QueryString 属性改为可读写
                isreadonly.SetValue(HttpContext.Request.QueryString, false, null);
                Request.QueryString.Add("MYORGANID", UserTokenManager.GetUserOrganId(token));
                return true;
            }
            return false;
        }

        #region Filter:防注入过滤
        /// <summary>
        /// 防注入过滤
        /// </summary>
        private void Filter()
        {
            try
            {
                // -----------------------防 Post 注入-----------------------
                if (HttpContext.Request.Form != null)
                {
                    //PropertyInfo 需要 using System.Reflection;
                    PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    //把 Form 属性改为可读写
                    isreadonly.SetValue(HttpContext.Request.Form, false, null);

                    for (int k = 0; k < System.Web.HttpContext.Current.Request.Form.Count; k++)
                    {
                        string getsqlkey = HttpContext.Request.Form.Keys[k];
                        string sqlstr = HttpContext.Request.Form[getsqlkey].Replace('<', '＜').Replace('>', '＞').Replace('\'', '＇');
                        HttpContext.Request.Form[getsqlkey] = Regex.Replace(sqlstr, FORBIDDEN_WORD, "", RegexOptions.IgnoreCase);
                    }
                }

                // -----------------------防 GET 注入-----------------------
                if (HttpContext.Request.QueryString != null)
                {
                    PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                    //把 QueryString 属性改为可读写
                    isreadonly.SetValue(HttpContext.Request.QueryString, false, null);

                    for (int k = 0; k < System.Web.HttpContext.Current.Request.QueryString.Count; k++)
                    {
                        string getsqlkey = HttpContext.Request.QueryString.Keys[k];
                        string sqlstr = HttpContext.Request.QueryString[getsqlkey].Replace('<', '＜').Replace('>', '＞').Replace('\'', '＇');
                        HttpContext.Request.QueryString[getsqlkey] = Regex.Replace(sqlstr, FORBIDDEN_WORD, "", RegexOptions.IgnoreCase);
                    }
                }

                // -----------------------防 Cookies 注入-----------------------
                //if (HttpContext.Current.Request.Cookies != null)
                //{
                //    PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                //    //把 Cookies 属性改为可读写
                //    isreadonly.SetValue(HttpContext.Current.Request.Cookies, false, null);

                //    for (int k = 0; k < System.Web.HttpContext.Current.Request.Cookies.Count; k++)
                //    {
                //        string getsqlkey = HttpContext.Current.Request.Cookies.Keys[k];
                //        string sqlstr = HttpContext.Current.Request.Cookies[getsqlkey].Value.Replace('<', '＜').Replace('>', '＞').Replace('\'', '＇');
                //        HttpContext.Current.Request.Cookies[getsqlkey].Value = Regex.Replace(sqlstr, FORBIDDEN_WORD, "", RegexOptions.IgnoreCase);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}