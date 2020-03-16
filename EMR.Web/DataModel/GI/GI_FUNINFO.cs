using System;

namespace DataModel.GI
{
    /// <summary>
 	/// GI_FUNINFO  系统功能定义
	/// </summary>
    public class GI_FUNINFO
    {

        /// <summary>
 	    /// (索引)(主键)功能定义序号
	    /// </summary>
		public string FUNID{ get; set; }

        /// <summary>
 	    /// 组织机构代码
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 父类定义序号
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// 系统模块代码
	    /// </summary>
		public string SYSID{ get; set; }

        /// <summary>
 	    /// 功能定义名称
	    /// </summary>
		public string FUNNAME{ get; set; }

        /// <summary>
 	    /// 是否末级判别
	    /// </summary>
		public decimal? ISLAST{ get; set; }

        /// <summary>
 	    /// 功能对应页面
	    /// </summary>
		public string FUNPAGE{ get; set; }

        /// <summary>
 	    /// 定义显示判别0不显示1显示
	    /// </summary>
		public decimal? ISSHOW{ get; set; }

        /// <summary>
 	    /// 定义备注信息
	    /// </summary>
		public string FUNNTOE{ get; set; }

        /// <summary>
 	    /// 功能定义图片
	    /// </summary>
		public string FUNICON{ get; set; }

        /// <summary>
 	    /// 定义选中图片
	    /// </summary>
		public string CHECKICON{ get; set; }

        /// <summary>
 	    /// 拼音码
	    /// </summary>
		public string SPELLCODE{ get; set; }

        /// <summary>
 	    /// 自定义码
	    /// </summary>
		public string CUSTOMCODE{ get; set; }

        /// <summary>
 	    /// 修改操作时间
	    /// </summary>
		public DateTime? MODIFYTIME{ get; set; }

        /// <summary>
 	    /// 修改用户代码
	    /// </summary>
		public string MODIFYUSERCODE{ get; set; }

        /// <summary>
 	    /// 功能定义级别：左侧菜单加载第一级别，用户功能第二，页面权限第三....
	    /// </summary>
		public decimal? FUNLEVEL{ get; set; }

        /// <summary>
 	    /// 显示排序序号
	    /// </summary>
		public decimal? DISPLAYSORT{ get; set; }

        /// <summary>
 	    /// 是否作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }
      
    }
}