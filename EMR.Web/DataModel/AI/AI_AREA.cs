namespace DataModel.AI
{
    /// <summary>
 	/// AI_DeptInfo 科室病区 
	/// </summary>
    public class AI_AREA
    {

        /// <summary>
 	    /// (索引)(主键)地区编号
	    /// </summary>
		public decimal? ID{ get; set; }

        /// <summary>
 	    /// 省
	    /// </summary>
		public string PROVINCE{ get; set; }

        /// <summary>
 	    /// 市
	    /// </summary>
		public string CITY{ get; set; }

        /// <summary>
 	    /// 县
	    /// </summary>
		public string AREA{ get; set; }
      
    }
}