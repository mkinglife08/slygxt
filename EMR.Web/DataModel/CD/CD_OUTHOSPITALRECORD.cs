using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_OuthospitalRecord 出院记录
	/// </summary>
    public class CD_OUTHOSPITALRECORD
    {

        /// <summary>
 	    /// (索引)(主键)出院记录id
	    /// </summary>
		public string OUTHOSPITALRECORDID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 出院时间
	    /// </summary>
		public string DISCHARGETIME{ get; set; }

        /// <summary>
 	    /// 入院原因
	    /// </summary>
		public string HOSPITALIZEDCAUSE{ get; set; }

        /// <summary>
 	    /// 转院日期
	    /// </summary>
		public string TRANSFERDATE{ get; set; }

        /// <summary>
 	    /// 转往医疗机构名称
	    /// </summary>
		public string TRANSFERINSTITUTIONS{ get; set; }

        /// <summary>
 	    /// 转往医院联系医生
	    /// </summary>
		public string TRANSFERDOCTOR{ get; set; }

        /// <summary>
 	    /// 转院目的
	    /// </summary>
		public string TRANSFERPURPOSE{ get; set; }

        /// <summary>
 	    /// 入院情况
	    /// </summary>
		public string HOSPITALIZEDCASE{ get; set; }

        /// <summary>
 	    /// 住院诊治经过
	    /// </summary>
		public string HOSPITALCOURSE{ get; set; }

        /// <summary>
 	    /// 出院状况
	    /// </summary>
		public string DISCHARGESTATUS{ get; set; }

        /// <summary>
 	    /// 出院带药
	    /// </summary>
		public string DISCHARGEMEDICATION{ get; set; }

        /// <summary>
 	    /// 出院体温
	    /// </summary>
		public decimal? DISCHARGETEMPERATURE{ get; set; }

        /// <summary>
 	    /// 出院脉搏
	    /// </summary>
		public decimal? DISCHARGEPULSE{ get; set; }

        /// <summary>
 	    /// 出院呼吸
	    /// </summary>
		public decimal? DISCHARGEBREATHE{ get; set; }

        /// <summary>
 	    /// 出院血压
	    /// </summary>
		public string DISCHARGEBLOODPRESSURE{ get; set; }

        /// <summary>
 	    /// 出院体重
	    /// </summary>
		public decimal? DISCHARGEBODYWEIGHT{ get; set; }

        /// <summary>
 	    /// 出院去向  254
	    /// </summary>
		public string DISCHARGEWHERE{ get; set; }

        /// <summary>
 	    /// 出院去向其他
	    /// </summary>
		public string DISCHARGEWHEREOTHER{ get; set; }

        /// <summary>
 	    /// 是否需要随访
	    /// </summary>
		public string TOLLOWUPGUIDANCESTATE{ get; set; }

        /// <summary>
 	    /// 随访指导
	    /// </summary>
		public string TOLLOWUPGUIDANCE{ get; set; }

        /// <summary>
 	    /// 记录类型：0：24小时内入出院记录，1：出院记录，2：出观记录，3：自动出院记录，4：产科新生儿出院记录，5：转院记录

	    /// </summary>
		public string RECORDTYPE{ get; set; }

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