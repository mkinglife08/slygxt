/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictService.cs
// 文件功能描述： 公用代码字典服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供公用代码字典相关数据的服务，一般返回与公用代码字典相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMR.Services.SystemSupport
{
    public class CodeDictService
    {
        /// <summary>
        /// 保存公用代码字典数据
        /// </summary>
        /// <param name="entity">公用代码字典实体</param>
        public void SaveInfo(GI_CodeDict entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.DictID) && entity.DictID != "null")
            {
                entity.UpdateM("DictID");
            }
            else
            {
                entity.DictID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_CodeDict", ColumnName = "DictID", OrganID = entity.OrganID }) + "";
                entity.ParentID = (string.IsNullOrWhiteSpace(entity.ParentID) ? "0" : entity.ParentID);
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取公用代码字典列表
        /// </summary>
        /// <param name="_TreeNodeFilter">通用的树结构数据检索器</param>
        /// <returns></returns>
        public List<GI_CodeDict> GetAll(TreeNodeFilter _TreeNodeFilter)
        {
            string filter = "1=1";
            //关键词搜索
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.keyword))
                filter += string.Format(" and (DICTNAME like '%{0}%' or DICTNAMEEN like '%{0}%' or DictCode='{0}' or SPELLCODE like '%{1}%')", _TreeNodeFilter.keyword, _TreeNodeFilter.keyword.ToUpper());
            //根据父类的英文名搜索子类
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.ParentDictNameEN))
                filter += string.Format(" and ParentID in (select DictID from GI_CODEDICT where DictNameEN = '{0}')", _TreeNodeFilter.ParentDictNameEN);

            filter += _TreeNodeFilter.GetQueryString();
            List<GI_CodeDict> list = EntityOperate<GI_CodeDict>.GetEntityList(filter, "PARENTID,DISPLAYSORT",true);
            if (list == null || list.Count <= 0)
            {
                return new List<GI_CodeDict>();
            }
            list.ForEach((f) =>
            {
                f.IsLastName = f.ISLast == 0 ? "非未级" : "是未级";
                f.IsCanceName = f.IsCance != 1 ? "正常" : "作废";
            });
            return list;
        }

        /// <summary>
        /// 生成树结构节点
        /// </summary>
        /// <param name="list">公用代码字典数据列表</param>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> CreateTreeNode(List<GI_CodeDict> list, string ParentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            list.Where(s => s.ParentID == ParentID).ToList().ForEach((f) =>
            {
                TreeEntityForLayui treeNode = new TreeEntityForLayui() { name = f.DictName, id = f.DictID, pid = f.ParentID, children = CreateTreeNode(list, f.DictID) };
                retValue.Add(treeNode);
            });
            return retValue;
        }

        /// <summary>
        /// 获取单一树节点下的所有子节点，用于动态加载
        /// </summary>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(string ParentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<GI_CodeDict> list = EntityOperate<GI_CodeDict>.GetEntityList(" PARENTID = '" + ParentID + "'", "DISPLAYSORT").Where(f => f.IsCance != 1).ToList();
            if (list != null && list.Count > 0)
            {
                list.Where(s => s.ParentID == ParentID).ToList().ForEach((f) =>
                {
                    TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.DictName, id = f.DictID, pid = f.ParentID };
                    if (f.ISLast != 1)//如果不是末级，则加子级
                        tree.children = new List<TreeEntityForLayui>();
                    retValue.Add(tree);
                });
            }
            return retValue;
        }

        /// <summary>
        /// 通过字典英文名获取子类
        /// </summary>
        /// <param name="DictEName"></param>
        /// <returns></returns>
        public List<GI_CodeDict> GetChildByEName(string DictEName)
        {
            List<GI_CodeDict> list = EntityOperate<GI_CodeDict>.GetEntityList("ParentID in (select DictID from GI_CODEDICT where DictNameEN = '" + DictEName + "')", "DisplaySort,DICTID");
            return list;
        }

        /// <summary>
        /// 通过DictID获取实体类
        /// </summary>
        /// <param name="DictID"></param>
        /// <returns></returns>
        public GI_CodeDict GetCodeDictByDictID(string DictID) {
            GI_CodeDict entity = EntityOperate<GI_CodeDict>.GetEntityById(DictID, "DictID");
            return entity;
        }

        /// <summary>
        /// 根据字典编码和父类字典英文名获取实体
        /// </summary>
        /// <param name="DictCode"></param>
        /// <param name="DictEName"></param>
        /// <returns></returns>
        public GI_CodeDict GetCodeDictByDictCodeAndEName(string DictCode,string DictEName)
        {
            GI_CodeDict entity = EntityOperate<GI_CodeDict>.GetEntityBySQL("select * from GI_CodeDict where DictCode='" + DictCode + "' and ParentID in (select DictID from GI_CODEDICT where DictNameEN = '" + DictEName + "')");
            return entity;
        }

    }
}
