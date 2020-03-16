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
using EMR.Common;

namespace EMR.Web.Controllers.Infection
{
    /// <summary>
    /// 感染风险评分
    /// </summary>
    public class RiskInfectionController : BaseController
    {
        private RiskInfectionService riskInfectionService = new RiskInfectionService();
        /// <summary>
        /// 感染风险评分列表
        /// </summary>
        /// <returns></returns>
        public string GetAllRiskInfection()
        {
            return base.ExecuteActionJsonResult("获取感染风险评分列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_RISKINFECTION> list = riskInfectionService.GetAllRiskInfectionService(filter).ToList();
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
        /// 根据感染ID，获取感染风险评分数据列表
        /// </summary>
        /// <param name="RISKID"></param>
        /// <returns></returns>
        public string GetRiskInfectionSourceList(string RISKID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var riskInfectionList = riskInfectionService.GetRiskInfectionSourceList(filter, RISKID);
            return base.ExecuteActionJsonResult("获取感染风险评分数据列表", () =>
            {
                return new WebApi_Result()
                {
                    data = riskInfectionList
                };
            });
        }

        public string Save(BUS_RISKINFECTION riskModel, string riskSource)
        {
            {
                return base.ExecuteActionJsonResult("保存信息", () =>
                {
                    var userToken = Request["token"].GetUserToken();
                    //完善反馈单信息
                    if (string.IsNullOrWhiteSpace(riskModel.RISKID))
                    {
                        riskModel.XZRYID = userToken.UserId;
                        riskModel.XZRYMC = userToken.USERNAME;
                        riskModel.XZRQ = DateTime.Now;
                    }
                    riskModel.ORGANID = userToken.ORGANID;
                    riskInfectionService.Save(riskModel, riskSource);
                    return new WebApi_Result();
                });
            }
        }


        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_RISKINFECTION>.DeleteById(Request["RISKID"], "RISKID");
                EntityOperate<BUS_RISKINFECTION_SOURCE>.DeleteById(Request["RISKID"], "RISKID");
                return new WebApi_Result() { };
            });
        }


    } 
}