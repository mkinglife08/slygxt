using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Page
{
    public class PublicPagesController : Controller
    {
        /// <summary>
        /// 科室列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DeptInfoList()
        {
            return View();
        }
        /// <summary>
        /// 科室修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DeptInfoEdit()
        {
            return View();
        }
        /// <summary>
        /// 职工列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInfoList()
        {
            return View();
        }
        /// <summary>
        /// 职工修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInfoEdit()
        {
            return View();
        }
        /// <summary>
        /// 职工密码修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserPassWordEdit()
        {
            return View();
        }
        /// <summary>
        /// 医生分组列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DoctorGroupList()
        {
            return View();
        }
        /// <summary>
        /// 医生分组修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult DoctorGroupEdit()
        {
            return View();
        }
        /// <summary>
        /// 结构化模板列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult StructuredTemplateList()
        {
            return View();
        }
        /// <summary>
        /// 结构化模板修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult StructuredTemplateEdit()
        {
            return View();
        }

        /// <summary>
        /// 表单病历模板列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult FormEmrTemplateList()
        {
            return View();
        }

        /// <summary>
        /// 表单病历模板修改页面
        /// </summary>
        /// <returns></returns>
        public ActionResult FormEmrTemplateEdit()
        {
            return View();
        }

        public ActionResult InpatientList()
        {
            return View();
        }

        public ActionResult MedrecordQuery()
        {
            return View();
        }

        /// <summary>
        /// 病历检查汇总
        /// </summary>
        /// <returns></returns>
        public ActionResult SummaryRecoMedial()
        {
            return View();
        }

        /// <summary>
        /// 病历检查汇总查询
        /// </summary>
        /// <returns></returns>
        public ActionResult SummaryRecords()
        {
            return View();
        }
        /// <summary>
        /// 病历完整性核查
        /// </summary>
        /// <returns></returns>
        public ActionResult MedicalRecordCheck()
        {
            return View();
        }
        ///查看痕迹
        public ActionResult CheckTrace()
        {
            return View();
        }
        ///分类统计
        public ActionResult ClassificatStatistic()
        {
            return View();
        }
        ///手术类别
        public ActionResult SurgicalCategory()
        {
            return View();
        }
       
        ///统计-病历书写工作量
        public ActionResult StatisticalWorkload()
        {
            return View();
        }
        ///统计-病区工作日志 未
        public ActionResult KeepWardLog()
        {
            return View();
        }
        ///统计-病区状态
        public ActionResult StatisticalWardStatus()
        {
            return View();
        }
        ///统计-会诊统计一览表
        public ActionResult StatisticalStatisticList()
        {
            return View();
        }

        ///统计-收治患者动作量
        public ActionResult WorkloadPatients()
        {
            return View();
        }
        ///统计-手术工作量
        public ActionResult StatisticalOperationWorkload()
        {
            return View();
        }
        ///统计-手术情况
        public ActionResult StatisticalOperation()
        {
            return View();
        }

        ///运行病历检查汇总表
        public ActionResult SummaryRecordOperation()
        {
            return View();
        }

        ///质管检查
        public ActionResult QualityControlInspection()
        {
            return View();
        }
        //公告发布
             public ActionResult Announcement()
        {
            return View();
        }
        //公告管理
        public ActionResult AnnouncementManag()
        {
            return View();
        }
        //公告文章
        public ActionResult AnnouncementArticle()
        {
            return View();
        }
    }
}