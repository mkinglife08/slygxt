using System;

namespace DataModel.AI
{
    /// <summary>
 	/// AI_Diagnosis  标准诊断
	/// </summary>
    public class AI_DIAGNOSIS
    {

        /// <summary>
 	    /// 诊断id
	    /// </summary>
		public string DIAGNOSISID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 父诊断ID
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// 疾病代码编码
	    /// </summary>
		public string DIAGNOSISCODE{ get; set; }

        /// <summary>
 	    /// ICD代码
	    /// </summary>
		public string ICDCODE{ get; set; }

        /// <summary>
 	    /// 诊断名称
	    /// </summary>
		public string DIAGNOSISNAME{ get; set; }

        /// <summary>
 	    /// 诊断类别  468

	    /// </summary>
		public string DIAGNOSISTYPE{ get; set; }

        /// <summary>
 	    /// 报卡类型   484
	    /// </summary>
		public decimal? REPORTCARDID{ get; set; }

        /// <summary>
 	    /// 排列顺序
	    /// </summary>
		public decimal? SORTORDER{ get; set; }

        /// <summary>
 	    /// 拼音码
	    /// </summary>
		public string SPELLCODE{ get; set; }

        /// <summary>
 	    /// 自定义码
	    /// </summary>
		public string CUSTOMCODE{ get; set; }

        /// <summary>
 	    /// 备注使用说明
	    /// </summary>
		public string BZSYSM{ get; set; }

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