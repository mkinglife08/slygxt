/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 系统用户分组控制器，提供页面所需要调用的方法
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace EMR.Web.Controllers.SystemSupport
{
    
    public class RoleController : BaseController
    {
        private RoleService roleService = new RoleService();

        #region 增删改查
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("系统用户分组保存", () =>
            {
                GI_Role entity = base.GetPageData<GI_Role>(0);
                roleService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取系统用户分组列表", () =>
            {
                CommonFilter _CommonFilter = GetPageData<CommonFilter>(0);
                List<GI_Role> list = roleService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();
                if (list == null || list.Count() <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0,limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage>0?limit * (curpage - 1):0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit),count =list.Count };
            });
        }

        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取系统用户分组信息", () =>
            {
                GI_Role list = EntityOperate<GI_Role>.GetEntityBySQL("select * from GI_ROLE where ROLEID = '" + Request["RoleID"] +"'");
                return new WebApi_Result() { data = list };
            });
        }

        public string Delete() {
            return base.ExecuteActionJsonResult("删除分组信息", () =>
            {
                EntityOperate<GI_UserInfo>.DeleteById(Request["RoleID"], "ROLEID");
                return new WebApi_Result() {  };
            });
        }
        #endregion

        #region 系统分组权限

        public string SaveRoleRight()
        {
            return base.ExecuteActionJsonResult("系统分组权限保存", () =>
            {
                roleService.SaveRoleRight(Request["ROLEID"], Request["role_funinfo_check"]);
                return new WebApi_Result();
            });
        }
        #endregion
    }
}
