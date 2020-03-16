using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_ProgressNote 病程记录
	/// </summary>
    public class CD_PROGRESSNOTE
    {

        /// <summary>
 	    /// (索引)(主键)病程记录id
	    /// </summary>
		public string PROGRESSNOTEID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 病程类别id  824
	    /// </summary>
		public decimal? PROGRESSTYPEID{ get; set; }

        /// <summary>
 	    /// 病程记录时间
	    /// </summary>
		public string PROGRESSNOTETIME{ get; set; }

        /// <summary>
 	    /// 记录类型补充
	    /// </summary>
		public string RECORDCONTENTSUPPLEMENT{ get; set; }

        /// <summary>
 	    /// 是否需要家属签名
	    /// </summary>
		public decimal? FAMILYSIGNATURE{ get; set; }

        /// <summary>
 	    /// 是否需要换页打印
	    /// </summary>
		public decimal? CHANGEPAGEPRINT{ get; set; }

        /// <summary>
 	    /// 记录内容
	    /// </summary>
		public string RECORDCONTENT{ get; set; }

        /// <summary>
 	    /// 查房医师代码
	    /// </summary>
		public string WARDROUNDUSERID{ get; set; }

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