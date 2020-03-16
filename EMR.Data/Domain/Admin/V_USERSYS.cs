using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.Models
{
    /// <summary>
    /// - V_USERSYS 实体类
    /// </summary>
    public partial class V_USERSYS
    {
        /// <summary>
        ///  
        /// </summary>
        public int? IsDefault { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string SYSID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string OrganID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string SYSName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string SYSICON { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string SYSNote { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? IsCance { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string ModifyUserCode { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string DefaultPage { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? DisplaySort { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string DefaultTitle { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 标识列名
        /// </summary>
        public string MyIdentity { get; set; }
    }
}
