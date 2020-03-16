using System;

namespace DataModel.CD
{
    /// <summary>
 	/// CD_MedicalRecordHomePage病案首页
	/// </summary>
    public class CD_MEDICALRECORDHOMEPAGE
    {

        /// <summary>
 	    /// (索引)(主键)病案首页id
	    /// </summary>
		public string HOMEPAGEID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 健康卡号
	    /// </summary>
		public string HEALTHCARD{ get; set; }

        /// <summary>
 	    /// 医疗付费方式 CV07.10.005
	    /// </summary>
		public string PAYMENTMETHOD{ get; set; }

        /// <summary>
 	    /// 入院途径  CV09.00.403
	    /// </summary>
		public string ADMISSIONWAY{ get; set; }

        /// <summary>
 	    /// 门诊诊断编码
	    /// </summary>
		public string CLINICDIAGNOSISCODE{ get; set; }

        /// <summary>
 	    /// 门诊诊断
	    /// </summary>
		public string CLINICDIAGNOSIS{ get; set; }

        /// <summary>
 	    /// 损伤、中毒的外部因素编码
	    /// </summary>
		public string EXTERNALITYCODE{ get; set; }

        /// <summary>
 	    /// 损伤、中毒的外部因素
	    /// </summary>
		public string EXTERNALITYDESC{ get; set; }

        /// <summary>
 	    /// 药物过敏1：无  2：有
	    /// </summary>
		public string DRUGALLERGY{ get; set; }

        /// <summary>
 	    /// 药物过敏内容
	    /// </summary>
		public string DRUGALLERGYDESC{ get; set; }

        /// <summary>
 	    /// 病理诊断编码
	    /// </summary>
		public string PATHOLOGICDIAGNOSISCODE{ get; set; }

        /// <summary>
 	    /// 病理诊断
	    /// </summary>
		public string PATHOLOGICDIAGNOSIS{ get; set; }

        /// <summary>
 	    /// 病理号
	    /// </summary>
		public string PATHOLOGYNO{ get; set; }

        /// <summary>
 	    /// 科主任代码
	    /// </summary>
		public string DEPTDIRECTORUSERID{ get; set; }

        /// <summary>
 	    /// 科主任姓名
	    /// </summary>
		public string DEPTDIRECTORNAME{ get; set; }

        /// <summary>
 	    /// 主任(副主任)医师代码
	    /// </summary>
		public string DIRECTORUSERID{ get; set; }

        /// <summary>
 	    /// 主任(副主任)医师姓名
	    /// </summary>
		public string DIRECTORNAME{ get; set; }

        /// <summary>
 	    /// 主治医师代码
	    /// </summary>
		public string VISITINGSTAFFID{ get; set; }

        /// <summary>
 	    /// 主治医师姓名
	    /// </summary>
		public string VISITINGNAME{ get; set; }

        /// <summary>
 	    /// 住院医师代码
	    /// </summary>
		public string RESIDENTDOCTORID{ get; set; }

        /// <summary>
 	    /// 住院医师姓名
	    /// </summary>
		public string RESIDENTNAME{ get; set; }

        /// <summary>
 	    /// 责任护士代码
	    /// </summary>
		public string RESPONSIBLENURSEID{ get; set; }

        /// <summary>
 	    /// 责任护士姓名
	    /// </summary>
		public string RESPONSIBLENURSENAME{ get; set; }

        /// <summary>
 	    /// 进修医师代码
	    /// </summary>
		public string REFRESHERDOCTORID{ get; set; }

        /// <summary>
 	    /// 进修医师姓名
	    /// </summary>
		public string REFRESHERDOCTORNAME{ get; set; }

        /// <summary>
 	    /// 实习医师代码
	    /// </summary>
		public string INTERNDOCTORID{ get; set; }

        /// <summary>
 	    /// 实习医师姓名
	    /// </summary>
		public string INTERNDOCTORNAME{ get; set; }

        /// <summary>
 	    /// 编码员代码
	    /// </summary>
		public string CODERUSERID{ get; set; }

        /// <summary>
 	    /// 编码员姓名
	    /// </summary>
		public string CODERUSERNAME{ get; set; }

        /// <summary>
 	    /// 病案质量1：甲  2：乙  3：丙
	    /// </summary>
		public string MEDICALRECORDMASS{ get; set; }

        /// <summary>
 	    /// 质控医师代码
	    /// </summary>
		public string QCDOCTORID{ get; set; }

        /// <summary>
 	    /// 质控医师姓名
	    /// </summary>
		public string QCDOCTORNAME{ get; set; }

        /// <summary>
 	    /// 质控护士代码
	    /// </summary>
		public string QCNURSEID{ get; set; }

        /// <summary>
 	    /// 质控护士姓名
	    /// </summary>
		public string QCNURSENAME{ get; set; }

        /// <summary>
 	    /// 质控日期
	    /// </summary>
		public DateTime? QCTIME{ get; set; }

