/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 科室控制层
// 创建标识：盛贵明 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Public;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Public
{
    public class DeptInfoController : BaseController
    {
        private DeptInfoService service = new DeptInfoService();
        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                AI_DeptInfo entity = base.GetPageData<AI_DeptInfo>(0);
                entity.DeptID = string.IsNullOrWhiteSpace(entity.DeptID) ? null : entity.DeptID;
                entity.ParentID = string.IsNullOrWhiteSpace(entity.ParentID) ? null : entity.ParentID;
                entity.ModifyTime = DateTime.Now;
                entity.ModifyUserID = UserTokenManager.GetUserToken(Request["token"]).UserId;
                service.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<AI_DeptInfo>.DeleteById(Request["DeptID"], "DeptID");
                return new WebApi_Result() { };
            });
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {

            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                TreeNodeFilter treeNodeFilter = GetPageData<TreeNodeFilter>(0);
                List<AI_DeptInfo> list = service.GetAll(treeNodeFilter).Where(f => f.IsCance != 1).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }

         /// <summary>
         /// 获取树数据
         /// </summary>
         /// <returns></returns>
        public string GetSingleTreeNode()
        {
            List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
            if (string.IsNullOrEmpty(Request["ParentID"]))
            {
                returnValue.Add(new TreeEntityForLayui()
                {
                    name = "所有科室",
                    id = "0",
                    pid = "",
                    open = true,
                    children = service.GetSingleTreeNode("0")
                });
            }
            else
            {
                returnValue = service.GetSingleTreeNode(Request["ParentID"]);
            }
            return new JavaScriptSerializer().Serialize(returnValue);
        }

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取科室信息", () =>
            {
                AI_DeptInfo entity = EntityOperate<AI_DeptInfo>.GetEntityById(Request["DeptID"], "DeptID");
                return new WebApi_Result() { data = entity };
            });
        }

        /// <summary>
        /// 根据IsInpatient病区判别获取科室或者病区信息
        /// </summary>
        /// <returns></returns>
        public string GetDeptInfoByInpatient()
        {
            return base.ExecuteActionJsonResult("获取科室或病区信息", () =>
            {
                return new WebApi_Result() { data = service.GetDeptInfoByIsInpatient(Request["IsInpatient"], Request["keyword"]) };
            });
        }

    }
     
}