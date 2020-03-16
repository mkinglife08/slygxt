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
    public class DeathRecordController : BaseController
    {
        private DeathRecordService DeathRecordService = new DeathRecordService();

        /// <summary>
        /// 保存死亡记录
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("死亡记录保存", () =>
            {
                CD_DeathRecord entity = base.GetPageData<CD_DeathRecord>(0);
                DeathRecordService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }
        /// <summary>
        /// 获取死亡记录列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取死亡记录列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                //List<CD_BasicDeathRecordInfo> list = DeathRecordService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<CD_DeathRecord> list = DeathRecordService.GetAll(filter);
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取死亡记录信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取死亡记录信息", () =>
            {
                CD_DeathRecord entity = EntityOperate<CD_DeathRecord>.GetEntityById(Request["InpatientId"], "InpatientId");
                if (entity != null && string.IsNullOrWhiteSpace(entity.Creator))
                    entity.Creator = EntityOperate<GI_UserInfo>.GetEntityById(entity.Creator, "USERID").UserName;
                return new WebApi_Result() { data = entity };
            });
        }
    }
}