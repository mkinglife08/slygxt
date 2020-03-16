using System;

namespace DataModel.GI
{
    /// <summary>
 	/// GI_ORGANINFO  组织机构信息表
	/// </summary>
    public class GI_ORGANINFO
    {

        /// <summary>
 	    /// (索引)(主键)组织机构代码
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 父类机构代码
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// 组织机构名称
	    /// </summary>
		public string ORGANNAME{ get; set; }

        /// <summary>
 	    /// 组织机构简称
	    /// </summary>
		public string SHORTNAME{ get; set; }

        /// <summary>
 	    /// 组织机构图标
	    /// </summary>
		public string ORGANICON{ get; set; }

        /// <summary>
 	    /// 组织机构地址
	    /// </summary>
		public string ADDRESS{ get; set; }

        /// <summary>
 	    /// 组织机构电话
	    /// </summary>
		public string ORGANTEL{ get; set; }

        /// <summary>
 	    /// 机构联系人员
	    /// </summary>
		public string ORGANUSER{ get; set; }

        /// <summary>
 	    /// 组织机构介绍
	    /// </summary>
		public string ORGANNOTE{ get; set; }

        /// <summary>
 	    /// 机构启用日期
	    /// </summary>
		public DateTime? STARTDATE{ get; set; }

        /// <summary>
 	    /// 机构终止日期
	    /// </summary>
		public DateTime? STOPDATE{ get; set; }

        /// <summary>
 	    /// 拼音码
	    /// </summary>
		public string SPELLCODE{ get; set; }

        /// <summary>
 	    /// 自定义码
	    /// </summary>
		public string CUSTOMCODE{ get; set; }

        /// <summary>
 	    /// 修改用户代码
	    /// </summary>
		public string MODIFYUSER{ get; set; }

        /// <summary>
 	    /// 修改操作时间
	    /// </summary>
		public DateTime? MODIFYTIME{ get; set; }

        /// <summary>
 	    /// 是否作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }

        /// <summary>
 	    /// 末级判别0不是末级1末级
	    /// </summary>
		public decimal? ISLAST{ get; set; }
      
    }
}