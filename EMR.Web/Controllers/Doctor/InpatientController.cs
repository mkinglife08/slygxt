using EMR.Data;
using EMR.Data.Models;
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
    public class InpatientController : BaseController
    {
        private BasicInpatientInfoService inpatientService = new BasicInpatientInfoService();
        /// <summary>
        /// 获取住院病人列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取住院病人列表", () =>
            {
                InpatientFilter filter = GetPageData<InpatientFilter>(0);
                //List<CD_BasicInpatientInfo> list = inpatientService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<CD_BasicInpatientInfo> list = inpatientService.GetAll(filter);
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
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取住院病人信息", () =>
            {
                CD_Inpatient list = EntityOperate<CD_Inpatient>.GetEntityById(Request["HealthCard"], "HealthCard");
                return new WebApi_Result() { data = list };
            });
        }
    }
}