namespace DataModel.GI
{
    /// <summary>
 	/// GI_UserDept  用户科室对照
	/// </summary>
    public class GI_USERDEPT
    {

        /// <summary>
 	    /// (索引)(主键)用户序号
	    /// </summary>
		public string USERID{ get; set; }

        /// <summary>
 	    /// (索引)(主键)科室序号
	    /// </summary>
		public string DEPTID{ get; set; }

        /// <summary>
 	    /// 科室类型1科室2病区
	    /// </summary>
		public decimal? TYPECODE{ get; set; }

        /// <summary>
 	    /// 显示排序
	    /// </summary>
		public decimal? DISPLAYSORT{ get; set; }
      
    }
}