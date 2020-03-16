/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 医生分组控制器，提供页面所需要调用的方法
// 创建标识：李荷 2018-12-28 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Public;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EMR.Web.Controllers.Public
{
    public class DoctorGroupController : BaseController
    {
        private DoctorGroupService doctorGroupService = new DoctorGroupService();
        #region 增删改查
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("医生分组保存", () =>
            {
                AI_DoctorGroup entity = base.GetPageData<AI_DoctorGroup>(0);
                entity.DoctorGroupId = string.IsNullOrWhiteSpace(entity.DoctorGroupId) ? null : entity.DoctorGroupId;
                entity.UpdateTime = DateTime.Now;
                entity.Updater = UserTokenManager.GetUserToken(Request["token"]).UserId;
                entity.OrganID = UserTokenManager.GetUserToken(Request["token"]).ORGANID;
                doctorGroupService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取医生分组列表", () =>
            {
                CommonFilter _CommonFilter = GetPageData<CommonFilter>(0);
                List<AI_DoctorGroup> list = doctorGroupService.GetAll(_CommonFilter).Where(f => f.Del != 1).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何医生分组数据" };
                }
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取医生分组信息", () =>
            {
                AI_DoctorGroup entity = EntityOperate<AI_DoctorGroup>.GetEntityById(Request["DOCTORGROUPID"], "DOCTORGROUPID");
                return new WebApi_Result() { data = entity };
            });
        }
        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<AI_DoctorGroup>.DeleteById(Request["DOCTORGROUPID"], "DOCTORGROUPID");
                return new WebApi_Result() { };
            });
        }


        #endregion
    }
}