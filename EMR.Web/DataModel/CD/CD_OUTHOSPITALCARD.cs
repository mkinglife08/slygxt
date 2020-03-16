using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_OuthospitalCard 出院证
	/// </summary>
    public class CD_OUTHOSPITALCARD
    {

        /// <summary>
 	    /// (索引)(主键)住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 建议
	    /// </summary>
		public string PROPOSAL{ get; set; }

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