/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 质控管理控制层
// 创建标识：朱天伟 2019-05-28
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Public;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMR.Services.Server.Doctor;
using FastData.Context;
using Oracle.ManagedDataAccess.Client;
using FastData;
using FastUntility.Page;

namespace EMR.Web.Controllers.Public
{
    public class QualityControlController : BaseController
    {

        InpatientService inpatientservice = new InpatientService();

        /// <summary>
        /// 完整性检查列表
        /// </summary>
        /// <param name="DpetID">科室</param>
        /// <param name="Start">出院开始时间</param>
        /// <param name="Stop">出院结束时间</param>
        /// <param name="Zyh">病人ID或病案号（健康卡号）</param>
        /// <param name="Name">病人姓名</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页几条</param>
        /// <returns></returns>
        public ActionResult MedicalRecordCheckList(string DpetID, string Start, string Stop, string Zyh, string Name, int page, int limit)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "DpetID", Value = DpetID });
                param.Add(new OracleParameter { ParameterName = "LeaveTimeStart", Value = Start });
                param.Add(new OracleParameter { ParameterName = "LeaveTimeStop", Value = Stop });
                param.Add(new OracleParameter { ParameterName = "Zyh", Value = Zyh });
                param.Add(new OracleParameter { ParameterName = "Name", Value = Name });

                //如果page为0 输出所有的数据
                if (page == 0 && limit == 0)
                {
                    var list = FastMap.Query("Inpatient.MedicalRecordCheck.List", param.ToArray(), db);
                    return Json(new { code = 0, data = list, count = list.Count });
                }
                //分页
                var pageModel = new PageModel();
                pageModel.PageId = page == 0 ? 1 : page;
                pageModel.PageSize = limit == 0 ? 10 : limit;
                var pageInfo = FastMap.QueryPage(pageModel, "Inpatient.MedicalRecordCheck.List", param.ToArray(), db);
                return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
            }
        }

        /// <summary>
        /// 检查总汇
        /// </summary>
        /// <param name="start"></param>
        /// <param name="dpetidlist"></param>
        /// <returns></returns>
        public ActionResult GetSummaryRecoMedialList(string start, string dpetidlist)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "DpetIDList", Value = dpetidlist });
                param.Add(new OracleParameter { ParameterName = "Entrytime", Value = start });
                var list = FastMap.Query("Inpatient.SummaryRecoMedial.List", param.ToArray(), db);

                list.ForEach((f) => {
                    f.Add("wwcnum","22");
                });

                return Json(new { code = 0, data = list, count = list.Count });
            }
        }




    }
}