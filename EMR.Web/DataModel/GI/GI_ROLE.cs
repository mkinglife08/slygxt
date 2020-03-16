namespace DataModel.GI
{
    /// <summary>
 	/// GI_ROLE  系统用户分组
	/// </summary>
    public class GI_ROLE
    {

        /// <summary>
 	    /// (索引)(主键)用户分组编号
	    /// </summary>
		public string ROLEID{ get; set; }

        /// <summary>
 	    /// 组织机构代码
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 用户分组名称
	    /// </summary>
		public string ROLENAME{ get; set; }

        /// <summary>
 	    /// 用户分组说明
	    /// </summary>
		public string ROLENOTE{ get; set; }

        /// <summary>
 	    /// 权限控制1增加2删除3修改4查看2打印6授权
	    /// </summary>
		public string ROLEPOWER{ get; set; }

        /// <summary>
 	    /// 是否作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }
      
    }
}