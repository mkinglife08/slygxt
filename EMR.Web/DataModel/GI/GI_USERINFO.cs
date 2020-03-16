using System;

namespace DataModel.GI
{
    /// <summary>
 	/// GI_USERINFO  系统用户人员
	/// </summary>
    public class GI_USERINFO
    {

        /// <summary>
 	    /// (索引)(主键)用户人员序号
	    /// </summary>
		public string USERID{ get; set; }

        /// <summary>
 	    /// 组织机构代码
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// (索引)用户人员编号
	    /// </summary>
		public string USERCODE{ get; set; }

        /// <summary>
 	    /// 用户人员名称
	    /// </summary>
		public string USERNAME{ get; set; }

        /// <summary>
 	    /// 用户人员照片
	    /// </summary>
		public string USERPHOTO{ get; set; }

        /// <summary>
 	    /// 用户登录密码
	    /// </summary>
		public string PASSWORD{ get; set; }

        /// <summary>
 	    /// 用户人员职称
	    /// </summary>
		public string USERPOSITION{ get; set; }

        /// <summary>
 	    /// 用户人员性别1男2女3保密
	    /// </summary>
		public decimal? USERSEX{ get; set; }

        /// <summary>
 	    /// 用户出生日期
	    /// </summary>
		public DateTime? USERBIRTHDAY{ get; set; }

        /// <summary>
 	    /// 用户人员电话
	    /// </summary>
		public string USERTEL{ get; set; }

        /// <summary>
 	    /// 用户说明信息
	    /// </summary>
		public string USERNOTE{ get; set; }

        /// <summary>
 	    /// 超级用户判别0不是1是
	    /// </summary>
		public decimal? ISSUPER{ get; set; }

        /// <summary>
 	    /// 用户登录时间
	    /// </summary>
		public DateTime? LOGINTIME{ get; set; }

        /// <summary>
 	    /// 用户是否在线0不在线1在线
	    /// </summary>
		public decimal? ISONLINE{ get; set; }

        /// <summary>
 	    /// 是否作废判别0正常1作废
	    /// </summary>
		public decimal? ISCANCE{ get; set; }

        /// <summary>
 	    /// 拼音码
	    /// </summary>
		public string SPELLCODE{ get; set; }

        /// <summary>
 	    /// 自定义码
	    /// </summary>
		public string CUSTOMCODE{ get; set; }

        /// <summary>
 	    /// 修改用户代码
	    /// </summary>
		public string MODIFYUSERID{ get; set; }

        /// <summary>
 	    /// 修改操作时间
	    /// </summary>
		public DateTime? MODIFYTIME{ get; set; }

        /// <summary>
 	    /// HIS编号
	    /// </summary>
		public string HISCODE{ get; set; }

        /// <summary>
 	    /// 用户科室
	    /// </summary>
		public string DPETID{ get; set; }

        /// <summary>
 	    /// 用户病区
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 用户医疗组
	    /// </summary>
		public string MEDICALID{ get; set; }

        /// <summary>
 	    /// 电子签名
	    /// </summary>
		public string ESIGN{ get; set; }

        /// <summary>
 	    /// 用户职务
	    /// </summary>
		public string JOB{ get; set; }

        /// <summary>
 	    /// 职务级别
	    /// </summary>
		public string JOBLEVEL{ get; set; }

        /// <summary>
 	    /// 审核状态0未审核1通过
	    /// </summary>
		public decimal? CHECKSTATE{ get; set; }

        /// <summary>
 	    /// 用户类型0医生1护士2其他
	    /// </summary>
		public decimal? USERTYPE{ get; set; }

        /// <summary>
 	    /// 上级医师
	    /// </summary>
		public string SUPERIORUSER{ get; set; }
      
    }
}