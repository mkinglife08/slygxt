using EMR.Services.Server.Doctor;
using EMR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Page
{
    public class DoctorPagesController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        
        /// <summary>
        /// 病案首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Medrecord()
        {
            return View();
        }

        /// <summary>
        /// 病案首页-打印
        /// </summary>
        /// <returns></returns>
        public ActionResult MedrecordPrint()
        {
            return View();
        }

        /// <summary>
        /// 打开入院记录，如果以及有入院记录展示打印页面，如果没有入院记录展示编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MedrecordRoute()
        {
            MedicalRecordHomePageService service = new MedicalRecordHomePageService();
            CD_MedicalRecordHomePage info = service.GetInfoByInpatientId(Request["InpatientId"]);
            if (info != null)
            {
                return View("MedrecordPrint");
            }
            else
            {
                return View("Medrecord");
            }
        }

        /// <summary>
        /// 住院病人列表
        /// </summary>
        /// <returns></returns>
        public ActionResult InpatientList()
        {
            return View();
        }
        /// <summary>
        /// 会诊单弹窗
        /// </summary>
        /// <returns></returns>
        public ActionResult ConsultationPop()
        {
            return View();
        }
        /// <summary>
        /// 会诊单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ConsultationList()
        {
            return View();
        }
       /// <summary>
        /// 会诊单编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult ConsultationEdit()
        {
            return View();
        }
        /// <summary>
        /// 会诊单打印
        /// </summary>
        /// <returns></returns>
        public ActionResult ConsultationPrint()
        {
            return View();
        }
        /// <summary>
        /// 患者信息
        /// </summary>
        /// <returns></returns>
        public ActionResult PatientInfor()
        {
            return View();
        }

        /// <summary>
        /// 入院记录类型选择
        /// </summary>
        /// <returns></returns>
        public ActionResult HospitalRecordType()
        {
            return View();
        }
        /// <summary>
        /// 入院记录编辑
        /// </summary>
        /// <returns></returns>
		public ActionResult HospitalRecordEdit()
        {
            return View();
        }
        /// <summary>
        /// 入院记录打印
        /// </summary>
        /// <returns></returns>
        public ActionResult HospitalRecord()
        {
            return View();
        }
        /// <summary>
        /// 专科检查
        /// </summary>
        /// <returns></returns>
        public ActionResult SpecializedExam() {
            return View();
        }

        /// <summary>
        /// 打开入院记录，如果以及有入院记录展示打印页面，如果没有入院记录展示编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult HospitalRecordRoute()
        {
            HospitalRecordService service = new HospitalRecordService();
            CD_HospitalRecord info = service.GetInfoByInpatientId(Request["InpatientId"]);
            if (info != null)
            {
                return View("HospitalRecord");
            }
            else
            {
                return View("HospitalRecordType");
            }
        }
        /// <summary>
        /// 手术记录编辑-弹出框
        /// </summary>
        /// <returns></returns>
        public ActionResult OperationRecordEdit()
        {
            return View();
        }

        /// <summary>
        /// 诊断编辑-弹出框
        /// </summary>
        /// <returns></returns>
        public ActionResult PatientDiagnosisEdit()
        {
            return View();
        }

        /// <summary>
        /// 病程记录
        /// </summary>
        /// <returns></returns>
        public ActionResult ProgressNoteList()
        {
            return View();
        }

        /// <summary>
        /// 首次病程记录 
        /// </summary>
        /// <returns></returns>
        public ActionResult ProgressNoteFirst()
        {
            return View();
        }

        /// <summary>
        /// 中医首次病程记录 
        /// </summary>
        /// <returns></returns>
        public ActionResult ProgressNoteChina()
        {
            return View();
        }

        /// <summary>
        /// 西医首次病程记录 
        /// </summary>
        /// <returns></returns>
        public ActionResult ProgressNoteWestern()
        {
            return View();
        }

        /// <summary>
        /// 围手术期文书
        /// </summary>
        /// <returns></returns>
        public ActionResult MedicalRecordList()
        {
            return View();
        }

        public ActionResult SaveTemplate()
        {
            return View();
        }

        public ActionResult ImportTemplate()
        {
            return View();
        }
        public ActionResult AttendPhy()
        {
            return View();
        }

        public ActionResult InformedConsent()
        {
            return View();
        }

        public ActionResult InformedConsentHour()
        {
            return View();
        }

        /// <summary>
        /// 住院卡
        /// </summary>
        /// <returns></returns>
        public ActionResult HospitalCard()
        {
            return View();
        }

        /// <summary>
        /// 死亡记录
        /// </summary>
        /// <returns></returns>
        public ActionResult DeathRecord()
        {
            return View();
        }

        /// <summary>
        /// 出院记录
        /// </summary>
        /// <returns></returns>
        public ActionResult OuthospitalRecord()
        {
            return View();
        }

        /// <summary>
        /// 出院证明
        /// </summary>
        /// <returns></returns>
        public ActionResult DischargeCertificate()
        {
            return View();
        }

        /// <summary>
        /// 授权
        /// </summary>
        /// <returns></returns>
        public ActionResult PatientAuthorization()
        {
            return View();
        }
        //婴儿出生出院记录
        public ActionResult BabyRecord()
        {
            return View();
        }
        //婴儿室记录
        public ActionResult NurseryRecord()
        {
            return View();
        }
        //产褥复旧
        public ActionResult Puerperal()
        {
            return View();
        }
        //产时记录
        public ActionResult WhenRecord()
        {
            return View();
        }
        //低位产钳助产术
        public ActionResult LowPosition()
        {
            return View();
        }
        //计划生育小节
        public ActionResult SummaryFamily()
        {
            return View();
        }
        //计划生育病程记录
        public ActionResult FamilyCourse()
        {
            return View();
        }

        /// <summary>
        /// 病历审阅
        /// </summary>
        /// <returns></returns>
        public ActionResult MedicalRecordAccessRecord()
        {
            return View();

        }
        //康复治疗单
        public ActionResult RehabilitationList()
        {
            return View();

        }
        //吞咽功能障碍评定量表
        public ActionResult DysphagiaSale()
        {
            return View();
        }
        //物理治疗单
        public ActionResult PhysiotherapySheet()
        {
            return View();
        }
        //作业治疗申请记录
        public ActionResult JobRecords()
        {
            return View();
        }
        //工号查询
        public ActionResult NumberQuery()
        {
            return View();
        }
        //综合查询
        public ActionResult IntegratedQuery()
        {
            return View();
        }
        //报卡查询
         public ActionResult ReportQueries()
        {
            return View();
        }
        //病案查阅
        public ActionResult MedicalReview()
        {
            return View();
        }
        //病历检查情况
        public ActionResult MedicalRecords()
        {
            return View();
        }
        //查看痕迹
        public ActionResult CheckTrace()
        {
            return View();
        }
        //会诊信息
        public ActionResult InforConsultation()
        {
            return View();
        }
        //六大本-护理文书
        public ActionResult NursingDocuments()
        {
            return View();
        }
        //六大本-记录学习
        public ActionResult RecordLearning()
        {
            return View();
        }
        //六大本-记录学习新增
        public ActionResult RecordLearningAdd()
        {
            return View();
        }
        //六大本-死亡病例讨论
        public ActionResult DiscussionRecord()
        {
            return View();
        }
        //六大本死亡病例新增
        public ActionResult DiscussionRecordAdd()
        {
            return View();
        }
        //六大本-医疗安全新增
        public ActionResult MedicaSecurityAdd()
        {
            return View();
        }
        //六大本-医疗安全学习讨论
        public ActionResult MedicalSafety()
        {
            return View();
        }
        //六大本-疑难杂症病历讨论
        public ActionResult IncurableDiseases()
        {
            return View();
        }
        //六大本-疑难杂症新增
        public ActionResult IncurableDiseasesAdd()
        {
            return View();
        }
        //六大本-值班交接本
        public ActionResult HandoverDuty()
        {
            return View();
        }
        //六大本-值班交接新增
        public ActionResult HandoverDutyAdd()
        {
            return View();
        }
        //六大本-重大手术前讨论
        public ActionResult MajorPreoper()
        {
            return View();
        }
        //危急值
        public ActionResult criticalValue()
        {
            return View();
        }
        //维护-医疗组
        public ActionResult MedicalMaintenance()
        {
            return View();
        }
        //质量控制-查看痕迹
        public ActionResult QualityView()
        {
            return View();
        }
        //重大疑难杂症手术
        public ActionResult MajorSurgery()
        {
            return View();
        }
        //质管检查
        public ActionResult QualityControlInspection()
        {
            return View();
        }
        //长期医嘱单
        public ActionResult LongOrders()
        {
            return View();
        }
        //临时医嘱单
        public ActionResult TemporaryOrders()
        {
            return View();
        }
        //检验报告
        public ActionResult Inspection()
        {
            return View();
        }
        //检查报告
        public ActionResult InspectionReport()
        {
            return View();
        }
        //既往住院记录
        public ActionResult Previous()
        {
            return View();
        }
    }
}