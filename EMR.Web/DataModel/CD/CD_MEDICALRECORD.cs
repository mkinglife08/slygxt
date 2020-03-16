using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_MedicalRecord  文书记录 
	/// </summary>
    public class CD_MEDICALRECORD
    {

        /// <summary>
 	    /// (索引)(主键)文书记录序号
	    /// </summary>
		public string RECORDID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 科室id
	    /// </summary>
		public string DEPTID{ get; set; }

        /// <summary>
 	    /// 病区id
	    /// </summary>
		public string WARDID{ get; set; }

        /// <summary>
 	    /// 床号
	    /// </summary>
		public string BEDNUM{ get; set; }

        /// <summary>
 	    /// 病历类别  849

	    /// </summary>
		public decimal? RECORDCLASS{ get; set; }

        /// <summary>
 	    /// 病历名称
	    /// </summary>
		public string RECORDNAME{ get; set; }

        /// <summary>
 	    /// 病历书写状态0：暂存1：保存
	    /// </summary>
		public decimal? RECORDSTATE{ get; set; }

        /// <summary>
 	    /// 记录医师编码
	    /// </summary>
		public string RECORDUSERID{ get; set; }

        /// <summary>
 	    /// 记录医生姓名
	    /// </summary>
		public string RECORDUSERNAME{ get; set; }

        /// <summary>
 	    /// 记录时间
	    /// </summary>
		public DateTime? RECORDTIME{ get; set; }

        /// <summary>
 	    /// 上级医师签名代码
	    /// </summary>
		public string SUPERIORUSERID{ get; set; }

        /// <summary>
 	    /// 上级医生姓名
	    /// </summary>
		public string SUPERIORUSERNAME{ get; set; }

        /// <summary>
 	    /// 病历打印次数
	    /// </summary>
		public decimal? PRINTCOUNT{ get; set; }

        /// <summary>
 	    /// 打印后修改标志 0否1是
	    /// </summary>
		public decimal? AFTERPRINTMODIFY{ get; set; }

        /// <summary>
 	    /// 打印人
	    /// </summary>
		public string PRINTERID{ get; set; }

        /// <summary>
 	    /// 打印人姓名
	    /// </summary>
		public string PRINTERNAME{ get; set; }

        /// <summary>
 	    /// 是否作废判别
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