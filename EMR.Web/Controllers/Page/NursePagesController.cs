/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：NursePagesController.cs
// 文件功能描述： 护士站页面显示控制器，系统设置模块下所有页面的控制器，每个页面都需要对应一个方法名称与页面名称一致的方法，否则无法正常渲染页面。方法中也可以返回一些简单的参数给前端页面，具体可以参考.net MVC的使用方法。
// 创建标识：朱天伟 2019-2-27 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Services.Server;
using EMR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Page
{
    public class NursePagesController : Controller
    {
        // GET: Nurse
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 体温单
        /// </summary>
        /// <returns></returns>
        public ActionResult TemperatureChart()
        {
            return View();
        }
        public ActionResult TemperatureChartEdit()
        {
            return View();
        }

        /// <summary>
        /// 血糖检验记录编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult BloodGlucoseTestEdit()
        {
            return View();
        }
        //血糖检验检查结果记录
        public ActionResult BloodGlucoseTestResult()
        {
            return View();
        }
        //导管评估单
        public ActionResult CatheterSheet()
        {
            return View();
        }
        //产程图
         public ActionResult LaborFigure()
        {
            return View();
        }
        //护理入院评估单编辑
        public ActionResult NursingAdmEdit()
        {
            return View();
        }
        //入院评估单查看
        public ActionResult NursingAdmView()
        {
            return View();
        }
        //护理记录添加
        public ActionResult NursingRecordAdd()
        {
            return View();
        }
        //护理记录
        public ActionResult NursingRecord()
        {
            return View();
        }
        //产后护理记录单
         public ActionResult PostpartumRecord()
        {
            return View();
        }
        //产前记录
        public ActionResult PrenatalRecords()
        {
            return View();
        }
        //无证无卡孕妇登记
        public ActionResult WomenWithoutCert()
        {
            return View();
        }
        //分娩记录
        public ActionResult WhenRecord()
        {
            return View();
        }
        
    }
}