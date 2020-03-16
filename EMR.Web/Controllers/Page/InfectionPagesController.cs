using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Page
{
    /// <summary>
    /// 院感系统所用页面
    /// </summary>
    public class InfectionPagesController : Controller
    {
        #region 感染督察反馈单

        /// <summary>
        /// 反馈单列表页
        /// </summary>
        /// <returns></returns>
        public ActionResult InspectFeedBackList()
        {
            return View();
        }

        /// <summary>
        /// 反馈单数据列表
        /// </summary>
        /// <returns></returns>
        public ActionResult InspectFeedBackSourceList()
        {
            return View();
        }

        #endregion

        #region 洗手（卫生手消毒）操作评分标准
        /// <summary>
        /// 洗手操作数据列表
        /// </summary>
        /// <returns></returns>
        public ActionResult WashHandList()
        {
            return View();
        }
        /// <summary>
        /// 洗手操作数据详情
        /// </summary>
        /// <returns></returns>
        public ActionResult WashHandDetail()
        {
            return View();
        }
        #endregion

        #region 外科手消毒操作评分标准
        /// <summary>
        /// 洗手操作数据列表
        /// </summary>
        /// <returns></returns>
        public ActionResult DisInfectionList()
        {
            return View();
        }
        /// <summary>
        /// 洗手操作数据详情
        /// </summary>
        /// <returns></returns>
        public ActionResult DisInfectionDetail()
        {
            return View();
        }
        #endregion

        #region 医院感染风险评分表
        /// <summary>
        /// 医院感染风险评分数据列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RiskInfectionList()
        {
            return View();
        }
        /// <summary>
        /// 医院感染风险评分数据详情
        /// </summary>
        /// <returns></returns>
        public ActionResult RiskInfectionDetail()
        {
            return View();
        }
        #endregion

        #region 多重耐药菌隔离措施落实情况监督 
        
        /// <summary>
        /// 多重耐药菌隔离措施落实情况监督列表
        /// </summary>
        /// <returns></returns>
        public ActionResult DrugResistQuarList()
        {
            return View();
        }
        /// <summary>
        /// 多重耐药菌隔离措施落实情况监督详情
        /// </summary>
        /// <returns></returns>
        public ActionResult DrugResistQuarDetail()
        {
            return View();
        }

        #endregion

        #region 环境监测结果 

        /// <summary>
        /// 环境监测结果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult EnvironmentTestList()
        {
            return View();
        }
        /// <summary>
        /// 环境监测结果详情
        /// </summary>
        /// <returns></returns>
        public ActionResult EnvironmentTestDetail()
        {
            return View();
        }

        #endregion

        #region 手卫生依从性及正确性现场调查
        /// <summary>
        /// 手卫生依从性及正确性现场调查列表
        /// </summary>
        /// <returns></returns>
        public ActionResult HandHygieneList()
        {
            return View();
        }
        /// <summary>
        /// 手卫生依从性及正确性现场调查详情
        /// </summary>
        /// <returns></returns>
        public ActionResult HandHygieneDetail()
        {
            return View();
        }
        /// <summary>
        /// 手卫生依从性及正确性现场调查分析页
        /// </summary>
        /// <returns></returns>
        public ActionResult HandHygieneAnalysis()
        {
            return View();
        }
        #endregion

        #region 医院感染病例个案调查表
        /// <summary>
        /// 医院感染病例个案调查列表
        /// </summary>
        /// <returns></returns>
        public ActionResult InfectionExamineList()
        {
            return View();
        }

        /// <summary>
        /// 医院感染病例个案调查详情
        /// </summary>
        /// <returns></returns>
        public ActionResult InfectionExamineDetail()
        {
            return View();
        }
        #endregion


    }
}