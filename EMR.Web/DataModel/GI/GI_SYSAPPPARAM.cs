namespace DataModel.GI
{
    /// <summary>
 	/// GI_SYSAPPPARAM 系统业务参数信息
	/// </summary>
    public class GI_SYSAPPPARAM
    {

        /// <summary>
 	    /// (索引)(主键)
	    /// </summary>
		public string PARAMID{ get; set; }

        /// <summary>
 	    /// 组织机构代码ZZJGDM
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 参数英文名称CSYWMC
	    /// </summary>
		public string PARAMNAMEENG{ get; set; }

        /// <summary>
 	    /// 系统模块代码XTMKID
	    /// </summary>
		public string MODULEID{ get; set; }

        /// <summary>
 	    /// 参数中文名称CSZWMC
	    /// </summary>
		public string PARAMNAMECHS{ get; set; }

        /// <summary>
 	    /// 系统参数内容XTCSNR
	    /// </summary>
		public string PARAMCONTENT{ get; set; }

        /// <summary>
 	    /// 参数备注说明CSBZSM
	    /// </summary>
		public string PARAMREMARK{ get; set; }

        /// <summary>
 	    /// 参数存取类别CSCQLB
	    /// </summary>
		public decimal? PARAMTYPE{ get; set; }

        /// <summary>
 	    /// 汉字输入码一HZSRM1
	    /// </summary>
		public string CHSCODE1{ get; set; }

        /// <summary>
 	    /// 汉字输入码二HZSRM2
	    /// </summary>
		public string CHSCODE2{ get; set; }

        /// <summary>
 	    /// 汉字输入码三HZSRM3
	    /// </summary>
		public string CHSCODE3{ get; set; }
      
    }
}