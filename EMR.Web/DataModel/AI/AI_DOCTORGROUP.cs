using System;

namespace DataModel.AI
{
    /// <summary>
 	/// CD_DoctorGroup医生分组
	/// </summary>
    public class AI_DOCTORGROUP
    {

        /// <summary>
 	    /// (索引)(主键)医生分组id
	    /// </summary>
		public string DOCTORGROUPID{ get; set; }

        /// <summary>
 	    /// 组号
	    /// </summary>
		public string GROUPNUM{ get; set; }

        /// <summary>
 	    /// 组名
	    /// </summary>
		public string GROUPNAME{ get; set; }

        /// <summary>
 	    /// 组长id
	    /// </summary>
		public string CHIEFID{ get; set; }

        /// <summary>
 	    /// 组长工号
	    /// </summary>
		public string CHIEFNUM{ get; set; }

        /// <summary>
 	    /// 组长姓名
	    /// </summary>
		public string CHIEFNAME{ get; set; }

        /// <summary>
 	    /// 副组长id
	    /// </summary>
		public string DEPUTYID{ get; set; }

        /// <summary>
 	    /// 副组长工号
	    /// </summary>
		public string DEPUTYNUM{ get; set; }

        /// <summary>
 	    /// 副组长姓名
	    /// </summary>
		public string DEPUTYNAME{ get; set; }

        /// <summary>
 	    /// 所属科室
	    /// </summary>
		public string DEPTID{ get; set; }

        /// <summary>
 	    /// 所属科室名称
	    /// </summary>
		public string DEPTNAME{ get; set; }

        /// <summary>
 	    /// 备注
	    /// </summary>
		public string MEMO{ get; set; }

        /// <summary>
 	    /// 作废标志
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
 	    /// 修改用户
	    /// </summary>
		public string UPDATER{ get; set; }

        /// <summary>
 	    /// 用户修改时间
	    /// </summary>
		public DateTime? UPDATETIME{ get; set; }

        /// <summary>
 	    /// 机构组织代码
	    /// </summary>
		public string ORGANID{ get; set; }
      
    }
}