using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_FormEmrTemplate 表单病历模板
	/// </summary>
    public class CD_FORMEMRTEMPLATE
    {

        /// <summary>
 	    /// (索引)(主键)模板id
	    /// </summary>
		public string TEMPLATEID{ get; set; }

        /// <summary>
 	    /// 父类模板id
	    /// </summary>
		public string PARENTID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 模板名称
	    /// </summary>
		public string TEMPLATENAME{ get; set; }

        /// <summary>
 	    /// 模板内容
	    /// </summary>
		public string TEMPLATECONTENT{ get; set; }

        /// <summary>
 	    /// 模板类型10知情同意书，11营养评估，12康复评估，13手术风险评估表，14手术安全核查表，15心血管介入治疗术安全核查表
	    /// </summary>
		public decimal? TEMPLATETYPE{ get; set; }

        /// <summary>
 	    /// 拼音输入码
	    /// </summary>
		public string PHONETICCODE{ get; set; }

        /// <summary>
 	    /// 医院名称
	    /// </summary>
		public string HOSPITALNAME{ get; set; }

        /// <summary>
 	    /// 应用科室
	    /// </summary>
		public string APPLICATIONDEPARTMENT{ get; set; }

        /// <summary>
 	    /// 是否作废判别
	    /// </summary>
		public decimal? DEL{ get; set; }

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