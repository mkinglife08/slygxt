using System;

namespace DataModel.AI
{
    /// <summary>
 	/// AI_StructuredTemplate 结构化模板
	/// </summary>
    public class AI_STRUCTUREDTEMPLATE
    {

        /// <summary>
 	    /// (索引)(主键)模板id
	    /// </summary>
		public string TEMPLATEID{ get; set; }

        /// <summary>
 	    /// 父模板id
	    /// </summary>
		public string PARENTTEMPID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 模板名称
	    /// </summary>
		public string TEMPLATENAME{ get; set; }

        /// <summary>
 	    /// 模板类型  806 
	    /// </summary>
		public decimal? TEMPLATETYPE{ get; set; }

        /// <summary>
 	    /// 共享类型 811
	    /// </summary>
		public decimal? SHARETYPE{ get; set; }

        /// <summary>
 	    /// 共享范围
	    /// </summary>
		public string SHARERANGE{ get; set; }

        /// <summary>
 	    /// 是否分类判别
	    /// </summary>
		public decimal? ISCATEGORY{ get; set; }

        /// <summary>
 	    /// 模板数据
	    /// </summary>
		public string TEMPLATEDATA{ get; set; }

        /// <summary>
 	    /// 模板内容
	    /// </summary>
		public string TEMPLATECONTENT{ get; set; }

        /// <summary>
 	    /// 作废标志
	    /// </summary>
		public decimal? DEL{ get; set; }

        /// <summary>
 	    /// 创建用户ID
	    /// </summary>
		public string CREATOR{ get; set; }

        /// <summary>
 	    /// 用户创建时间
	    /// </summary>
		public DateTime? CREATETIME{ get; set; }

        /// <summary>
 	    /// 修改用户ID
	    /// </summary>
		public string UPDATER{ get; set; }

        /// <summary>
 	    /// 用户修改时间
	    /// </summary>
		public DateTime? UPDATETIME{ get; set; }
      
    }
}