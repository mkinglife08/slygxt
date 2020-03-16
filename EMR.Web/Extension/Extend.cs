
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using EMR.Web.Extension.Models;
using EMR.Web.Extension.Common;

namespace EMR.Web.Extension
{
    public static class Extend
    {
        private const string FORBIDDEN_WORD = @"execute|exec|select|insert|update|delete|create|drop|alter|exists|table|sysobjects|truncate|union|and|order|xor|or|mid|cast|where|asc|desc|xp_cmdshell|join|declare|nvarchar|varchar|char|sp_oacreate|wscript.shell|xp_regwrite|\'|%|;|\-\-|\*|!";
        /// <summary>
        /// 危险字符过滤（已过期，最新方法已经在页面POST时就自动过滤，无需调用该方法）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [Obsolete]
        public static string StringFilter(this string str)
        {
            string strReturn = "";
            strReturn = Regex.Replace(str, FORBIDDEN_WORD, "", RegexOptions.IgnoreCase);
            return strReturn;
        }

        /// <summary>
        /// 过滤HTML字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceHtml(this string str)
        {
            string regexstr = @"<.*?>";   //去除所有标签，只剩img,br,p

            return Regex.Replace(str, regexstr, string.Empty, RegexOptions.IgnoreCase).Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }

        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strEncrypt">加密类型（md5或者sha1）</param>
        /// <returns></returns>
        public static string ToEncrypt(this string str, string strEncrypt)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, strEncrypt);
        }

        /// <summary>
        /// 获取当前登录的用户信息。
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UserToken GetUserToken(this string token)
        {
            return UserTokenManager.GetUserToken(token);
        }

    }
}