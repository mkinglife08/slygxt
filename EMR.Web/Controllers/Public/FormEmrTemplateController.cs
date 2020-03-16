/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FormEmrTemplateController.cs
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
using EMR.Services.Server.Doctor;

namespace EMR.Web.Controllers.Public
{
    public class FormEmrTemplateController : BaseController
    {

        private FormEmrService formEmrService = new FormEmrService();
        private FormEmrTemplateService formEmrTemplateService = new FormEmrTemplateService();

        #region 增删改
        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                CD_FormEmrTemplate entity = base.GetPageData<CD_FormEmrTemplate>(0);
                entity.TemplateId = string.IsNullOrWhiteSpace(entity.TemplateId) ? null : entity.TemplateId;
                entity.ParentId = string.IsNullOrWhiteSpace(entity.ParentId) ? null : entity.ParentId;
                entity.CreateTime = DateTime.Now;
                entity.Creator = UserTokenManager.GetUserToken(Request["token"]).UserId;

                formEmrTemplateService.SaveInfo(entity);
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
                EntityOperate<CD_FormEmrTemplate>.DeleteById(Request["TemplateId"], "TemplateId");
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
                List<V_FormEmrTemplate> list = formEmrTemplateService.GetAll(treeNodeFilter).Where(f => f.Del != 1).ToList();
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
                V_FormEmrTemplate entity = EntityOperate<V_FormEmrTemplate>.GetEntityById(Request["TemplateId"], "TemplateId");
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
                List<V_FormEmrTemplate> list = EntityOperate<V_FormEmrTemplate>.GetEntityList().Where(f => f.Del != 1).OrderBy(f => f.TemplateId).ToList();
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                returnValue.Add(new TreeEntityForLayui() { name = "所有结构化模板", id = "0", pid = "", open = true, children = formEmrTemplateService.CreateTreeNode(list, "0") });
                return new WebApi_Result() { data = returnValue, count = list.Count };
            });
        }


        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <returns></returns>
        public string GetSingleTreeNode()
        {
            var PARENTID = Request["PARENTID"];
            List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
            int TemplateType = 0;
            if (!int.TryParse(Request["TemplateType"], out TemplateType)) { TemplateType = 10; }//如果没有IsCategory参数的话，默认显示全部
            if (string.IsNullOrEmpty(PARENTID))
            {
                //returnValue.Add(new TreeEntityForLayui()
                //{
                //    name = "所有模板",
                //    id = "0",
                //    pid = "",
                //    open = true,
                //    children = service.GetSingleTreeNode("0")
                //});
            }
            else
            {
                List<V_FormEmrTemplate> list = EntityOperate<V_FormEmrTemplate>.GetEntityList("TemplateType=" + TemplateType).Where(f => f.Del != 1).OrderBy(f => f.TemplateId).ToList();
                switch (PARENTID)
                {
                    case "Signed": returnValue = formEmrService.GetSingleTreeNode("Signed", Request["InpatientId"], TemplateType); break;
                    case "CanUse":
                        returnValue = formEmrTemplateService.CreateTreeNode(list, "0") ; break;
                    case "all":
                        List<TreeEntityForLayui> secChild = new List<TreeEntityForLayui>();
                        secChild.Add(new TreeEntityForLayui() { name = "已签同意书", id = "Signed", pid = "all", open = true, children = formEmrService.GetSingleTreeNode("Signed", Request["InpatientId"], TemplateType) });
                        secChild.Add(new TreeEntityForLayui() { name = "可用同意书", id = "CanUse", pid = "all", open = true, children = formEmrTemplateService.CreateTreeNode(list, "0") });
                        returnValue = secChild;
                        break;
                    default:
                        returnValue  = formEmrTemplateService.GetSingleTreeNode(PARENTID); break;
                }

               
            }
            return new JavaScriptSerializer().Serialize(returnValue);
        }

        #endregion


    }

}