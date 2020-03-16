using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Infection;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EMR.Web.Extension;

namespace EMR.Web.Controllers.Infection
{
    /// <summary>
    /// 外科手消毒操作评分标准
    /// </summary>
    public class DisInfectionController : BaseController
    {
        private DisInfectionService disInfectionService = new DisInfectionService();

        /// <summary>
        /// 外科手消毒操作评分列表
        /// </summary>
        /// <returns></returns>
        public string GetAllDisInfection()
        {
            return base.ExecuteActionJsonResult("获取外科手消毒操作评分列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_DISINFECTION> list = disInfectionService.GetAllDisInfection(filter).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
                //return new WebApi_Result() { data = list, count = list.Count };
            });
        }

        /// <summary>
        /// 根据消毒操作ID 获取外科手消毒操作评分
        /// </summary>
        /// <param name="WHOID"></param>
        /// <returns></returns>
        public string GetDisInfectionModel(string DISID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var WashHandModel = disInfectionService.GetDisInfectionModel(filter, DISID);
            return base.ExecuteActionJsonResult("获取外科手消毒操作数据", () =>
            {
                return new WebApi_Result()
                {
                    data = WashHandModel
                };
            });
        }

        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                BUS_DISINFECTION entity = base.GetPageData<BUS_DISINFECTION>(0);
                var userToken = Request["token"].GetUserToken();
                //完善反馈单数据信息 
                if (string.IsNullOrWhiteSpace(entity.DISID))
                {
                    entity.XZRYID = userToken.UserId;
                    entity.XZRYMC = userToken.USERNAME; 
                    entity.XZRQ = DateTime.Now;
                    entity.ORGANID = userToken.ORGANID;
                }
                disInfectionService.Save(entity);
                return new WebApi_Result();
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_DISINFECTION>.DeleteById(Request["DISID"], "DISID"); 
                return new WebApi_Result() { };
            });
        }

    }
}