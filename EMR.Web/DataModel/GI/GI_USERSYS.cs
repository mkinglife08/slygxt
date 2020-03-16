namespace DataModel.GI
{
    /// <summary>
 	/// GI_USERSYS  系统用户系统对照
	/// </summary>
    public class GI_USERSYS
    {

        /// <summary>
 	    /// 用户人员代码
	    /// </summary>
		public string USERID{ get; set; }

        /// <summary>
 	    /// 系统模块代码
	    /// </summary>
		public string SYSID{ get; set; }

        /// <summary>
 	    /// 
	    /// </summary>
		public decimal? ISDEFAULT{ get; set; }
      
    }
}