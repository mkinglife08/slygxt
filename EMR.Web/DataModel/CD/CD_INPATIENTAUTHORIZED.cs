using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_InpatientAuthorized    住院病人授权
	/// </summary>
    public class CD_INPATIENTAUTHORIZED
    {

        /// <summary>
 	    /// (索引)(主键)住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 被授权人ID
	    /// </summary>
		public string AUTHORIZEDPERSONID{ get; set; }

        /// <summary>
 	    /// 被授权人姓名
	    /// </summary>
		public string AUTHORIZEDPERSONNAME{ get; set; }

        /// <summary>
 	    /// 授权原因
	    /// </summary>
		public string AUTHORIZEDREASON{ get; set; }

        /// <summary>
 	    /// 被授权时间
	    /// </summary>
		public DateTime? AUTHORIZEDPERSONTIME{ get; set; }

        /// <summary>
 	    /// 创建时间
	    /// </summary>
		public DateTime? CREATETIME{ get; set; }

        /// <summary>
 	    /// 创建人
	    /// </summary>
		public string CREATOR{ get; set; }
      
    }
}