/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FunInfoService.cs
// 文件功能描述： 系统功能定义服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供系统功能定义相关数据的服务，一般返回与系统功能定义相关的实体或实体集合。
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
    public class FunInfoService : ISerialPrimaryKey
    {
        /// <summary>
        /// 获取自增主键
        /// </summary>
        /// <param name="OrganId">组织机构ID</param>
        /// <returns>主键ID</returns>
        public string GetPrimaryId(string OrganId = "0")
        {
            return CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_FUNINFO",ColumnName = "FUNID",OrganID = OrganId }) + "";
        }

        /// <summary>
        /// 保存系统功能定义数据
        /// </summary>
        /// <param name="entity">系统功能定义实体</param>
        public void SaveInfo(GI_FunInfo entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.FUNID) && entity.FUNID != "null")
            {
                entity.UpdateM("FUNID");
            }
            else
            {
                entity.FUNID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_FunInfo", ColumnName = "FUNID", OrganID = entity.OrganID }) + "";
                entity.ParentID = (string.IsNullOrWhiteSpace(entity.ParentID) ? "0" : entity.ParentID);
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取系统功能定义数据列表
        /// </summary>
        /// <param name="_TreeNodeFilter">通用的树结构数据检索器</param>
        /// <returns></returns>
        public List<V_FunInfo> GetAll(TreeNodeFilter _TreeNodeFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.keyword))
                filter += string.Format(" and FUNNAME like '%{0}%'", _TreeNodeFilter.keyword);
            if ((_TreeNodeFilter.ParentID + "").Contains("MODULE_"))
                filter += " and SYSID = '" + _TreeNodeFilter.ParentID.Replace("MODULE_", "") + "'";
            else
                filter += _TreeNodeFilter.GetQueryString();
            List<V_FunInfo> list = EntityOperate<V_FunInfo>.GetEntityList(filter, "PARENTID,DISPLAYSORT");
            if (list == null || list.Count <= 0)
            {
                return new List<V_FunInfo>();
            }
            list.ForEach((f) =>
            {
                f.IsLastName = f.IsLast == 0 ? "非未级" : "是未级";
                f.IsShowName = f.IsShow == 0 ? "不显示" : "显示";
            });
            return list;
        }

        /// <summary>
        /// 生成树结构节点
        /// </summary>
        /// <param name="listFUNINFO">系统功能定义数据列表</param>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> CreateTreeNode(List<GI_FunInfo> listFUNINFO, string PARENTID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            listFUNINFO.Where(s => s.ParentID == PARENTID).ToList().ForEach((f) =>
            {
                retValue.Add(new TreeEntityForLayui() { name = f.FUNName, id = f.FUNID, pid = f.ParentID, children = CreateTreeNode(listFUNINFO, f.FUNID) });
            });
            return retValue;
        }

        /// <summary>
        /// 获取与用户分组相关的系统功能定义树结构
        /// </summary>
        /// <param name="listFUNINFO">系统功能定义数据列表</param>
        /// <param name="listROLERIGHT">用户权限数据列表</param>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> CreateRoleTreeNode(List<GI_FunInfo> listFUNINFO, List<GI_RoleRight> listROLERIGHT, string parentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            listFUNINFO.Where(s => s.ParentID == parentID).ToList().ForEach((f) =>
            {
                TreeEntityForLayui tree = new TreeEntityForLayui() { name =f.FUNName, id = f.FUNID, pid = f.ParentID };
                if (f.IsLast.Value != 1)
                    tree.children = CreateRoleTreeNode(listFUNINFO, listROLERIGHT, f.FUNID);
                retValue.Add(tree);
            });
            if (listROLERIGHT != null && listROLERIGHT.Count > 0)
            {
                retValue.ForEach(e =>
                {
                    if (listROLERIGHT.Where(f => f.FUNID == e.id).Count() > 0)
                        e.@checked = true;
                });
            }
            return retValue;
        }

        /// <summary>
        /// 获取单一树节点下的所有子节点，用于动态加载
        /// </summary>
        /// <param name="parentID">父级ID</param>
        /// <param name="roleID">用户分组ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(string parentID, string roleID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<GI_FunInfo> list = EntityOperate<GI_FunInfo>.GetEntityList(" PARENTID = '" + parentID + "'", "DISPLAYSORT").Where(f => f.IsCance != 1).ToList();
            list.Where(s => s.ParentID == parentID).ToList().ForEach((f) =>
            {
                TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.FUNName, id = f.FUNID, pid = f.ParentID, remark = f.SYSID };
                if (f.IsLast != 1)//如果不是末级，则加子级
                    tree.children = new List<TreeEntityForLayui>();
                retValue.Add(tree);
            });
            if (!string.IsNullOrWhiteSpace(roleID))
            {
                List<GI_RoleRight> list_ROLERIGHT = EntityOperate<GI_RoleRight>.GetEntityList("ROLEID = '" + roleID + "'");
                if (list_ROLERIGHT != null && list_ROLERIGHT.Count > 0)
                {
                    retValue.ForEach(e =>
                    {
                        if (list_ROLERIGHT.Where(f => f.FUNID == e.id).Count() > 0)
                            e.@checked = true;
                    });
                }
            }
            return retValue;
        }

        /// <summary>
        /// 根据系统模块ID，获取单一树节点下的所有子节点，用于动态加载
        /// </summary>
        /// <param name="SYSID">系统模块ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNodeBySYSID(string SYSID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<GI_FunInfo> list = EntityOperate<GI_FunInfo>.GetEntityList(" parentid='0' and SYSID = '" + SYSID + "'", "DISPLAYSORT").Where(f => f.IsCance != 1).ToList();
            list.ToList().ForEach((f) =>
            {
                TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.FUNName, id = f.FUNID, pid = f.ParentID, remark = f.SYSID };
                if (f.IsLast != 1)//如果不是末级，则加子级
                    tree.children = new List<TreeEntityForLayui>();
                retValue.Add(tree);
            });
            return retValue;
        }

        /// <summary>
        /// 根据系统模块ID，获取与用户分组相关的系统功能定义树结构
        /// </summary>
        /// <param name="listFUNINFO">系统功能定义数据列表</param>
        /// <param name="listROLERIGHT">用户权限数据列表</param>
        /// <param name="SYSID">系统模块ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetRoleTreeNodeBySYSID(List<GI_FunInfo> listFUNINFO, List<GI_RoleRight> listROLERIGHT, string SYSID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            listFUNINFO.Where(f => f.ParentID == "0" && f.SYSID == SYSID).ToList().ForEach((f) =>
                 {
                     TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.FUNName, id = f.FUNID, pid = f.ParentID, remark = f.SYSID };
                     tree.children = CreateRoleTreeNode(listFUNINFO, listROLERIGHT, f.FUNID);
                     retValue.Add(tree);
                 });
            if (listROLERIGHT != null && listROLERIGHT.Count > 0)
            {
                retValue.ForEach(e =>
                {
                    if (listROLERIGHT.Where(f => f.FUNID == e.id).Count() > 0)
                        e.@checked = true;
                });
            }
            return retValue;
        }
    }
}
