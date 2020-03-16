using System;

namespace DataModel.AI
{
    /// <summary>
 	/// AI_DeptInfo  科室病区
	/// </summary>
    public class AI_DEPTINFO
    {

        /// <summary>
 	    /// (索引)(主键)医疗组序号
	    /// </summary>
		public string DEPTID{ get; set; }

        /// <summary>
 	    /// 代码序号
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// HIS序号
	    /// </summary>
		public string HISID{ get; set; }

        /// <summary>
 	    /// 科室名称
	    /// </summary>
		public string DEPTNAME{ get; set; }

        /// <summary>
 	    /// 拼音码
	    /// </summary>
		public string SPELLCODE{ get; set; }

        /// <summary>
 	    /// 自定义码
	    /// </summary>
		public string CUSTOMCODE{ get; set; }

        /// <summary>
 	    /// 作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }

        /// <summary>
 	    /// 病区判别0不是1是
	    /// </summary>
		public decimal? ISINPATIENT{ get; set; }

        /// <summary>
 	    /// 科室说明
	    /// </summary>
		public string DEPTNOTE{ get; set; }

        /// <summary>
 	    /// 操作时间
	    /// </summary>
		public DateTime? MODIFYTIME{ get; set; }

        /// <summary>
 	    /// 修改用户
	    /// </summary>
		public string MODIFYUSERID{ get; set; }
      
    }
}