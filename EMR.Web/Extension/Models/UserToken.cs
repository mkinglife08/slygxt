using System;
namespace EMR.Web.Extension.Models
{
    public class UserToken
    {
        
        public string Permission { get; internal set; }
        public DateTime Timeout { get; internal set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; internal set; }
        /// <summary>
        /// 用户工号
        /// </summary>
        public string USERCODE { get; internal set; }
        /// <summary>
        /// 机构ID
        /// </summary>
        public string ORGANID { get; internal set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string USERNAME { get; internal set; }
        /// <summary>
        /// 操作用户判别
        /// </summary>
        public string ISSUPER { get; internal set; }
        /// <summary>
        /// 病区ID
        /// </summary>
        public string InpatientID { get; internal set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string DpetID { get; internal set; }
        /// <summary>
        /// 绑带IP
        /// </summary>
        public string BindingIP { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserPhoto { get; set; }

        public string Token { get; set; }
        
    }
}