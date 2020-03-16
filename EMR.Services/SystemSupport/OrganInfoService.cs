/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：OrganInfoService.cs
// 文件功能描述： 组织机构服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供组织机构相关数据的服务，一般返回与组织机构相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using EMR.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMR.Services.SystemSupport
{
    public class OrganInfoService : ISerialPrimaryKey
    {
        /// <summary>
        /// 获取自增主键
        /// </summary>
        /// <param name="OrganId">组织机构ID</param>
        /// <returns>主键ID</returns>
        public string GetPrimaryId(string OrganId = "0")
        {
            return CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_ORGANINFO",ColumnName = "ORGANID",OrganID = "0" }) + "";
        }

        /// <summary>
        /// 保存组织机构数据
        /// </summary>
        /// <param name="entity">组织机构实体</param>
        public void SaveInfo(GI_OrganInfo entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.OrganID) && entity.OrganID != "null")
            {
                entity.ParentID = string.IsNullOrWhiteSpace(entity.ParentID) ? null : entity.ParentID;
                entity.UpdateM("ORGANID");
            }
            else
            {
                entity.OrganID = GetPrimaryId();
                entity.ParentID = (string.IsNullOrWhiteSpace(entity.ParentID) ? "0" : entity.ParentID);
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取组织机构数据列表
        /// </summary>
        /// <param name="_TreeNodeFilter">通用的树结构数据检索器</param>
        /// <returns></returns>
        public List<GI_OrganInfo> GetAll(TreeNodeFilter _TreeNodeFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.keyword))
                filter += string.Format(" and ORGANNAME like '%{0}%'", _TreeNodeFilter.keyword);
            filter += _TreeNodeFilter.GetQueryString();
            List<GI_OrganInfo> list = EntityOperate<GI_OrganInfo>.GetEntityList(filter);
            if (list == null || list.Count <= 0)
            {
                return new List<GI_OrganInfo>();
            }
            return list;
        }

        /// <summary>
        /// 生成树结构节点
        /// </summary>
        /// <param name="listORGANINFO">组织机构列表</param>
        /// <param name="parentID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> CreateTreeNode(List<GI_OrganInfo> listORGANINFO, string parentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            listORGANINFO.Where(s => s.ParentID == parentID).ToList().ForEach((f) =>
            {
                retValue.Add(new TreeEntityForLayui() { name = f.OrganName, id = f.OrganID, pid = f.ParentID, children = CreateTreeNode(listORGANINFO, f.OrganID) });
            });
            return retValue;
        }

        /// <summary>
        /// 获取单一树节点下的所有子节点。
        /// </summary>
        /// <param name="_TreeNodeFilter">通用的树结构数据检索器</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(TreeNodeFilter _TreeNodeFilter)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            string filter = " 1=1 "+ _TreeNodeFilter.GetQueryString();
            List<GI_OrganInfo> list = EntityOperate<GI_OrganInfo>.GetEntityList(filter);
            if (list != null && list.Count > 0)
            {
                list.Where(s => s.ParentID == _TreeNodeFilter.ParentID).ToList().ForEach((f) =>
                {
                    retValue.Add(new TreeEntityForLayui() { name = f.OrganName, id = f.OrganID, pid = f.ParentID, children = new List<TreeEntityForLayui>() });
                });
            }
            return retValue;
        }
    }
}
