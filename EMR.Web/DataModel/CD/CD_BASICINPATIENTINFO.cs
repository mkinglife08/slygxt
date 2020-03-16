using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_BasicInpatientInfo 病人基本信息表
	/// </summary>
    public class CD_BASICINPATIENTINFO
    {

        /// <summary>
 	    /// (索引)(主键)健康卡号
	    /// </summary>
		public string HEALTHCARD{ get; set; }

        /// <summary>
 	    /// 医院id
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 身份证号码
	    /// </summary>
		public string IDCARD{ get; set; }

        /// <summary>
 	    /// 姓名
	    /// </summary>
		public string NAME{ get; set; }

        /// <summary>
 	    /// 性别代码 字典340
	    /// </summary>
		public string GENDERCODE{ get; set; }

        /// <summary>
 	    /// 性别
	    /// </summary>
		public string GENDER{ get; set; }

        /// <summary>
 	    /// 出生日期
	    /// </summary>
		public DateTime? BIRTHDATE{ get; set; }

        /// <summary>
 	    /// 民族代码  字典
	    /// </summary>
		public string ETHNICCODE{ get; set; }

        /// <summary>
 	    /// 民族
	    /// </summary>
		public string ETHNIC{ get; set; }

        /// <summary>
 	    /// 籍贯编码  字典
	    /// </summary>
		public string NATIVECODE{ get; set; }

        /// <summary>
 	    /// 籍贯
	    /// </summary>
		public string NATIVEPLACE{ get; set; }

        /// <summary>
 	    /// 出生地编码 
	    /// </summary>
		public string BIRTHPLACECODE{ get; set; }

        /// <summary>
 	    /// 出生地
	    /// </summary>
		public string BIRTHPLACE{ get; set; }

        /// <summary>
 	    /// 婚姻状态代码  字典323
	    /// </summary>
		public string MARITALCODE{ get; set; }

        /// <summary>
 	    /// 婚姻状态
	    /// </summary>
		public string MARITAL{ get; set; }

        /// <summary>
 	    /// 现住址编码
	    /// </summary>
		public string ADDRESSCODE{ get; set; }

        /// <summary>
 	    /// 现地址-补充信息
	    /// </summary>
		public string ADDRESSOTHER{ get; set; }

        /// <summary>
 	    /// 现地址-详细地址
	    /// </summary>
		public string ADDRESSDETAIL{ get; set; }

        /// <summary>
 	    /// 现地址-邮编
	    /// </summary>
		public string ADDRESSPOSTCODE{ get; set; }

        /// <summary>
 	    /// 联系电话
	    /// </summary>
		public string PHONE{ get; set; }

        /// <summary>
 	    /// 联系人
	    /// </summary>
		public string CONTACTNAME{ get; set; }

        /// <summary>
 	    /// 联系人电话
	    /// </summary>
		public string CONTACTPHONE{ get; set; }

        /// <summary>
 	    /// 联系人电话1
	    /// </summary>
		public string CONTACTPHONE1{ get; set; }

        /// <summary>
 	    /// 联系人关系
	    /// </summary>
		public string CONTACTRELATION{ get; set; }

        /// <summary>
 	    /// 关系编码
	    /// </summary>
		public string CONTACTRELATIONCODE{ get; set; }

        /// <summary>
 	    /// 联系人地址
	    /// </summary>
		public string CONTACTPLACE{ get; set; }

        /// <summary>
 	    /// 国籍
	    /// </summary>
		public string NATIONALITY{ get; set; }

        /// <summary>
 	    /// 国籍编码
	    /// </summary>
		public string NATIONALITYCODE{ get; set; }

        /// <summary>
 	    /// 户口地址编码
	    /// </summary>
		public string HOUSEHOLDCODE{ get; set; }

        /// <summary>
 	    /// 户口地址-补充信息
	    /// </summary>
		public string HOUSEHOLDOTHER{ get; set; }

        /// <summary>
 	    /// 户口地址-详细信息
	    /// </summary>
		public string HOUSEHOLDDETAILED{ get; set; }

        /// <summary>
 	    /// 户口地址-邮编
	    /// </summary>
		public string HOUSEHOLDPOSTCODE{ get; set; }

        /// <summary>
 	    /// 工作单位
	    /// </summary>
		public string COMPANY{ get; set; }

        /// <summary>
 	    /// 单位电话
	    /// </summary>
		public string COMPANYPHONE{ get; set; }

        /// <summary>
 	    /// 单位邮编
	    /// </summary>
		public string COMPANYPOSTCODE{ get; set; }

        /// <summary>
 	    /// 单位地址
	    /// </summary>
		public string COMPANYADDRESS{ get; set; }

        /// <summary>
 	    /// 文化程度
	    /// </summary>
		public string EDUCATION{ get; set; }

        /// <summary>
 	    /// 文化程度编码
	    /// </summary>
		public string EDUCATIONCODE{ get; set; }

        /// <summary>
 	    /// 职业
	    /// </summary>
		public string JOB{ get; set; }

        /// <summary>
 	    /// 职业编码 字典268
	    /// </summary>
		public string JOBCODE{ get; set; }

        /// <summary>
 	    /// 宗教信仰
	    /// </summary>
		public string RELIGION{ get; set; }

        /// <summary>
 	    /// 宗教信仰编码
	    /// </summary>
		public string RELIGIONCODE{ get; set; }

        /// <summary>
 	    /// 作废标志
	    /// </summary>
		public decimal? DEL{ get; set; }

        /// <summary>
 	    /// 创建时间
	    /// </summary>
		public DateTime? CREATETIME{ get; set; }

        /// <summary>
 	    /// 创建人
	    /// </summary>
		public string CREATOR{ get; set; }

        /// <summary>
 	    /// 更新时间
	    /// </summary>
		public DateTime? UPDATETIME{ get; set; }

        /// <summary>
 	    /// 更新人
	    /// </summary>
		public string UPDATER{ get; set; }

        /// <summary>
 	    /// 联系人2
	    /// </summary>
		public string CONTACTNAME2{ get; set; }

        /// <summary>
 	    /// 联系人2电话
	    /// </summary>
		public string CONTACTPHONE2{ get; set; }

        /// <summary>
 	    /// 联系人2关系
	    /// </summary>
		public string CONTACTRELATION2{ get; set; }

        /// <summary>
 	    /// 关系编码2
	    /// </summary>
		public string CONTACTRELATIONCODE2{ get; set; }

        /// <summary>
 	    /// 联系人2地址
	    /// </summary>
		public string CONTACTPLACE2{ get; set; }

        /// <summary>
 	    /// 家庭电话
	    /// </summary>
		public string HOMEPHONE{ get; set; }

        /// <summary>
 	    /// 家庭邮编
	    /// </summary>
		public string HOMEPOSTCODE{ get; set; }
      
    }
}