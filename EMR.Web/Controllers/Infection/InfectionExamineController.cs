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
    /// 医院感染病例个案调查
    /// </summary>
    public class InfectionExamineController : BaseController
    {
        private InfectionExamineService infectionExamineService = new InfectionExamineService();
        /// <summary>
        ///医院感染病例个案调查列表
        /// </summary>
        /// <returns></returns>
        public string GetAllInfectionExamine()
        {
            return base.ExecuteActionJsonResult("获取医院感染病例个案调查列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_INFECTIONEXAMINE> list = infectionExamineService.GetAllInfectionExamineService(filter).ToList();
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
        /// 根据ID,获取医院感染病例个案调查详情数据
        /// </summary>
        /// <param name="RISKID"></param>
        /// <returns></returns>
        public string GetInfectionExamineSourceList(string EXID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var tupleList = infectionExamineService.GetInfectionExamineSource(filter, EXID);
            return base.ExecuteActionJsonResult("获取医院感染病例个案调查详情数据", () =>
            {
                return new WebApi_Result()
                {
                    data = tupleList
                };
            });
        }

        public string Save(string examModelJson, string examBloodSource)
        {
            var examModel = Newtonsoft.Json.JsonConvert.DeserializeObject<BUS_INFECTIONEXAMINE>(examModelJson);

           // var examModel = JSONHelper.DeserializeObject<BUS_INFECTIONEXAMINE>(examModelJson, "yyyy-MM-dd HH:ss:mm");
            {
                return base.ExecuteActionJsonResult("保存信息", () =>
                {
                    var userToken = Request["token"].GetUserToken();
                    //完善反馈单信息
                    if (string.IsNullOrWhiteSpace(examModel.EXID))
                    {
                        examModel.XZRYID = userToken.UserId;
                        examModel.XZRYMC = userToken.USERNAME;
                        examModel.XZRQ = DateTime.Now;
                    }
                    examModel.ORGANID = userToken.ORGANID;
                    infectionExamineService.Save(examModel, examBloodSource);
                    return new WebApi_Result();
                });
            }
        }


        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            { 
                EntityOperate<BUS_INFECTIONEXAMINE>.DeleteById(Request["EXID"], "EXID");
                EntityOperate<BUS_INFECTIONEXAMINE_BLOOD>.DeleteById(Request["EXID"], "EXID");
                return new WebApi_Result() { };
            });
        }


    }
}