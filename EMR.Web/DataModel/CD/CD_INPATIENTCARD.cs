using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_InpatientCard 住院卡
	/// </summary>
    public class CD_INPATIENTCARD
    {

        /// <summary>
 	    /// (索引)(主键)住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 并发症
	    /// </summary>
		public string COMPLICATION{ get; set; }

        /// <summary>
 	    /// 治疗简要
	    /// </summary>
		public string BRIEFTREATMENT{ get; set; }

        /// <summary>
 	    /// 愈合时间
	    /// </summary>
		public string HEALINGTIME{ get; set; }

        /// <summary>
 	    /// 术后并发症 :休克;出血;脓肿;裂缝;肺炎;败血症;其他;无
	    /// </summary>
		public string COMPLICATIONS{ get; set; }

        /// <summary>
 	    /// 接收医院
	    /// </summary>
		public string RECEIVINGHOSPITAL{ get; set; }

        /// <summary>
 	    /// 接收社区
	    /// </summary>
		public string RECEIVINGCOMMUNITY{ get; set; }

        /// <summary>
 	    /// 疾病转归;医嘱离院;非医嘱离院;死亡;其他
	    /// </summary>
		public string DISEASEOUTCOME{ get; set; }

        /// <summary>
 	    /// 保存状态
	    /// </summary>
		public decimal? SAVESTATE{ get; set; }

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