/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 公用代码字典控制器，提供页面所需要调用的方法
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
    public class CodeDictController : BaseController
    {
        private CodeDictService codeDictService = new CodeDictService();
        #region 增删改查
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("公用代码字典保存", () =>
            {
                GI_CodeDict entity = base.GetPageData<GI_CodeDict>(0);
                entity.DictID = string.IsNullOrWhiteSpace(entity.DictID) ? null : entity.DictID;
                entity.ParentID = string.IsNullOrWhiteSpace(entity.ParentID) ? null : entity.ParentID;
                codeDictService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取公用代码字典列表", () =>
            {
                TreeNodeFilter treeNodeFilter = GetPageData<TreeNodeFilter>(0);

                //2019年5月20日14:44:21 by-jh 把作废的字典数据也显示到前台
                //List<GI_CodeDict> list = codeDictService.GetAll(treeNodeFilter).Where(f => f.IsCance != 1).ToList();

                List<GI_CodeDict> list = codeDictService.GetAll(treeNodeFilter).ToList();
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

        public string GetChildByEName()
        {
            return base.ExecuteActionJsonResult("通过字典英文名获取子类", () =>
            {
                return new WebApi_Result() { data = codeDictService.GetChildByEName(Request["EName"]) };
            });
        }

        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取公用代码字典信息", () =>
            {
                GI_CodeDict entity = EntityOperate<GI_CodeDict>.GetEntityById(Request["DICTID"], "DICTID",true);
                return new WebApi_Result() { data = entity };
            });
        }

        public string GetLastDISPLAYSORT()
        {
            return base.ExecuteActionJsonResult("获取最新排序号", () =>
            {
                int lastDISPLAYSORT = EntityOperate<GI_CodeDict>.GetLastOrderId(Request["PARENTID"]);
                return new WebApi_Result() { data = lastDISPLAYSORT };
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<GI_CodeDict>.DeleteById(Request["DICTID"], "DICTID");
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
            return base.ExecuteActionJsonResult("获取公用代码字典树结构", () =>
            {
                List<GI_CodeDict> list = EntityOperate<GI_CodeDict>.GetEntityList().Where(f => f.IsCance != 1).OrderBy(f => f.DisplaySort).ToList();
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                returnValue.Add(new TreeEntityForLayui() { name = "所有数据字典", id = "0", pid = "", open = true, children = codeDictService.CreateTreeNode(list, "0") });
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
            if (string.IsNullOrEmpty(Request["PARENTID"]))
            {
                returnValue.Add(new TreeEntityForLayui()
                {
                    name = "所有系统功能定义",
                    id = "0",
                    pid = "",
                    open = true,
                    children = codeDictService.GetSingleTreeNode("0")
                });
            }
            else
            {
                returnValue = codeDictService.GetSingleTreeNode(Request["PARENTID"]);
            }
            return new JavaScriptSerializer().Serialize(returnValue);
        }
        #endregion
    }
}
