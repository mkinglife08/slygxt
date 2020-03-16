using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_DeathRecord 死亡记录
	/// </summary>
    public class CD_DEATHRECORD
    {

        /// <summary>
 	    /// (索引)(主键)死亡记录id
	    /// </summary>
		public string DEATHID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 死亡时间
	    /// </summary>
		public string DEATHTIME{ get; set; }

        /// <summary>
 	    /// 入院原因
	    /// </summary>
		public string HOSPITALIZEDCAUSE{ get; set; }

        /// <summary>
 	    /// 入院情况
	    /// </summary>
		public string HOSPITALIZEDCASE{ get; set; }

        /// <summary>
 	    /// 诊治经过
	    /// </summary>
		public string HOSPITALCOURSE{ get; set; }

        /// <summary>
 	    /// 死亡原因
	    /// </summary>
		public string DEATHCAUSE{ get; set; }

        /// <summary>
 	    /// 记录类型：0：24小时内入院死亡记录1：死亡记录
	    /// </summary>
		public decimal? RECORDTYPE{ get; set; }

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