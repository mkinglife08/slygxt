/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：TemperatureChartController.cs
// 文件功能描述： 体温单额外控制层
// 创建标识：朱天伟 2019-03-01
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Nurse;
using EMR.Web.Controllers.Page;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Nurse
{
    public class TemperatureChartExtraController : BaseController
    {
        /// <summary>
        /// 体温操作类
        /// </summary>
        TemperatureChartService temperatureChartService = new TemperatureChartService();
        /// <summary>
        /// 体温额外操作类
        /// </summary>
        TemperatureChartExtraService temperatureChartExtraService = new TemperatureChartExtraService();
        /// <summary>
        /// 体温单额外列表根据时间
        /// </summary>
        /// <returns></returns>
        public string GetListByTime()
        {
            return base.ExecuteActionJsonResult("体温单额外列表", () =>
            {
                string InpatientId = Request["InpatientId"];
                string StartDay = Request["StartDay"];
                string EndDay = Request["EndDay"];
                List<CN_TemperatureChartExtra> list = temperatureChartExtraService.GetListByMeasureTime(InpatientId, StartDay, EndDay);
                int curpage = 0, limit = 10;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }


        
        /// <summary>
        /// 根据住院病人id以及测量日期获得体温单记录
        /// </summary>
        /// <returns></returns>
        public string GetInfoByInpatientId()
        {
            return base.ExecuteActionJsonResult("体温单额外列表", () =>
            {
                List<CN_TemperatureChartExtra> list = temperatureChartExtraService.GetListByInpatientId(Request["InpatientId"], Request["day"]);
                int curpage = 0, limit = 10;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
    }
}