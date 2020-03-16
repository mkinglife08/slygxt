/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：DoctorGroupService.cs
// 文件功能描述： 医生分组服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供医生分组相关数据的服务，一般返回与医生分组相关的实体或实体集合。
// 创建标识：李荷 2018-12-28 
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

namespace EMR.Services.Server.Public
{
    public class DoctorGroupService
    {
        /// <summary>
        /// 获取自增主键
        /// </summary>
        /// <param name="OrganId">组织机构ID</param>
        /// <returns>主键ID</returns>
        public string GetPrimaryId(string OrganId = "0")
        {
            return CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "AI_DoctorGroup", ColumnName = "DoctorGroupId", OrganID = OrganId }) + "";
        }
        /// <summary>
        /// 保存医生分组数据
        /// </summary>
        /// <param name="entity">医生分组实体</param>
        public void SaveInfo(AI_DoctorGroup entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.DoctorGroupId) && entity.DoctorGroupId != "null")
            {
                entity.UpdateM("DoctorGroupId");
            }
            else
            {
                entity.CreateTime = entity.UpdateTime;
                entity.Creator = entity.Creator;
                entity.DoctorGroupId = GetPrimaryId();
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取医生分组列表
        /// </summary>
        /// <param name="CommonFilter"></param>
        /// <returns></returns>
        public List<AI_DoctorGroup> GetAll(CommonFilter commonFilter)
        {
            string Filter = " 1= 1";
            if (!string.IsNullOrWhiteSpace(commonFilter.keyword))
                Filter += string.Format(" and (GROUPNAME like '%{0}%' or GROUPNUM like '%{0}%')", commonFilter.keyword);
            Filter += commonFilter.GetQueryString();
            List<AI_DoctorGroup> list = EntityOperate<AI_DoctorGroup>.GetEntityList(Filter).FindAll(f => f.Del != 1);
            if (list == null || list.Count <= 0)
            {
                return new List<AI_DoctorGroup>();
            }
            return list;
        }

        /// <summary>
        /// 生成树结构节点
        /// </summary>
        /// <param name="list">医生分组数据列表</param>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> CreateTreeNode(List<AI_DoctorGroup> list, string DeptId)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            list.Where(s => s.DeptId == DeptId).ToList().ForEach((f) =>
            {
                TreeEntityForLayui treeNode = new TreeEntityForLayui() { name = f.GroupName, id = f.DoctorGroupId, pid = f.DeptId, children = CreateTreeNode(list, f.DoctorGroupId) };
                retValue.Add(treeNode);
            });
            return retValue;
        }

        /// <summary>
        /// 获取单一树节点下的所有子节点，用于动态加载
        /// </summary>
        /// <param name="PARENTID">父级ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(string DeptId)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<AI_DoctorGroup> list = EntityOperate<AI_DoctorGroup>.GetEntityList(" DEPTID = '" + DeptId + "'", "DISPLAYSORT").Where(f => f.Del != 1).ToList();
            if (list != null && list.Count > 0)
            {
                list.Where(s => s.DeptId == DeptId).ToList().ForEach((f) =>
                {
                    TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.GroupName, id = f.DoctorGroupId, pid = f.DeptId };
                    //if (f.ISLast != 1)//如果不是末级，则加子级
                    //    tree.children = new List<TreeEntityForLayui>();
                    retValue.Add(tree);
                });
            }
            return retValue;
        }


        #region 用户医生组对照

        /// <summary>
        /// 根据用户id查找关联的医生组
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<AI_DoctorGroup> GetDoctorGroupByUserId(string UserId)
        {
            List<AI_DoctorGroup> list = EntityOperate<AI_DoctorGroup>.GetEntityList(" DoctorGroupId in (select DoctorGroupId from AI_GroupMember where Member='" + UserId + "')");
            return list;
        }
        #endregion
    }
}
