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
    /// 手卫生依从性及正确性现场调查
    /// </summary>
    public class HandHygieneController : BaseController
    {
        private HandHygieneService handHygieneService = new HandHygieneService();
        /// <summary>
        /// 手卫生依从性及正确性现场调查列表
        /// </summary>
        /// <returns></returns>
        public string GetAllHandHygiene()
        {
            return base.ExecuteActionJsonResult("手卫生依从性及正确性现场调查列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_HANDHYGIENE> list = handHygieneService.GetAllHandHygieneService(filter).ToList();
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
        /// 根据主ID，手卫生依从性及正确性现场调查数据列表
        /// </summary>
        /// <param name="RISKID"></param>
        /// <returns></returns>
        public string GetHandHygieneSourceList(string HANDID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var handhygieneList = handHygieneService.GetHandHygieneSourceList(filter, HANDID);
            return base.ExecuteActionJsonResult("获取手卫生依从性及正确性现场调查数据列表", () =>
            {
                return new WebApi_Result()
                {
                    data = handhygieneList
                };
            });
        }


        /// <summary>
        /// 根据主ID，获取手卫生依从性及正确性现场调查数据分析表
        /// </summary>
        /// <param name="RISKID"></param>
        /// <returns></returns>
        public string GetHandHygiAnalysisSourceList(string HANDID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var handhygieneList = handHygieneService.GetHandHygiAnalysisSourceList(filter, HANDID);
            return base.ExecuteActionJsonResult("获取手卫生依从性现场调查数据分析表", () =>
            {
                return new WebApi_Result()
                {
                    data = handhygieneList
                };
            });
        }


        public string Save(BUS_HANDHYGIENE mainModel, string handSource)
        {

            {
                return base.ExecuteActionJsonResult("保存信息", () =>
                {
                    var userToken = Request["token"].GetUserToken();
                    //完善反馈单信息
                    if (string.IsNullOrWhiteSpace(mainModel.HANDID))
                    {
                        mainModel.XZRYID = userToken.UserId;
                        mainModel.XZRYMC = userToken.USERNAME;
                        mainModel.XZRQ = DateTime.Now;
                    }
                    mainModel.ORGANID = userToken.ORGANID;
                    handHygieneService.Save(mainModel, handSource);
                    return new WebApi_Result();
                });
            }
        }


        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_HANDHYGIENE>.DeleteById(Request["HANDID"], "HANDID");
                EntityOperate<BUS_HANDHYGIENE_SOURCE>.DeleteById(Request["HANDID"], "HANDID");
                return new WebApi_Result() { };
            });
        }


    }
}