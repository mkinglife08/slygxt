using System;

namespace DataModel.CD
{
    /// <summary>
 	/// 病人诊断
	/// </summary>
    public class CD_PATIENTDIAGNOSIS
    {

        /// <summary>
 	    /// (索引)(主键)诊断id
	    /// </summary>
		public string DIAGNOSISID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 病历记录id
	    /// </summary>
		public string RECORDID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 父诊断ID
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// ICD代码
	    /// </summary>
		public string ICDCODE{ get; set; }

        /// <summary>
 	    /// 诊断名称
	    /// </summary>
		public string DIAGNOSISNAME{ get; set; }

        /// <summary>
 	    /// 诊断名称补充
	    /// </summary>
		public string DIAGNOSISNAMESUPPLEMENT{ get; set; }

        /// <summary>
 	    /// 确诊标志   489
	    /// </summary>
		public decimal? DIAGNOSISFLAG{ get; set; }

        /// <summary>
 	    /// 诊断类别  468

	    /// </summary>
		public string DIAGNOSISTYPE{ get; set; }

        /// <summary>
 	    /// 入院病情
	    /// </summary>
		public string ADMISSIONILLNESS{ get; set; }

        /// <summary>
 	    /// 记录医生
	    /// </summary>
		public string RECORDUSERID{ get; set; }

        /// <summary>
 	    /// 记录医生姓名
	    /// </summary>
		public string RECORDUSERNAME{ get; set; }

        /// <summary>
 	    /// 诊断时间
	    /// </summary>
		public DateTime? DIAGNOSISTIME{ get; set; }

        /// <summary>
 	    /// 报卡类型   484
	    /// </summary>
		public decimal? REPORTCARDID{ get; set; }

        /// <summary>
 	    /// 排列顺序
	    /// </summary>
		public decimal? SORTORDER{ get; set; }

        /// <summary>
 	    /// 主诊断标志0不是1是
	    /// </summary>
		public decimal? MAINDIAGNOSIS{ get; set; }

        /// <summary>
 	    /// 作废标志
	    /// </summary>
		public decimal? DEL{ get; set; }

        /// <summary>
 	    /// 创建时间
	    /// </summary>
		public DateTime? CREATETIME{ get; set; }

        /// <summary>
 	    /// 创建人
	    /// </summary>
		public string CREATOR{ get; set; }

        /// <summary>
 	    /// 更新时间
	    /// </summary>
		public DateTime? UPDATETIME{ get; set; }

        /// <summary>
 	    /// 更新人
	    /// </summary>
		public string UPDATER{ get; set; }
      
    }
}