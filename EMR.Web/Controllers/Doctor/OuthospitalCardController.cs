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
    public class OuthospitalCardController : BaseController
    {
        private OuthospitalCardService OuthospitalCardService = new OuthospitalCardService();

        /// <summary>
        /// 保存出院证明
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("出院证明保存", () =>
            {
                CD_OuthospitalCard entity = base.GetPageData<CD_OuthospitalCard>(0);
                OuthospitalCardService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }
        /// <summary>
        /// 获取出院证明列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取出院证明列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                //List<CD_BasicOuthospitalCardInfo> list = OuthospitalCardService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<CD_OuthospitalCard> list = OuthospitalCardService.GetAll(filter);
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取出院证明信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取出院证明信息", () =>
            {
                CD_OuthospitalCard entity = EntityOperate<CD_OuthospitalCard>.GetEntityById(Request["InpatientId"], "InpatientId");
                if (entity != null && string.IsNullOrWhiteSpace(entity.Creator))
                    entity.Creator = EntityOperate<GI_UserInfo>.GetEntityById(entity.Creator, "USERID").UserName;
                return new WebApi_Result() { data = entity };
            });
        }
    }
}