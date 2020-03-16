/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FunInfoController.cs
// 文件功能描述： 系统功能定义控制器，提供页面所需要调用的方法
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
using System.Web.Script.Serialization;

namespace EMR.Web.Controllers.SystemSupport
{

    public class FunInfoController : BaseController
    {
        private FunInfoService funInfoService = new FunInfoService();
        #region 增删改查
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("系统功能定义保存", () =>
            {
                GI_FunInfo entity = base.GetPageData<GI_FunInfo>(0);
                entity.FUNID = string.IsNullOrWhiteSpace(entity.FUNID) ? null : entity.FUNID;
                entity.ParentID = string.IsNullOrWhiteSpace(entity.ParentID) ? null : entity.ParentID;
                funInfoService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取系统功能定义列表", () =>
            {
                TreeNodeFilter treeNodeFilter = GetPageData<TreeNodeFilter>(0);
                List<V_FunInfo> list = funInfoService.GetAll(treeNodeFilter).Where(f => f.IsCance != 1).ToList();
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

        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取系统功能定义信息", () =>
            {
                GI_FunInfo list = EntityOperate<GI_FunInfo>.GetEntityById(Request["FUNID"], "FUNID");
                return new WebApi_Result() { data = list };
            });
        }

        public string GetLastDISPLAYSORT()
        {
            return base.ExecuteActionJsonResult("获取最新排序号", () =>
            {
                int lastDISPLAYSORT = EntityOperate<GI_FunInfo>.GetLastOrderId(Request["PARENTID"]);
                return new WebApi_Result() { data = lastDISPLAYSORT };
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<GI_FunInfo>.DeleteById(Request["FUNID"], "FUNID");
                return new WebApi_Result() { };
            });
        }
        #endregion

        #region 树结构方法
        /// <summary>
        /// 获取所有树节点，用于一次性加载全部节点
        /// </summary>
        /// <returns></returns>
        public string GetTreeNode()
        {
            return base.ExecuteActionJsonResult("获取系统功能定义树结构", () =>
            {
                List<GI_SYSAPPINFO> list = EntityOperate<GI_SYSAPPINFO>.GetEntityList("", "DISPLAYSORT").Where(f => f.IsCance != 1).ToList();
                var childrenNode = new List<TreeEntityForLayui>();
                list.ForEach((f) =>
                {
                    childrenNode.Add(new TreeEntityForLayui() { name = f.SYSName, id = "MODULE_" + f.SYSID, pid = "MODULE_0", open = true, children = funInfoService.GetSingleTreeNodeBySYSID(f.SYSID) });
                });
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                returnValue.Add(new TreeEntityForLayui() { name = "所有系统功能定义", id = "0", pid = "", open = true, children = childrenNode });
                return new WebApi_Result() { data = returnValue, count = list.Count };
            });
        }

        /// <summary>
        /// 获取单一树节点下的所有子节点，用于动态加载
        /// </summary>
        /// <returns></returns>
        public string GetSingleTreeNode()
        {
            List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
            if (string.IsNullOrEmpty(Request["ParentID"]))
            {
                TreeEntityForLayui topNode = new TreeEntityForLayui()
                {
                    name = "所有系统功能定义",
                    id = "0",
                    pid = "",
                    open = true,
                    children = funInfoService.GetSingleTreeNode("0", Request["RoleID"])
                };
                topNode.@checked = topNode.children.Where(f => f.@checked).Count() > 0;
                returnValue.Add(topNode);
            }
            else if (Request["ParentID"].Contains("MODULE_"))
            {
                returnValue = funInfoService.GetSingleTreeNodeBySYSID(Request["ParentID"].Replace("MODULE_", ""));
            }
            else
            {
                //string parentid = string.IsNullOrEmpty(Request["PARENTID"]) ? "0" : Request["PARENTID"];
                returnValue = funInfoService.GetSingleTreeNode(Request["ParentID"], Request["RoleID"]);
            }
            return new JavaScriptSerializer().Serialize(returnValue);
        }

        /// <summary>
        /// 获取与用户分组相关的系统功能定义树结构
        /// </summary>
        /// <returns></returns>
        public string GetRoleTreeNode()
        {
            return base.ExecuteActionJsonResult("获取系统功能定义树结构", () =>
            {
                List<GI_FunInfo> list = EntityOperate<GI_FunInfo>.GetEntityList("", "DISPLAYSORT").Where(f => f.IsCance != 1).ToList();
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();

                List<GI_RoleRight> listROLERIGHT = new List<GI_RoleRight>();
                if (!string.IsNullOrWhiteSpace(Request["RoleID"]))
                {
                    listROLERIGHT = EntityOperate<GI_RoleRight>.GetEntityList("RoleID = '" + Request["RoleID"] + "'");
                }
                var childrenNode = new List<TreeEntityForLayui>();
                List<GI_SYSAPPINFO> listSYSAPPINFO = EntityOperate<GI_SYSAPPINFO>.GetEntityList("", "DISPLAYSORT").Where(f => f.IsCance != 1).ToList();
                listSYSAPPINFO.ForEach((f) =>
                {
                    TreeEntityForLayui treeEntity = new TreeEntityForLayui() { name = f.SYSName, id = "MODULE_" + f.SYSID, pid = "MODULE_0", open = true, children = funInfoService.GetRoleTreeNodeBySYSID(list, listROLERIGHT, f.SYSID), @checked = listROLERIGHT.Where(e => e.FUNID == "MODULE_" + f.SYSID).Count() > 0 };
                    childrenNode.Add(treeEntity);

                });
                returnValue.Add(new TreeEntityForLayui() { name = "所有系统功能定义", id = "0", pid = "", open = true, children = childrenNode });
                return new WebApi_Result() { data = returnValue, count = list.Count };
            });
        }
        #endregion
    }
}
