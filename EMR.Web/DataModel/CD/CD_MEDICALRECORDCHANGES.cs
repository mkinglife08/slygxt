using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_MedicalRecordChanges  病历修改记录
	/// </summary>
    public class CD_MEDICALRECORDCHANGES
    {

        /// <summary>
 	    /// (索引)(主键)病历修改记录id
	    /// </summary>
		public string MEDICALRECORDCHANGEID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 病历记录id
	    /// </summary>
		public string RECORDID{ get; set; }

        /// <summary>
 	    /// 修改内容
	    /// </summary>
		public string CHANGECONTENT{ get; set; }

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