        /// <summary>
 	    /// 住院费用总计
	    /// </summary>
		public string FEETOTAL{ get; set; }

        /// <summary>
 	    /// 自付金额
	    /// </summary>
		public string FEEOWN{ get; set; }

        /// <summary>
 	    /// 一般医疗服务费
	    /// </summary>
		public string MEDICALSERVICESFEE{ get; set; }

        /// <summary>
 	    /// 一般治疗操作费
	    /// </summary>
		public string TREATMENTOPERATEFEE{ get; set; }

        /// <summary>
 	    /// 护理费
	    /// </summary>
		public string NURSINGFEE{ get; set; }

        /// <summary>
 	    /// 其他费用
	    /// </summary>
		public string OTHERSERVICEFEE{ get; set; }

        /// <summary>
 	    /// 病理诊断费
	    /// </summary>
		public string DIAGNOSISFEE{ get; set; }

        /// <summary>
 	    /// 影像学诊断费
	    /// </summary>
		public string IMAGINGDIAGNOSISDEE{ get; set; }

        /// <summary>
 	    /// 实验室诊断费
	    /// </summary>
		public string LABORATORYDIAGNOSISFEE{ get; set; }

        /// <summary>
 	    /// 临床诊断费
	    /// </summary>
		public string CLINICALDIAGNOSISFEE{ get; set; }

        /// <summary>
 	    /// 非手术治疗项目费
	    /// </summary>
		public string NONOPERATIONPROJECTFEE{ get; set; }

        /// <summary>
 	    /// 临床物理治疗费
	    /// </summary>
		public string CLINICALPHYSICALTREATMENTFEE{ get; set; }

        /// <summary>
 	    /// 手术治疗费
	    /// </summary>
		public string OPERATIONTREATMENTFEE{ get; set; }

        /// <summary>
 	    /// 麻醉费
	    /// </summary>
		public string ANESTHETICFEE{ get; set; }

        /// <summary>
 	    /// 手术费
	    /// </summary>
		public string OPERATIONFEE{ get; set; }

        /// <summary>
 	    /// 康复费
	    /// </summary>
		public string REHABILITATIONFEE{ get; set; }

        /// <summary>
 	    /// 中医治疗费
	    /// </summary>
		public string CHINESEMEDICINETREATMENTFEE{ get; set; }

        /// <summary>
 	    /// 西药费
	    /// </summary>
		public string WESTERNMEDICINEFEE{ get; set; }

        /// <summary>
 	    /// 抗菌药物费用
	    /// </summary>
		public string ANTIMICROBIALCOSTSFEE{ get; set; }

        /// <summary>
 	    /// 中成药费
	    /// </summary>
		public string PATENTMEDICINEFEE{ get; set; }

        /// <summary>
 	    /// 中草药费
	    /// </summary>
		public string HERBALMEDICINEFEE{ get; set; }

        /// <summary>
 	    /// 血费
	    /// </summary>
		public string NLOODFEE{ get; set; }

        /// <summary>
 	    /// 白蛋白制品费
	    /// </summary>
		public string ALBUMINPRODUCTSFEE{ get; set; }

        /// <summary>
 	    /// 球蛋白制品费
	    /// </summary>
		public string IMMUNOGLOBULINFEE{ get; set; }

        /// <summary>
 	    /// 凝血因子制品费
	    /// </summary>
		public string CLOTTINGFACTORFEE{ get; set; }

        /// <summary>
 	    /// 细胞因子制品费
	    /// </summary>
		public string CYTOKINEFEE{ get; set; }

        /// <summary>
 	    /// 检查用一次性医用材料费
	    /// </summary>
		public string INSPECTIONMATERIALFEE{ get; set; }

        /// <summary>
 	    /// 治疗用一次性医用材料费
	    /// </summary>
		public string TREATMENTMATERIALFEE{ get; set; }

        /// <summary>
 	    /// 手术用一次性医用材料费
	    /// </summary>
		public string OPERATIONMATERIALFEE{ get; set; }

        /// <summary>
 	    /// 其他费
	    /// </summary>
		public string OTHERFEE{ get; set; }

        /// <summary>
 	    /// 尸检1：是 2：否
	    /// </summary>
		public string AUTOPSY{ get; set; }

        /// <summary>
 	    /// 离院方式 CV06.00.226
	    /// </summary>
		public string LEAVEHOSPITALWAY{ get; set; }

        /// <summary>
 	    /// 转院机构
	    /// </summary>
		public string TOHOSPITAL{ get; set; }

        /// <summary>
 	    /// 血型1：A  2：B  3：AB  4：O  5：未测
	    /// </summary>
		public string BLOODTYPE{ get; set; }

        /// <summary>
 	    /// Rh1 CV04.50.020
	    /// </summary>
		public string RH{ get; set; }

        /// <summary>
 	    /// 是否有出院31天内再住院计划1：无  2：有
	    /// </summary>
		public string READMPLAN{ get; set; }

        /// <summary>
 	    /// 目的
	    /// </summary>
		public string READMPLANCAUSE{ get; set; }

