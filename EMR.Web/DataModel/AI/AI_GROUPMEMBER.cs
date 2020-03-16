using System;

namespace DataModel.AI
{
    /// <summary>
 	/// CD_GroupMember 医生组成员
	/// </summary>
    public class AI_GROUPMEMBER
    {

        /// <summary>
 	    /// (主键)医生组成员id
	    /// </summary>
		public string MEMBERID{ get; set; }

        /// <summary>
 	    /// 医生分组id
	    /// </summary>
		public string DOCTORGROUPID{ get; set; }

        /// <summary>
 	    /// 成员id
	    /// </summary>
		public string MEMBER{ get; set; }

        /// <summary>
 	    /// 成员工号
	    /// </summary>
		public string MEMBERNUM{ get; set; }

        /// <summary>
 	    /// 成员姓名
	    /// </summary>
		public string MEMBERNAME{ get; set; }

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