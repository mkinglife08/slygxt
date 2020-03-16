using System;

namespace DataModel.GI
{
    /// <summary>
 	/// GI_SYSAPPINFO  系统模块信息
	/// </summary>
    public class GI_SYSAPPINFO
    {

        /// <summary>
 	    /// (索引)(主键)系统模块代码
	    /// </summary>
		public string SYSID{ get; set; }

        /// <summary>
 	    /// 组织机构代码
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 系统模块名称
	    /// </summary>
		public string SYSNAME{ get; set; }

        /// <summary>
 	    /// 系统模块简称
	    /// </summary>
		public string SHORTNAME{ get; set; }

        /// <summary>
 	    /// 系统模块图标
	    /// </summary>
		public string SYSICON{ get; set; }

        /// <summary>
 	    /// 系统模块说明
	    /// </summary>
		public string SYSNOTE{ get; set; }

        /// <summary>
 	    /// 是否作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }

        /// <summary>
 	    /// 修改用户代码
	    /// </summary>
		public string MODIFYUSERCODE{ get; set; }

        /// <summary>
 	    /// 修改操作时间
	    /// </summary>
		public DateTime? MODIFYTIME{ get; set; }

        /// <summary>
 	    /// 默认页面
	    /// </summary>
		public string DEFAULTPAGE{ get; set; }

        /// <summary>
 	    /// 显示排序序号
	    /// </summary>
		public decimal? DISPLAYSORT{ get; set; }

        /// <summary>
 	    /// 
	    /// </summary>
		public string DEFAULTTITLE{ get; set; }
      
    }
}