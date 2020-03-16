using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_Consultation 会诊单
	/// </summary>
    public class CD_CONSULTATION
    {

        /// <summary>
 	    /// (索引)(主键)会诊记录id
	    /// </summary>
		public string CONSULTATIONID{ get; set; }

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
 	    /// 会诊状态：1：新开、2：已回复
	    /// </summary>
		public string CONSULTATIONSTATE{ get; set; }

        /// <summary>
 	    /// 会诊类型：1：普通 2：紧急
	    /// </summary>
		public string CONSULTATIONTYPE{ get; set; }

        /// <summary>
 	    /// 会诊医院类型：1：本院 2：外院
	    /// </summary>
		public string HOSPITALTYPE{ get; set; }

        /// <summary>
 	    /// 会诊医院名称
	    /// </summary>
		public string HOSPITALNAME{ get; set; }

        /// <summary>
 	    /// 请求时间
	    /// </summary>
		public DateTime? APPLYTIME{ get; set; }

        /// <summary>
 	    /// 病情摘要
	    /// </summary>
		public string DISEASESUMMARY{ get; set; }

        /// <summary>
 	    /// 请求科室代码
	    /// </summary>
		public string APPLYDEPARTCODE{ get; set; }

        /// <summary>
 	    /// 请求科室名称
	    /// </summary>
		public string APPLYDEPARTNAME{ get; set; }

        /// <summary>
 	    /// 请求病区代码
	    /// </summary>
		public string APPLYWARDCODE{ get; set; }

        /// <summary>
 	    /// 请求病区名称
	    /// </summary>
		public string APPLYWARDNAME{ get; set; }

        /// <summary>
 	    /// 请求医生代码
	    /// </summary>
		public string APPLYDOCTORCODE{ get; set; }

        /// <summary>
 	    /// 请求医生姓名
	    /// </summary>
		public string APPLYDOCTORNAME{ get; set; }

        /// <summary>
 	    /// 申请科室代码
	    /// </summary>
		public string REQUESTDEPARTCODE{ get; set; }

        /// <summary>
 	    /// 申请人代码
	    /// </summary>
		public string REQUESTERCODE{ get; set; }

        /// <summary>
 	    /// 审核签名时间
	    /// </summary>
		public string VERIFIERTIME{ get; set; }

        /// <summary>
 	    /// 审核签名医生代码
	    /// </summary>
		public string VERIFIERCODE{ get; set; }

        /// <summary>
 	    /// 答复时间
	    /// </summary>
		public DateTime? REPLYTIME{ get; set; }

        /// <summary>
 	    /// 答复内容
	    /// </summary>
		public string REPLYCONTENT{ get; set; }

        /// <summary>
 	    /// 答复科室代码
	    /// </summary>
		public string REPLYDEPARTCODE{ get; set; }

        /// <summary>
 	    /// 答复科室名称
	    /// </summary>
		public string REPLYDEPARTNAME{ get; set; }

        /// <summary>
 	    /// 答复病区代码
	    /// </summary>
		public string REPLYWARDCODE{ get; set; }

        /// <summary>
 	    /// 答复病区名称
	    /// </summary>
		public string REPLYWARDNAME{ get; set; }

        /// <summary>
 	    /// 答复医生代码
	    /// </summary>
		public string REPLYDOCTORCODE{ get; set; }

        /// <summary>
 	    /// 答复医生姓名
	    /// </summary>
		public string REPLYDOCTORNAME{ get; set; }

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