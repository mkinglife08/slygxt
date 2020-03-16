using System;

namespace DataModel.GI
{
    /// <summary>
 	/// GI_MedicalGroup  医疗组
	/// </summary>
    public class GI_MEDICALGROUP
    {

        /// <summary>
 	    /// (索引)(主键)医疗组序号
	    /// </summary>
		public string MEDICALID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 医疗组名称
	    /// </summary>
		public string MEDICALNAME{ get; set; }

        /// <summary>
 	    /// 医疗组说明
	    /// </summary>
		public string MEDICALNOTE{ get; set; }

        /// <summary>
 	    /// 医疗组管理员
	    /// </summary>
		public string USERID{ get; set; }

        /// <summary>
 	    /// 作废判别0正常1作废
	    /// </summary>
		public decimal? ISDEL{ get; set; }

        /// <summary>
 	    /// 操作时间
	    /// </summary>
		public DateTime? MODIFYTIME{ get; set; }

        /// <summary>
 	    /// 修改用户
	    /// </summary>
		public string MODIFYUSERID{ get; set; }
      
    }
}