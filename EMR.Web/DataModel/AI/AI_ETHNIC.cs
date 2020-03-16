namespace DataModel.AI
{
    /// <summary>
 	/// AI_Area  籍贯
	/// </summary>
    public class AI_ETHNIC
    {

        /// <summary>
 	    /// (索引)(主键)籍贯Id
	    /// </summary>
		public decimal? ID{ get; set; }

        /// <summary>
 	    /// 籍贯
	    /// </summary>
		public string NAME{ get; set; }

        /// <summary>
 	    /// 邮政编码
	    /// </summary>
		public string POSTCODE{ get; set; }

        /// <summary>
 	    /// 拼音码
	    /// </summary>
		public string SPELLCODE{ get; set; }

        /// <summary>
 	    /// 自定义码
	    /// </summary>
		public string CUSTOMCODE{ get; set; }
      
    }
}