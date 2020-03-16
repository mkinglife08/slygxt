/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 组织机构控制器，提供页面所需要调用的方法
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

    public class OrganInfoController : BaseController
    {
        private OrganInfoService organInfoService = new OrganInfoService();

        #region 增删改查
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("组织机构保存", () =>
            {
                GI_OrganInfo entity = base.GetPageData<GI_OrganInfo>(0);
                entity.OrganID = string.IsNullOrWhiteSpace(entity.OrganID) ? null : entity.OrganID;
                entity.ParentID = string.IsNullOrWhiteSpace(entity.ParentID) ? null : entity.ParentID;
                organInfoService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取组织机构列表", () =>
            {
                TreeNodeFilter treeNodeFilter = GetPageData<TreeNodeFilter>(0);
                List<GI_OrganInfo> list = organInfoService.GetAll(treeNodeFilter).Where(f => f.IsCance != 1).ToList();
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
            return base.ExecuteActionJsonResult("获取组织机构信息", () =>
            {
                GI_OrganInfo info = EntityOperate<GI_OrganInfo>.GetEntityById(Request["ORGANID"], "ORGANID");
                return new WebApi_Result() { data = info };
            });
        }

        /// <summary>
        /// 获取最新组织机构编号，用于新增时 前端自动生成组织机构编号
        /// </summary>
        /// <returns></returns>
        public string GetOrganID()
        {
            return base.ExecuteActionJsonResult("获取最新组织机构编号", () =>
            {
                string strReturn = "";
                int lastDISPLAYSORT = EntityOperate<GI_OrganInfo>.GetLastOrderId(Request["ParentID"], "ORGANID");
                if (lastDISPLAYSORT <= 1)
                    strReturn = Request["ParentID"] + "01";
                else
                    strReturn = lastDISPLAYSORT + "";
                return new WebApi_Result() { data = strReturn };
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<GI_OrganInfo>.DeleteById(Request["OrganID"], "ORGANID");
                return new WebApi_Result() { };
            });
        }
        #endregion

        #region 树结构方法
        /// <summary>
        /// 获取所有树节点，用于一次性加载全部节点
        /// </summary>
        /// <returns></returns>
        public string GetAllTreeNode()
        {
            return base.ExecuteActionJsonResult("获取组织机构树结构", () =>
            {
                List<GI_OrganInfo> list = EntityOperate<GI_OrganInfo>.GetEntityList();
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                returnValue.Add(new TreeEntityForLayui() { name = "所有组织机构", id = "0", pid = "", open = true, children = organInfoService.CreateTreeNode(list, "0") });
                return new WebApi_Result() { data = returnValue, count = list.Count };
            });
        }

        /// <summary>
        /// 获取单一树节点下的所有子节点，用于动态加载
        /// </summary>
        /// <returns></returns>
        public string GetSingleTreeNode()
        {
            //return base.ExecuteActionJsonResult("获取组织机构树结构", () =>
            //{
                TreeNodeFilter _TreeNodeFilter = GetPageData<TreeNodeFilter>(0);
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                if (string.IsNullOrEmpty(_TreeNodeFilter.ParentID))
                {
                    _TreeNodeFilter.ParentID = "0";
                    returnValue.Add(new TreeEntityForLayui()
                    {
                        name = "所有组织机构",
                        id = "0",
                        pid = "",
                        open = true,
                        children = organInfoService.GetSingleTreeNode(_TreeNodeFilter)
                    });
                }
                else
                {
                    returnValue = organInfoService.GetSingleTreeNode(_TreeNodeFilter);
                }
                return new JavaScriptSerializer().Serialize(returnValue);
            //    return new WebApi_Result() { data = returnValue, count = 0 };
            //});
        }
        #endregion
    }
}
