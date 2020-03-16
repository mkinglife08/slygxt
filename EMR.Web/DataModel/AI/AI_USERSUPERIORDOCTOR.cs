namespace DataModel.AI
{
    /// <summary>
 	/// AI_UserSuperiorDoctor  用户上级医师对照
	/// </summary>
    public class AI_USERSUPERIORDOCTOR
    {

        /// <summary>
 	    /// (索引)(主键)用户序号
	    /// </summary>
		public string USERID{ get; set; }

        /// <summary>
 	    /// 上级医师序号
	    /// </summary>
		public string SUPERIORUSERID{ get; set; }

        /// <summary>
 	    /// 显示排序
	    /// </summary>
		public decimal? DISPLAYSORT{ get; set; }
      
    }
}