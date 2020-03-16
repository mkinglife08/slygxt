using System;

namespace DataModel.GI
{
    /// <summary>
 	/// GI_CODEDICT 公用代码字典
	/// </summary>
    public class GI_CODEDICT
    {

        /// <summary>
 	    /// (索引)(主键)代码字典序号
	    /// </summary>
		public string DICTID{ get; set; }

        /// <summary>
 	    /// 父类代码序号
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// 组织机构代码
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 代码字典编码
	    /// </summary>
		public string DICTCODE{ get; set; }

        /// <summary>
 	    /// 字典中文名称
	    /// </summary>
		public string DICTNAME{ get; set; }

        /// <summary>
 	    /// 字典英文名称
	    /// </summary>
		public string DICTNAMEEN{ get; set; }

        /// <summary>
 	    /// 是否作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }

        /// <summary>
 	    /// 是否末级判别0不是未级1未级
	    /// </summary>
		public decimal? ISLAST{ get; set; }

        /// <summary>
 	    /// 显示排序序号
	    /// </summary>
		public decimal? DISPLAYSORT{ get; set; }

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
		public string MODIFYUSERID{ get; set; }

        /// <summary>
 	    /// 对应编码
	    /// </summary>
		public string THECODE{ get; set; }

        /// <summary>
 	    /// 备注
	    /// </summary>
		public string NOTE{ get; set; }
      
    }
}