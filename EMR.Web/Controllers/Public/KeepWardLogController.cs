/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 工作日志控制层
// 创建标识：朱天伟 2019-05-22 
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
    public class KeepWardLogController : BaseController
    {
        /// <summary>
        /// 病人服务器
        /// </summary>
        InpatientService inpatientService = new InpatientService();
        /// <summary>
        /// 转科服务器
        /// </summary>
        TransferService transferService = new TransferService();

        /// <summary>
        /// 入院情况表
        /// </summary>
        /// <param name="DpetID">科室ID</param>
        /// <param name="Start">入院开始时间</param>
        /// <param name="Stop">入院结束时间</param>
        /// <param name="Zyh">病人ID或病案号（健康卡号）</param>
        /// <param name="Name">病人姓名</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页几条</param>
        /// <returns></returns>
        public ActionResult GetAdmissionList(string DpetID, string Start, string Stop,string Zyh, string Name,int page,int limit)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "DpetID", Value = DpetID });
                param.Add(new OracleParameter { ParameterName = "EntryTimeStart", Value = Start });
                param.Add(new OracleParameter { ParameterName = "EntryTimeStop", Value = Stop });
                param.Add(new OracleParameter { ParameterName = "Zyh", Value = Zyh });
                param.Add(new OracleParameter { ParameterName = "Name", Value = Name });

                //如果page为0 输出所有的数据
                if (page == 0&& limit==0) {
                    var list = FastMap.Query("Inpatient.KeepWardLog.List", param.ToArray(), db);
                    return Json(new { code = 0, data = list, count = list.Count });
                }
                //分页
                var pageModel = new PageModel();
                pageModel.PageId = page == 0 ? 1 : page;
                pageModel.PageSize = limit == 0 ? 10 : limit;
                var pageInfo = FastMap.QueryPage(pageModel,"Inpatient.KeepWardLog.List", param.ToArray(), db);
                return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
            }
        }


        /// <summary>
        /// 出院情况
        /// </summary>
        /// <param name="DpetID">科室ID</param>
        /// <param name="Start">出院开始时间</param>
        /// <param name="Stop">出院结束时间</param>
        /// <param name="Zyh">病人ID或病案号（健康卡号）</param>
        /// <param name="Name">病人姓名</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页几条</param>
        /// <returns></returns>
        public ActionResult GetLeaveList(string DpetID, string Start, string Stop,string Zyh, string Name,int page,int limit){

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
                    var list = FastMap.Query("Inpatient.KeepWardLog.List", param.ToArray(), db);
                    return Json(new { code = 0, data = list, count = list.Count });
                }

                //分页
                var pageModel = new PageModel();
                pageModel.PageId = page == 0 ? 1 : page;
                pageModel.PageSize = limit == 0 ? 10 : limit;
                var pageInfo = FastMap.QueryPage(pageModel, "Inpatient.KeepWardLog.List", param.ToArray(), db);
                return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
            }
        }

        /// <summary>
        /// 转入情况
        /// </summary>
        /// <param name="DpetID">转入科室ID</param>
        /// <param name="Start">转入开始时间</param>
        /// <param name="Stop">转入结束时间</param>
        /// <param name="Zyh">病人ID或病案号（健康卡号）</param>
        /// <param name="Name">病人姓名</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页几条</param>
        /// <returns></returns>
        public ActionResult GetTransferInList(string DpetID, string Start, string Stop, string Zyh, string Name, int page, int limit)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "Zyh", Value = Zyh });
                param.Add(new OracleParameter { ParameterName = "Name", Value = Name });
                param.Add(new OracleParameter { ParameterName = "CurrentDeptID", Value = DpetID });
                param.Add(new OracleParameter { ParameterName = "ConversionTimeStart", Value = Start });
                param.Add(new OracleParameter { ParameterName = "ConversionTimeStop", Value = Stop });


                //如果page为0 输出所有的数据
                if (page == 0 && limit == 0)
                {
                    var list = FastMap.Query("Transfer.KeepWardLog.List", param.ToArray(), db);
                    return Json(new { code = 0, data = list, count = list.Count });
                }

                //分页
                var pageModel = new PageModel();
                pageModel.PageId = page == 0 ? 1 : page;
                pageModel.PageSize = limit == 0 ? 10 : limit;
                var pageInfo = FastMap.QueryPage(pageModel, "Transfer.KeepWardLog.List", param.ToArray(), db);
                return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
            }
        }

        /// <summary>
        /// 转出情况
        /// </summary>
        /// <param name="DpetID">转出科室ID</param>
        /// <param name="Start">转出开始时间</param>
        /// <param name="Stop">转出结束时间</param>
        /// <param name="Zyh">病人ID或病案号（健康卡号）</param>
        /// <param name="Name">病人姓名</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页几条</param>
        /// <returns></returns>
        public ActionResult GetTransferOutList(string DpetID, string Start, string Stop, string Zyh, string Name, int page, int limit)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "Zyh", Value = Zyh });
                param.Add(new OracleParameter { ParameterName = "Name", Value = Name });
                param.Add(new OracleParameter { ParameterName = "OldDeptID", Value = DpetID });
                param.Add(new OracleParameter { ParameterName = "ConversionTimeStart", Value = Start });
                param.Add(new OracleParameter { ParameterName = "ConversionTimeStop", Value = Stop });


                //如果page为0 输出所有的数据
                if (page == 0 && limit == 0)
                {
                    var list = FastMap.Query("Transfer.KeepWardLog.List", param.ToArray(), db);
                    return Json(new { code = 0, data = list, count = list.Count });
                }

                //分页
                var pageModel = new PageModel();
                pageModel.PageId = page == 0 ? 1 : page;
                pageModel.PageSize = limit == 0 ? 10 : limit;
                var pageInfo = FastMap.QueryPage(pageModel, "Transfer.KeepWardLog.List", param.ToArray(), db);
                return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
            }
        }

        /// <summary>
        /// 统计列表
        /// </summary>
        /// <param name="DpetID">科室id</param>
        /// <param name="Start">开始时间</param>
        /// <param name="Stop">结束时间</param>
        /// <param name="page">当前页</param>
        /// <param name="limit">每页几条</param>
        /// <returns></returns>
        public ActionResult GetStatisticsList(string DpetID, string Start, string Stop, int page, int limit)
        {

            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "DeptID", Value = DpetID });
                param.Add(new OracleParameter { ParameterName = "Start", Value = Start });
                param.Add(new OracleParameter { ParameterName = "Stop", Value = Stop });


                //如果page为0 输出所有的数据
                if (page == 0 && limit == 0)
                {
                    var list = FastMap.Query("Dept.KeepWardLog.List", param.ToArray(), db);
                    return Json(new { code = 0, data = list, count = list.Count });
                }

                //分页
                var pageModel = new PageModel();
                pageModel.PageId = page == 0 ? 1 : page;
                pageModel.PageSize = limit == 0 ? 10 : limit;
                var pageInfo = FastMap.QueryPage(pageModel, "Dept.KeepWardLog.List", param.ToArray(), db);
                return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
            }
        }
    }
}