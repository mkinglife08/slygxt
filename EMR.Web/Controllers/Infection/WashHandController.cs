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
    /// 洗手操作评分标准
    /// </summary>
    public class WashHandController : BaseController
    {
        private WashHandService washhandService = new WashHandService();

        /// <summary>
        /// 获取所有洗手操作评分列表
        /// </summary>
        /// <returns></returns>
        public string GetAllWashHand()
        {
            return base.ExecuteActionJsonResult("获取洗手操作评分列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_WASHHANDOPERATION> list = washhandService.GetAllWashHand(filter).ToList();
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
        /// 根据洗手操作ID 获取单个洗手操作实体
        /// </summary>
        /// <param name="WHOID"></param>
        /// <returns></returns>
        public string GetWashHandModel(string WHOID)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var WashHandModel = washhandService.GetWashHandModel(filter, WHOID);
            return base.ExecuteActionJsonResult("获取洗手操作数据", () =>
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
                BUS_WASHHANDOPERATION entity = base.GetPageData<BUS_WASHHANDOPERATION>(0);
                var userToken = Request["token"].GetUserToken();
                //完善反馈单数据信息 
                if (string.IsNullOrWhiteSpace(entity.WHOID))
                {
                    entity.XZRYID = userToken.UserId;
                    entity.XZRYMC = userToken.USERNAME;
                    //entity.DEPTID = userToken.DpetID;
                    //entity.DEPTNAME = "没给登录人所在部门名";
                    entity.XZRQ = DateTime.Now;
                    entity.ORGANID = userToken.ORGANID;
                }
                washhandService.Save(entity);
                return new WebApi_Result();
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_WASHHANDOPERATION>.DeleteById(Request["WHOID"], "WHOID"); 
                return new WebApi_Result() { };
            });
        }
    }
}