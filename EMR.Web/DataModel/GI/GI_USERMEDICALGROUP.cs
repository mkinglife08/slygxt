namespace DataModel.GI
{
    /// <summary>
 	/// GI_UserMedicalGroup  用户医疗组对照
	/// </summary>
    public class GI_USERMEDICALGROUP
    {

        /// <summary>
 	    /// (索引)(主键)用户序号
	    /// </summary>
		public string USERID{ get; set; }

        /// <summary>
 	    /// (索引)(主键)医疗组序号
	    /// </summary>
		public string FUNID{ get; set; }

        /// <summary>
 	    /// 显示排序
	    /// </summary>
		public decimal? DISPLAYSORT{ get; set; }
      
    }
}