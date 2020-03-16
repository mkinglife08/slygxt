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
    /// 环境检测
    /// </summary>
    public class EnvironmentTestController : BaseController
    {
        private EnvironmentTestService environmentTestService = new EnvironmentTestService();
        /// <summary>
        /// 环境检测数据列表
        /// </summary>
        /// <returns></returns>
        public string GetAllEnvironmentTest()
        {
            return base.ExecuteActionJsonResult("获取环境检测数据列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_ENVIRONMENTTEST> list = environmentTestService.GetAllEnvironmentTestService(filter).ToList();
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
        /// 根据ID,获取环境检测数据详情列表
        /// </summary>
        /// <param name="RISKID"></param>
        /// <returns></returns>
        public string GetEnvironmentTestSourceList(string ENVID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var tupleList = environmentTestService.GetEnvironmentTestSourceList(filter, ENVID);
            return base.ExecuteActionJsonResult("获取环境检测数据详情列表", () =>
            {
                return new WebApi_Result()
                {
                    data = tupleList
                };
            });
        }

        public string Save(BUS_ENVIRONMENTTEST envModel, string envSource)
        {
            {
                return base.ExecuteActionJsonResult("保存信息", () =>
                {
                    var userToken = Request["token"].GetUserToken();
                    //完善反馈单信息
                    if (string.IsNullOrWhiteSpace(envModel.ENVID))
                    {
                        envModel.XZRYID = userToken.UserId;
                        envModel.XZRYMC = userToken.USERNAME;
                        envModel.XZRQ = DateTime.Now;
                    }
                    envModel.ORGANID = userToken.ORGANID;
                    environmentTestService.Save(envModel, envSource);
                    return new WebApi_Result();
                });
            }
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_ENVIRONMENTTEST>.DeleteById(Request["ENVID"], "ENVID");
                EntityOperate<BUS_ENVIRONMENTTEST_SOURCE>.DeleteById(Request["ENVID"], "ENVID");
                return new WebApi_Result() { };
            });
        }
    }
}