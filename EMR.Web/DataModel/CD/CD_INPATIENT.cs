using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_Inpatient    住院病人
	/// </summary>
    public class CD_INPATIENT
    {

        /// <summary>
 	    /// (索引)(主键)住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 健康卡号
	    /// </summary>
		public string HEALTHCARD{ get; set; }

        /// <summary>
 	    /// 医院id
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// HIS住院id
	    /// </summary>
		public string HISINPATIENTID{ get; set; }

        /// <summary>
 	    /// HIS住院次数
	    /// </summary>
		public decimal? HISINPATIENTCOUNT{ get; set; }

        /// <summary>
 	    /// 入院病区
	    /// </summary>
		public string ADMISSIONWARD{ get; set; }

        /// <summary>
 	    /// 当前科室ID
	    /// </summary>
		public string CURRENTDEPTID{ get; set; }

        /// <summary>
 	    /// 当前病区ID
	    /// </summary>
		public string CURRENTWARDID{ get; set; }

        /// <summary>
 	    /// 床号
	    /// </summary>
		public string BEDNUMBER{ get; set; }

        /// <summary>
 	    /// 门诊就诊卡号
	    /// </summary>
		public string OUTPATIENTCARD{ get; set; }

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
 	    /// 就诊年龄(岁)
	    /// </summary>
		public string AGE{ get; set; }

        /// <summary>
 	    /// 新生儿年龄(月)
	    /// </summary>
		public string NBAGEMONTH{ get; set; }

        /// <summary>
 	    /// 新生儿年龄(天)
	    /// </summary>
		public string NBAGEDAY{ get; set; }

        /// <summary>
 	    /// 新生儿出生体重
	    /// </summary>
		public string NBAGEWEIGHT{ get; set; }

        /// <summary>
 	    /// 新生儿入院体重
	    /// </summary>
		public string NBHOSPITALWEIGHT{ get; set; }

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
 	    /// 入院途径代码 CV09.00.403
	    /// </summary>
		public string INPATIENTCODE{ get; set; }

        /// <summary>
 	    /// 住院次数
	    /// </summary>
		public decimal? ADMISSTTIMES{ get; set; }

        /// <summary>
 	    /// 入院途径
	    /// </summary>
		public string INPATIENTWAY{ get; set; }

        /// <summary>
 	    /// 入院时间（患者首次入科时间）
	    /// </summary>
		public DateTime? ENTRYTIME{ get; set; }

        /// <summary>
 	    /// 临床路径管理0未进路径1进入2变异3终止
	    /// </summary>
		public string CPMANAGE{ get; set; }

        /// <summary>
 	    /// 出院时间（即预出院时间）
	    /// </summary>
		public DateTime? LEAVETIME{ get; set; }

        /// <summary>
 	    /// 宗教信仰
	    /// </summary>
		public string RELIGION{ get; set; }

        /// <summary>
 	    /// 宗教信仰编码
	    /// </summary>
		public string RELIGIONCODE{ get; set; }

        /// <summary>
 	    /// 病历状态0未归档1归档
	    /// </summary>
		public string MEDICALRECORDSTATE{ get; set; }

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
 	    /// 付费类型
	    /// </summary>
		public string PAYMENTTYPE{ get; set; }

        /// <summary>
 	    /// 病历类型
	    /// </summary>
		public string RECORDTYPE{ get; set; }

        /// <summary>
 	    /// 出院病区
	    /// </summary>
		public string LEAVEWARD{ get; set; }

        /// <summary>
 	    /// 入院病房
	    /// </summary>
		public string ADMISSIONBEDWARD{ get; set; }

        /// <summary>
 	    /// 出院病房
	    /// </summary>
		public string LEAVEBEDWARD{ get; set; }

        /// <summary>
 	    /// 出院科室
	    /// </summary>
		public string LEAVEDEPT{ get; set; }

        /// <summary>
 	    /// 转科情况
	    /// </summary>
		public string CONVERSIONDEPT{ get; set; }

        /// <summary>
 	    /// 影像号
	    /// </summary>
		public string IMAGENUMBER{ get; set; }

        /// <summary>
 	    /// 转科次数
	    /// </summary>
		public string CONVERSIONDEPTNUM{ get; set; }

        /// <summary>
 	    /// 主诊医师代码
	    /// </summary>
		public string ATTENDINGDOCTORID{ get; set; }

        /// <summary>
 	    /// 主诊医师姓名
	    /// </summary>
		public string ATTENDINGNAME{ get; set; }

        /// <summary>
 	    /// 接待医师代码
	    /// </summary>
		public string RECEPTIONDOCTORID{ get; set; }

        /// <summary>
 	    /// 接待医师姓名
	    /// </summary>
		public string RECEPTIONDOCTORNAME{ get; set; }

        /// <summary>
 	    /// 主管护士代码
	    /// </summary>
		public string CHARGENURSEID{ get; set; }

        /// <summary>
 	    /// 主管护士姓名
	    /// </summary>
		public string CHARGENURSENAME{ get; set; }

        /// <summary>
 	    /// 住院证开单人代码
	    /// </summary>
		public string ISSUERID{ get; set; }

        /// <summary>
 	    /// 住院证开单人姓名
	    /// </summary>
		public string ISSUERNAME{ get; set; }

        /// <summary>
 	    /// 父母姓名(新生儿填写)
	    /// </summary>
		public string PARENTSNAME{ get; set; }

        /// <summary>
 	    /// 胎龄(新生儿填写)
	    /// </summary>
		public string GESTATIONALAGE{ get; set; }
      
    }
}