        /// <summary>
 	    /// 颅脑损伤患者昏迷时间：入院前
	    /// </summary>
		public string COMATIMEBEFORE{ get; set; }

        /// <summary>
 	    /// 颅脑损伤患者昏迷时间：入院后
	    /// </summary>
		public string COMATIMEAFTER{ get; set; }

        /// <summary>
 	    /// 记录医师代码
	    /// </summary>
		public string RECORDUSERID{ get; set; }

        /// <summary>
 	    /// 单病种管理1：无 2：有
	    /// </summary>
		public string SINGLEDISEASEMANAGE{ get; set; }

        /// <summary>
 	    /// 门诊与住院
	    /// </summary>
		public string CLINICINHOSPITAL{ get; set; }

        /// <summary>
 	    /// 入院与出院
	    /// </summary>
		public string ADMISSIONDISCHARGED{ get; set; }

        /// <summary>
 	    /// 术前与术后
	    /// </summary>
		public string OPERATIONBEFOREAFTER{ get; set; }

        /// <summary>
 	    /// 临床与病理
	    /// </summary>
		public string CLINICPATHOLOGY{ get; set; }

        /// <summary>
 	    /// 放射与病理
	    /// </summary>
		public string IRRADIATIONPATHOLOGY{ get; set; }

        /// <summary>
 	    /// 抢救情况1：无 2：有
	    /// </summary>
		public string RESCUECASE{ get; set; }

        /// <summary>
 	    /// 抢救次数
	    /// </summary>
		public string RESCUENUM{ get; set; }

        /// <summary>
 	    /// 抢救成功次数
	    /// </summary>
		public string RESCUESUCCEEDNUM{ get; set; }

        /// <summary>
 	    /// 是否为自动出院1：是 2：否
	    /// </summary>
		public string AGAINSTADVISEDISCHARGE{ get; set; }

        /// <summary>
 	    /// 转归情况1：治愈 2：好转 3：未愈 4：死亡 5：其他
	    /// </summary>
		public string PROGNOSISOFDISEASE{ get; set; }

        /// <summary>
 	    /// 手术并发症1：无 2：有
	    /// </summary>
		public string OPERATIVECOMPLICATIONS{ get; set; }

        /// <summary>
 	    /// 手术并发症_有1：肺栓塞2：深静脉血栓3：败血症4：出血或血肿5：伤口裂开6：猝死7：呼吸衰竭8：骨折9：生理/代谢紊乱10：肺部感染11：人工气道意外脱出12：切口感染13：其他
	    /// </summary>
		public string OPERATIVECOMPLICATIONSDESC{ get; set; }

        /// <summary>
 	    /// 手术并发症_有_其他
	    /// </summary>
		public string OPERATIVECOMPLICATIONSOTHER{ get; set; }

        /// <summary>
 	    /// 输血及血制品1：无 2：有
	    /// </summary>
		public string BLOODPRODUCT{ get; set; }

        /// <summary>
 	    /// 输血反应1：无  2：有
	    /// </summary>
		public string TRANSFUSIONREACTION{ get; set; }

        /// <summary>
 	    /// 住院期间是否告病危或危重1：是 2：否
	    /// </summary>
		public string LMMINENCEGRAVE{ get; set; }

        /// <summary>
 	    /// 修改历史
	    /// </summary>
		public decimal? CHANGEHISTORY{ get; set; }

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
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 非预期重返手术 0：否 1：是 
	    /// </summary>
		public string UNEXPECTEDSURGERY{ get; set; }

        /// <summary>
 	    /// 入院后确诊日期
	    /// </summary>
		public DateTime? DIAGNOSISDATE{ get; set; }

        /// <summary>
 	    /// 手术相关院内感染
	    /// </summary>
		public string SURGICALINFECTIONS{ get; set; }

        /// <summary>
 	    /// 医院感染情况 0：无  1：有
	    /// </summary>
		public string INFECTIONSITUATION{ get; set; }

        /// <summary>
 	    /// 临床路经管理 1：完成 2：变异 3：退出 4：未入
	    /// </summary>
		public string CLINICALPATHWAY{ get; set; }

        /// <summary>
 	    /// 急症 0：否 1：是 
	    /// </summary>
		public string EMERGENCYCASE{ get; set; }

        /// <summary>
 	    /// 疑难情况 0：否 1：是 
	    /// </summary>
		public string DIFFICULTSITUATION{ get; set; }

        /// <summary>
 	    /// 病例分型0.无1.单纯普通病历2.单纯急症病例3.复杂疑难病例4.复杂危重病例 
	    /// </summary>
		public string CASECLASSIFICATION{ get; set; }

        /// <summary>
 	    /// 医院感染情况详情
	    /// </summary>
		public string INFECTIONSITUATIONINFO{ get; set; }

        /// <summary>
 	    /// 保存方式0：暂存1：保存
	    /// </summary>
		public decimal? RECORDSTATE{ get; set; }
      
    }
}