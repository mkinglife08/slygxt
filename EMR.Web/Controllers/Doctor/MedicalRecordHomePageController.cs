using EMR.Data;
using EMR.Data.Models;
using EMR.Services;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Doctor
{
    public class MedicalRecordHomePageController : BaseController
    {
        private InpatientService inpatientService = new InpatientService();//病人信息服务
        private MedicalRecordHomePageService medicalRecordHomePageServiceService = new MedicalRecordHomePageService();//病案首页服务
        private PatientDiagnosisService patientDiagnosisService = new PatientDiagnosisService();
        private BasicInpatientInfoService basicInpatientInfoService = new BasicInpatientInfoService();
        private MedicalRecordAccessRecordService medicalrecordaccessrecordservice = new MedicalRecordAccessRecordService();//病历审阅服务

        /// <summary>
        /// 保存病案首页数据
        /// </summary>
        /// <returns></returns>
        public string SaveMedicalRecordHomePage()
        {
            return base.ExecuteActionJsonResult("病案首页数据保存", () =>
            {
                //获得住院病人
                CD_Inpatient entityInpatient = base.GetPageData<CD_Inpatient>(0);
                //获得病人基本信息
                CD_BasicInpatientInfo entityBasicInpatientInfo = base.GetPageData<CD_BasicInpatientInfo>(0);
                //获得病案首页
                CD_MedicalRecordHomePage entityMedicalRecordHomePage = base.GetPageData<CD_MedicalRecordHomePage>(0);
                //出生地
                if (entityInpatient.BirthplaceCode != null && entityInpatient.BirthplaceCode.Trim(',').Trim() == "") { entityInpatient.BirthPlace = entityInpatient.BirthplaceCode = entityBasicInpatientInfo.BirthPlace = entityBasicInpatientInfo.BirthplaceCode = ""; }
                //籍贯
                if (entityInpatient.NativeCode != null && entityInpatient.NativeCode.Trim(',').Trim() == "") { entityInpatient.NativePlace = entityInpatient.NativeCode = entityBasicInpatientInfo.NativePlace = entityBasicInpatientInfo.NativeCode = ""; }
                int AdmissionWay = 0;
                //入院途径
                if (int.TryParse(Request["InpatientCode"], out AdmissionWay)) { entityMedicalRecordHomePage.AdmissionWay = AdmissionWay; }
                //门诊诊断
                if (!string.IsNullOrWhiteSpace(entityMedicalRecordHomePage.ClinicDiagnosis) && entityMedicalRecordHomePage.ClinicDiagnosis.Split(',').Length == 2) { entityMedicalRecordHomePage.ClinicDiagnosis = entityMedicalRecordHomePage.ClinicDiagnosis.Split(',')[1]; }
                if (!string.IsNullOrWhiteSpace(entityInpatient.InpatientId))
                {
                    //保存病人
                    inpatientService.SaveInfo(entityInpatient);
                    //保存病人基本信息
                    basicInpatientInfoService.SaveInfo(entityBasicInpatientInfo);
                    //保存病案首页
                    medicalRecordHomePageServiceService.SaveInfo(entityMedicalRecordHomePage);
                }
                return new WebApi_Result();
            });
        }
        /// <summary>
        /// 获取住院病人列表
        /// </summary>
        /// <returns></returns>
        public string GetAllInpatient()
        {
            return base.ExecuteActionJsonResult("获取住院病人列表", () =>
            {
                string Creator = UserTokenManager.GetUId(Request["token"]);//用户ID
                string SYSID = Request["SYSID"];//当前工作站id

                InpatientFilter filter = GetPageData<InpatientFilter>(-2);
                //List<CD_BasicInpatientInfo> list = inpatientService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<CD_Inpatient> list = inpatientService.GetAll(filter);
                list.ForEach((f) =>
                {
                    //病案首页
                    CD_MedicalRecordHomePage homePage = EntityOperate<CD_MedicalRecordHomePage>.GetEntityById(f.InpatientId, "InpatientId");
                    if (homePage != null)
                    {
                        f.HomePageId = homePage.HomePageId;//病案首页id
                        f.VisitingName = homePage.VisitingName;//主治医生
                    }

                    PatientDiagnosisFilter filterDiagnosis = GetPageData<PatientDiagnosisFilter>(0);
                    filterDiagnosis.DiagnosisType = "2";
                    List<CD_PatientDiagnosis> diagList = patientDiagnosisService.GetAll(filterDiagnosis);
                    int diagIndex = 0;
                    diagList.ForEach((e) => { f.Diagnosis += ++diagIndex + "." + e.DiagnosisName + " "; });
                    if (!string.IsNullOrWhiteSpace(f.Diagnosis))
                    {
                        f.Diagnosis = f.Diagnosis.Trim();//入院诊断
                    }

                    #region 判断是否有权限查看病历
                    //1、检查病历是否已归档，2、检查病历审阅表中的状态：搜索不到代表未申请，AccessState=0 代表已申请未通过，AccessState=1 代表以申请已通过
                    if (f.MedicalRecordState == "1")
                    {
                        //检查是否有申请过查看病历
                        CD_MedicalRecordAccessRecord info = medicalrecordaccessrecordservice.GetInfoByInpatientIdAndApplyUserID(f.InpatientId, Creator);
                        if (info != null) { f.AccessState = info.AccessState; }
                    }
                    else
                    {
                        f.AccessState = 1;
                    }
                    //如果是医务科工作站(6)查一下有多少申请审阅的(审阅状态为0)
                    if (SYSID == "6")
                    {
                        List<CD_MedicalRecordAccessRecord> mrarList = medicalrecordaccessrecordservice.GetListByInpatientId(f.InpatientId, 0);
                        f.ApplyAccessNumber = mrarList.Count;
                    }
                    #endregion

                });
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取住院病人信息
        /// </summary>
        /// <returns></returns>
        public string GetInpatientInfoById()
        {
            return base.ExecuteActionJsonResult("获取住院病人信息", () =>
            {
                CD_Inpatient entity = EntityOperate<CD_Inpatient>.GetEntityById(Request["InpatientId"], "InpatientId");
                entity.PaymentTypeName = CommonService.GetDictNameByID("26", entity.PaymentType);
                entity.RecordTypeName = CommonService.GetDictNameByID("849", entity.RecordType);
                entity.CpManageName = CommonService.GetDictNameByID("463", entity.CpManage);
                PatientDiagnosisFilter filterDiagnosis = GetPageData<PatientDiagnosisFilter>(0);
                filterDiagnosis.DiagnosisType = "2";
                List<CD_PatientDiagnosis> diagList = patientDiagnosisService.GetAll(filterDiagnosis);
                if (diagList.Count > 0)
                {
                    int diagIndex = 0;
                    diagList.ForEach((e) => { entity.Diagnosis += ++diagIndex + "." + e.DiagnosisName + " "; });
                    entity.Diagnosis = entity.Diagnosis.Trim();
                }
                return new WebApi_Result() { data = entity };
            });
        }
        /// <summary>
        /// 获取住院病人信息
        /// </summary>
        /// <returns></returns>
        public string GetBasicInpatientInfoById()
        {
            return base.ExecuteActionJsonResult("获取住院病人信息", () =>
            {
                CD_BasicInpatientInfo entity = EntityOperate<CD_BasicInpatientInfo>.GetEntityById(Request["HealthCard"], "HealthCard");
                return new WebApi_Result() { data = entity };
            });
        }
        /// <summary>
        /// 获取病案首页信息
        /// </summary>
        /// <returns></returns>
        public string GetMedicalRecordHomePageInfoById()
        {
            return base.ExecuteActionJsonResult("获取病案首页信息", () =>
            {
                CD_MedicalRecordHomePage entity = EntityOperate<CD_MedicalRecordHomePage>.GetEntityById(Request["InpatientId"], "InpatientId");
                if (entity != null)
                {
                    entity.AdmissionWayName = CommonService.GetDictNameByID("228", entity.AdmissionWay + "");
                    entity.BloodTypeName = CommonService.GetDictNameByID("444", entity.BloodType + "");
                    entity.RHName = CommonService.GetDictNameByID("21", entity.RH + "");
                    entity.LeaveHospitalWayName = CommonService.GetDictNameByID("221", entity.LeaveHospitalWay + "");
                    entity.MedicalRecordMassName = CommonService.GetDictNameByID("773", entity.MedicalRecordMass + "");
                    entity.PrognosisOfDiseaseName = CommonService.GetDictNameByID("777", entity.PrognosisOfDisease + "");
                }
                return new WebApi_Result() { data = entity };
            });
        }


        #region 查阅病案授权

        /// <summary>
        /// 申请查阅已归档的病历
        /// </summary>
        /// <returns></returns>
        public string ApplicationReview()
        {
            return base.ExecuteActionJsonResult("申请查看病历", () =>
            {
                string InpatientId = Request["InpatientId"];//病人ID
                string Creator = UserTokenManager.GetUId(Request["token"]);//用户ID
                //检查是否有申请过查看病历
                CD_MedicalRecordAccessRecord info = medicalrecordaccessrecordservice.GetInfoByInpatientIdAndApplyUserID(InpatientId, Creator);
                if (info == null)
                {
                    CD_MedicalRecordAccessRecord entity = base.GetPageData<CD_MedicalRecordAccessRecord>(-1);
                    medicalrecordaccessrecordservice.save(entity);
                    return new WebApi_Result() { data = entity, msg = "申请提交成功" };
                }
                return new WebApi_Result() { msg = "你已经提交过申请，请不要重复提交！" };
            });
        }

        /// <summary>
        /// 通过病人id获得查阅申请
        /// </summary>
        /// <returns></returns>
        public string GetApplicationReviewList()
        {
            return base.ExecuteActionJsonResult("申请查看病历", () =>
            {
                string InpatientId = Request["InpatientId"];//病人ID
                string keyword = Request["keyword"];//用户姓名

                List<CD_MedicalRecordAccessRecord> list = medicalrecordaccessrecordservice.GetListByInpatientId(InpatientId,0,keyword);
                list.ForEach((f) =>
                {
                    //如果是已被审核过的，则选中
                    if (f.AccessState == 1) { f.LAY_CHECKED = true; }
                });

                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }

        /// <summary>
        /// 审阅审核通过
        /// </summary>
        /// <returns></returns>
        public string SaveApplicationReview()
        {
            return base.ExecuteActionJsonResult("保存审阅申请", () =>
            {
                string InpatientId = Request["InpatientId"];//病人ID
                string user_access_check = Request["user_access_check"];//审阅通过的id
                medicalrecordaccessrecordservice.UpdateAccessState(user_access_check, "1");
                return new WebApi_Result();
            });
        }

        #endregion
    }
}