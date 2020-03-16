using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_OperationRecord 手术记录
	/// </summary>
    public class CD_OPERATIONRECORD
    {

        /// <summary>
 	    /// (索引)(主键)手术记录id
	    /// </summary>
		public string OPERATIONID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 手术开始时间
	    /// </summary>
		public DateTime? STARTTIME{ get; set; }

        /// <summary>
 	    /// 手术结束时间
	    /// </summary>
		public DateTime? ENDTIME{ get; set; }

        /// <summary>
 	    /// 手术持续时间
	    /// </summary>
		public string OPERATIONCONTINUETIME{ get; set; }

        /// <summary>
 	    /// 手术代码
	    /// </summary>
		public string OPERATIONCODE{ get; set; }

        /// <summary>
 	    /// 手术名称
	    /// </summary>
		public string OPERATIONNAME{ get; set; }

        /// <summary>
 	    /// 手术级别
	    /// </summary>
		public decimal? OPERATIONLEVEL{ get; set; }

        /// <summary>
 	    /// 主刀医师代码
	    /// </summary>
		public string SURGEONID{ get; set; }

        /// <summary>
 	    /// 主刀医师姓名
	    /// </summary>
		public string SURGEONNAME{ get; set; }

        /// <summary>
 	    /// 一助代码
	    /// </summary>
		public string FIRSTASSISTANTID{ get; set; }

        /// <summary>
 	    /// 一助姓名
	    /// </summary>
		public string FIRSTASSISTANTNAME{ get; set; }

        /// <summary>
 	    /// 二助代码
	    /// </summary>
		public string SECONDASSISTANTID{ get; set; }

        /// <summary>
 	    /// 二助姓名
	    /// </summary>
		public string SECONDASSISTANTNAME{ get; set; }

        /// <summary>
 	    /// 三助代码
	    /// </summary>
		public string THIRDASSISTANTID{ get; set; }

        /// <summary>
 	    /// 三助姓名
	    /// </summary>
		public string THIRDASSISTANTNAME{ get; set; }

        /// <summary>
 	    /// 麻醉方式代码  450

	    /// </summary>
		public decimal? ANESTHESIAWAYCODE{ get; set; }

        /// <summary>
 	    /// 麻醉医师代码1
	    /// </summary>
		public string ANESTHESIA1ID{ get; set; }

        /// <summary>
 	    /// 麻醉医师姓名1
	    /// </summary>
		public string ANESTHESIA1NAME{ get; set; }

        /// <summary>
 	    /// 麻醉医师代码2
	    /// </summary>
		public string ANESTHESIA2ID{ get; set; }

        /// <summary>
 	    /// 麻醉医师姓名2
	    /// </summary>
		public string ANESTHESIA2NAME{ get; set; }

        /// <summary>
 	    /// 术前诊断
	    /// </summary>
		public string PREOPERATIVEDIAGNOSIS{ get; set; }

        /// <summary>
 	    /// 术后诊断
	    /// </summary>
		public string POSTOPERATIVEDIAGNOSIS{ get; set; }

        /// <summary>
 	    /// 手术经过
	    /// </summary>
		public string OPERATIONCOURSE{ get; set; }

        /// <summary>
 	    /// 手术图片
	    /// </summary>
		public string OPERATIONPICTURE{ get; set; }

        /// <summary>
 	    /// ASA分级
	    /// </summary>
		public decimal? ASALEVEL{ get; set; }

        /// <summary>
 	    /// 冰冻切片诊断代码
	    /// </summary>
		public string DIAGNOSTICCODE{ get; set; }

        /// <summary>
 	    /// 冰冻切片诊断名称
	    /// </summary>
		public string DIAGNOSTICNAME{ get; set; }

        /// <summary>
 	    /// 手术标本
	    /// </summary>
		public string SURGICALSPECIMENS{ get; set; }

        /// <summary>
 	    /// 失血量
	    /// </summary>
		public decimal? BLOODLOSS{ get; set; }

        /// <summary>
 	    /// 血、 血制品PRBC
	    /// </summary>
		public decimal? PRBC{ get; set; }

        /// <summary>
 	    /// FFP
	    /// </summary>
		public decimal? FFP{ get; set; }

        /// <summary>
 	    /// PLATES
	    /// </summary>
		public decimal? PLATES{ get; set; }

        /// <summary>
 	    /// 手术类别   797
	    /// </summary>
		public decimal? OPERATIONCATEGORY{ get; set; }

        /// <summary>
 	    /// 手术切口分级  238
	    /// </summary>
		public decimal? INCISIONLEVEL{ get; set; }

        /// <summary>
 	    /// 手术切口愈合等级 343
	    /// </summary>
		public decimal? HEALINGLEVEL{ get; set; }

        /// <summary>
 	    /// NNIS分级
	    /// </summary>
		public decimal? NNISLEVEL{ get; set; }

        /// <summary>
 	    /// 手术类型  802
	    /// </summary>
		public decimal? OPERATIONTYPE{ get; set; }

        /// <summary>
 	    /// 手术其他内容
	    /// </summary>
		public string OPERATIONCONTENT{ get; set; }

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