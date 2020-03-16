/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：StructuredTemplateController.cs
// 文件功能描述： 结构化模板控制层
// 创建标识：朱天伟 2019-01-02 
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
    public class StructuredTemplateController : BaseController
    {
        private StructuredTemplateService service = new StructuredTemplateService();

        #region 增删改
        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                AI_StructuredTemplate entity = base.GetPageData<AI_StructuredTemplate>(0);
                entity.TemplateId = string.IsNullOrWhiteSpace(entity.TemplateId) ? null : entity.TemplateId;
                entity.ParentTempId = string.IsNullOrWhiteSpace(entity.ParentTempId) ? null : entity.ParentTempId;
                entity.CreateTime = DateTime.Now;
                entity.Creator = UserTokenManager.GetUserToken(Request["token"]).UserId;

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
                EntityOperate<AI_StructuredTemplate>.DeleteById(Request["TemplateId"], "TemplateId");
                return new WebApi_Result() { };
            });
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                TreeNodeFilter treeNodeFilter = GetPageData<TreeNodeFilter>(0);
                List<V_StructuredTemplate> list = service.GetAll(treeNodeFilter).Where(f => f.Del != 1).ToList();
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
        /// 根据ID获取数据
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取信息", () =>
            {
                V_StructuredTemplate entity = EntityOperate<V_StructuredTemplate>.GetEntityById(Request["TemplateId"], "TemplateId");
                return new WebApi_Result() { data = entity };
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
            return base.ExecuteActionJsonResult("获取结构化模板树结构", () =>
            {
                int IsCategory = 0;
                if (!int.TryParse(Request["IsCategory"], out IsCategory)) { IsCategory = 3; }//如果没有IsCategory参数的话，默认显示全部
                List<V_StructuredTemplate> list = EntityOperate<V_StructuredTemplate>.GetEntityList().Where(f => f.Del != 1&&f.IsCategory!= IsCategory).OrderBy(f => f.TemplateId).ToList();
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                returnValue.Add(new TreeEntityForLayui() { name = "所有结构化模板", id = "0", pid = "", open = true, children = service.CreateTreeNode(list, "0") });
                return new WebApi_Result() { data = returnValue, count = list.Count };
            });
        }


        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <returns></returns>
        public string GetSingleTreeNode()
        {
            List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
            if (string.IsNullOrEmpty(Request["ParentTempId"]))
            {
                returnValue.Add(new TreeEntityForLayui()
                {
                    name = "所有模板",
                    id = "0",
                    pid = "",
                    open = true,
                    children = service.GetSingleTreeNode("0")
                });
            }
            else
            {
                returnValue = service.GetSingleTreeNode(Request["ParentTempId"]);
            }
            return new JavaScriptSerializer().Serialize(returnValue);
        }

        #endregion


    }

}