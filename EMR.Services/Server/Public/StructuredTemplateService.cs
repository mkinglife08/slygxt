﻿/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 结构化模板控制层
// 创建标识：朱天文 2019-01-02
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.SystemSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Server.Public
{
    public class StructuredTemplateService
    {
        #region 增删改
        /// <summary>
        /// 增加和保存
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(AI_StructuredTemplate entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.TemplateId) && entity.TemplateId != "null")
            {
                entity.UpdateM("TemplateId");
            }
            else
            {
                entity.TemplateId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "AI_StructuredTemplate", ColumnName = "TemplateId", OrganID = entity.OrganID }) + "";
                entity.ParentTempId = (string.IsNullOrWhiteSpace(entity.ParentTempId) ? "0" : entity.ParentTempId);
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <param name="_TreeNodeFilter">过滤条件</param>
        /// <returns></returns>
        public List<V_StructuredTemplate> GetAll(TreeNodeFilter _TreeNodeFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.ParentID))
                filter += string.Format("  and ParentTempId='{0}'", _TreeNodeFilter.ParentID);
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.keyword))
                filter += string.Format(" and (TemplateName like '%{0}%') ", _TreeNodeFilter.keyword);
            List<V_StructuredTemplate> list = EntityOperate<V_StructuredTemplate>.GetEntityList(filter, "ParentTempId,TemplateId");
            if (list == null || list.Count <= 0)
            {
                return new List<V_StructuredTemplate>();
            }
            list.ForEach((f) =>
            {
                f.DelName = f.Del != 1 ? "正常" : "作废";
                f.IsCategoryName = f.IsCategory != 1 ? "非末级" : "末级";
            });
            return list;
        }

        #endregion

        #region 树结构
        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <param name="ParentID">父类ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(string ParentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<V_StructuredTemplate> list = EntityOperate<V_StructuredTemplate>.GetEntityList(" ParentTempId = '" + ParentID + "'", "TemplateId").Where(f => f.Del != 1).ToList();
            if (list != null && list.Count > 0)
            {
                list.Where(s => s.ParentTempId == ParentID).ToList().ForEach((f) =>
                {
                    TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.TemplateName, id = f.TemplateId, pid = f.ParentTempId };
                    //if (f.ISLAST != 1)//如果不是末级，则加子级
                    //    tree.children = new List<TreeEntityForLayui>();
                    retValue.Add(tree);
                });
            }
            return retValue;
        }

        /// <summary>
        /// 生成树结构节点
        /// </summary>
        /// <param name="list">公用代码字典数据列表</param>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> CreateTreeNode(List<V_StructuredTemplate> list, string ParentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            list.Where(s => s.ParentTempId == ParentID).ToList().ForEach((f) =>
            {
                TreeEntityForLayui treeNode = new TreeEntityForLayui() { name = f.TemplateName, id = f.TemplateId, pid = f.ParentTempId, children = CreateTreeNode(list, f.TemplateId) };
                retValue.Add(treeNode);
            });
            return retValue;
        }

        #endregion
    }
}
