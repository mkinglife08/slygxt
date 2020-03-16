using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_FormEmr 表单病历
	/// </summary>
    public class CD_FORMEMR
    {

        /// <summary>
 	    /// (索引)(主键)表单病历id
	    /// </summary>
		public string FORMEMRID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 分类id
	    /// </summary>
		public string CATEGORYID{ get; set; }

        /// <summary>
 	    /// 模板id
	    /// </summary>
		public string FORMID{ get; set; }

        /// <summary>
 	    /// 知情同意书内容
	    /// </summary>
		public string FORMCONTENT{ get; set; }

        /// <summary>
 	    /// 修改历史
	    /// </summary>
		public decimal? CHANGEHISTORY{ get; set; }

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