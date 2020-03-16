using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_HospitalRecord 入院记录
	/// </summary>
    public class CD_HOSPITALRECORD
    {

        /// <summary>
 	    /// (索引)(主键)入院记录id
	    /// </summary>
		public string HOSPITALRECORDID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 记录类型  816

	    /// </summary>
		public decimal? RECORDTYPE{ get; set; }

        /// <summary>
 	    /// 病史陈述者
	    /// </summary>
		public string NARRATOR{ get; set; }

        /// <summary>
 	    /// 病史陈述者其他
	    /// </summary>
		public string NARRATORSUPPLEMENT{ get; set; }

        /// <summary>
 	    /// 主诉
	    /// </summary>
		public string CHIEFCOMPLAINT{ get; set; }

        /// <summary>
 	    /// 现病史
	    /// </summary>
		public string PRESENTHISTORY{ get; set; }

        /// <summary>
 	    /// 既往史
	    /// </summary>
		public string PREVIOUSHISTORY{ get; set; }

        /// <summary>
 	    /// 系统回顾
	    /// </summary>
		public string SYSTEMREVIEW{ get; set; }

        /// <summary>
 	    /// 个人史
	    /// </summary>
		public string PERSONALHISTORY{ get; set; }

        /// <summary>
 	    /// 婚育史
	    /// </summary>
		public string OBSTERICALHISTORY{ get; set; }

        /// <summary>
 	    /// 月经史
	    /// </summary>
		public string MENSESHISTORY{ get; set; }

        /// <summary>
 	    /// 家族史
	    /// </summary>
		public string FAMILYHISTORY{ get; set; }

        /// <summary>
 	    /// 喂养史
	    /// </summary>
		public string FEEDINGHISTORY{ get; set; }

        /// <summary>
 	    /// 出生史
	    /// </summary>
		public string BIRTHHISTORY{ get; set; }

        /// <summary>
 	    /// 体格检查
	    /// </summary>
		public string PHYSICALEXAM{ get; set; }

        /// <summary>
 	    /// 专科检查
	    /// </summary>
		public string SPECIALINSPECTION{ get; set; }

        /// <summary>
 	    /// 实验室检查
	    /// </summary>
		public string LABORATORYEXAMINATION{ get; set; }

        /// <summary>
 	    /// 特殊检查
	    /// </summary>
		public string SPECIALEXAMINATION{ get; set; }

        /// <summary>
 	    /// 病理检查
	    /// </summary>
		public string PATHOLOGICALEXAMINATION{ get; set; }

        /// <summary>
 	    /// 其他内容
	    /// </summary>
		public string OTHERCONTENT{ get; set; }

        /// <summary>
 	    /// 修改历史
	    /// </summary>
		public decimal? CHANGEHISTORY{ get; set; }

        /// <summary>
 	    /// 创建用户ID
	    /// </summary>
		public string CREATOR{ get; set; }

        /// <summary>
 	    /// 保存方式0：暂存1：保存
	    /// </summary>
		public decimal? RECORDSTATE{ get; set; }

        /// <summary>
 	    /// 记录时间
	    /// </summary>
		public DateTime? RECORDTIME{ get; set; }

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