namespace DataModel.GI
{
    /// <summary>
 	/// GI_SERIALINFO  系统主键编号
	/// </summary>
    public class GI_SERIALINFO
    {

        /// <summary>
 	    /// (索引)(主键)主键编号序号
	    /// </summary>
		public string KEYID{ get; set; }

        /// <summary>
 	    /// 组织机构代码
	    /// </summary>
		public string ORGINID{ get; set; }

        /// <summary>
 	    /// 主键编号表名
	    /// </summary>
		public string NAME{ get; set; }

        /// <summary>
 	    /// 主键编号列名
	    /// </summary>
		public string COLUMNNAME{ get; set; }

        /// <summary>
 	    /// 当前数据序号
	    /// </summary>
		public string CURRENTID{ get; set; }
      
    }
}