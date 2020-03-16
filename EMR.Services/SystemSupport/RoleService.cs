/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：RoleService.cs
// 文件功能描述： 用户分组（用户角色）服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供用户分组相关数据的服务，一般返回与用户分组相关的实体或实体集合。
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

namespace EMR.Services.SystemSupport
{
    public class RoleService
    {
        /// <summary>
        /// 保存系统用户分组数据
        /// </summary>
        /// <param name="entity">用户分组实体</param>
        public void SaveInfo(GI_Role entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.RoleID) && entity.RoleID != "null")
            {
                entity.UpdateM("ROLEID");
            }
            else
            {
                entity.RoleID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_ROLE", ColumnName = "ROLEID", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取系统用户分组数据列表
        /// </summary>
        /// <param name="commonFilter">通用的数据检索器</param>
        /// <returns>系统用户分组数据列表</returns>
        public List<GI_Role> GetAll(CommonFilter commonFilter)
        {
            string Filter = "1=1";
            if (!string.IsNullOrWhiteSpace(commonFilter.keyword))
                Filter += string.Format(" and ROLENAME like '%{0}%'", commonFilter.keyword);
            Filter += commonFilter.GetQueryString();
            List<GI_Role> list = EntityOperate<GI_Role>.GetEntityList(Filter);
            if (list == null || list.Count <= 0)
            {
                return new List<GI_Role>();
            }
            list.ForEach((f) =>
            {
                if (!string.IsNullOrWhiteSpace( f.RolePower ))
                {
                    f.PowerName = "";
                    foreach (string each in f.RolePower.Split(','))
                    {
                        switch (each)
                        {
                            case "1":
                                f.PowerName += "查看,";
                                break;
                            case "2":
                                f.PowerName += "编辑,";
                                break;
                            case "3":
                                f.PowerName += "删除,";
                                break;
                            case "4":
                                f.PowerName += "打印,";
                                break;
                            case "5":
                                f.PowerName += "授权,";
                                break;
                        }
                    }
                    f.PowerName = f.PowerName.Trim(',');
                }
            });
            return list;
        }

        #region 系统分组权限
        /// <summary>
        /// 获取系统分组权限
        /// </summary>
        /// <param name="roleid">分组ID</param>
        /// <returns>分组权限列表</returns>
        public List<GI_RoleRight> GetRoleRight(string roleid)
        {
            string filter = "ROLEID = '" + roleid + "'";
            List<GI_RoleRight> list_ROLERIGHT = EntityOperate<GI_RoleRight>.GetEntityList(filter);
            return list_ROLERIGHT;
        }

        /// <summary>
        /// 保存系统分组权限
        /// </summary>
        /// <param name="roleid">分组ID</param>
        /// <param name="fun">功能序号字符串，多个ID以逗号隔开</param>
        public void SaveRoleRight(string roleid, string fun)
        {
            EntityOperate<GI_RoleRight>.DeleteByFilter("ROLEID = '" + roleid + "'");
            if (!string.IsNullOrWhiteSpace(fun))
            {
                foreach (string each in fun.Trim(',').Split(','))
                {
                    GI_RoleRight _roleright = new GI_RoleRight() { FUNID = each, RoleID = roleid };
                    _roleright.SaveModelM();
                }
            }
        }
        #endregion
    }
}
