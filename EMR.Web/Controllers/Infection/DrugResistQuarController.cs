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
    /// 多重耐药菌隔离措施落实情况监督  
    /// </summary>
    public class DrugResistQuarController : BaseController
    {
        private DrugResistQuarService drugResistQuarService = new DrugResistQuarService();
        /// <summary>
        /// 多重耐药菌隔离措施列表
        /// </summary>
        /// <returns></returns>
        public string GetAllDrugResistQuar()
        {
            return base.ExecuteActionJsonResult("获取多重耐药菌隔离措施列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_DRUGRESISTQUAR> list = drugResistQuarService.GetAllDrugResistQuarService(filter).ToList();
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
        /// 根据感染ID，获取多重耐药菌隔离措施数据列表
        /// </summary>
        /// <param name="RISKID"></param>
        /// <returns></returns>
        public string GetDrugResistQuarSourceList(string DCID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var riskInfectionList = drugResistQuarService.GetDrugResistQuarSourceList(filter, DCID);
            return base.ExecuteActionJsonResult("获取多重耐药菌隔离措施数据列表", () =>
            {
                return new WebApi_Result()
                {
                    data = riskInfectionList
                };
            });
        }

        public string Save(BUS_DRUGRESISTQUAR drugModel, string drugSource)
        {
            {
                return base.ExecuteActionJsonResult("保存信息", () =>
                {
                    var userToken = Request["token"].GetUserToken();
                    //完善反馈单信息
                    if (string.IsNullOrWhiteSpace(drugModel.DCID))
                    {
                        drugModel.XZRYID = userToken.UserId;
                        drugModel.XZRYMC = userToken.USERNAME;
                        drugModel.XZRQ = DateTime.Now;
                    }
                    drugModel.ORGANID = userToken.ORGANID;
                    drugResistQuarService.Save(drugModel, drugSource);
                    return new WebApi_Result();
                });
            }
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_DRUGRESISTQUAR>.DeleteById(Request["DCID"], "DCID");
                EntityOperate<BUS_DRUGRESISTQUAR_SOURCE>.DeleteById(Request["DCID"], "DCID");
                return new WebApi_Result() { };
            });
        }

    }
}