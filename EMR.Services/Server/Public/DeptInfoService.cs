/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 科室控制层
// 创建标识：盛贵明 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Domain;
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
   public class DeptInfoService
    {
        /// <summary>
        /// 增加和保存
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(AI_DeptInfo entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.DeptID) && entity.DeptID != "null")
            {
                entity.UpdateM("DeptID");
            }
            else
            {
                entity.DeptID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "AI_DEPTINFO", ColumnName = "DeptID", OrganID = entity.OrganID }) + "";
                entity.ParentID = (string.IsNullOrWhiteSpace(entity.ParentID) ? "0" : entity.ParentID);
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <param name="_TreeNodeFilter">过滤条件</param>
        /// <returns></returns>
        public List<AI_DeptInfo> GetAll(TreeNodeFilter _TreeNodeFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.ParentID))
                filter += string.Format("  and ParentID='{0}'", _TreeNodeFilter.ParentID);
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.keyword))
                filter += string.Format(" and (DEPTNAME like '%{0}%' or SpellCode like '%{0}%') ", _TreeNodeFilter.keyword);
            List<AI_DeptInfo> list = EntityOperate<AI_DeptInfo>.GetEntityList(filter, "ParentID,DeptID");
            if (list == null || list.Count <= 0)
            {
                return new List<AI_DeptInfo>();
            }
            list.ForEach((f) =>
            {
                f.IsInpatientName = f.IsInpatient == 0 ? "不是" : "是";
                f.IsCanceName = f.IsCance != 1 ? "正常" : "作废";
            });
            return list;
        }


        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <param name="ParentID">父类ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(string ParentID)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<AI_DeptInfo> list = EntityOperate<AI_DeptInfo>.GetEntityList(" ParentID = '" + ParentID + "'", "DeptID").Where(f => f.IsCance != 1).ToList();
            if (list != null && list.Count > 0)
            {
                list.Where(s => s.ParentID == ParentID).ToList().ForEach((f) =>
                {
                    TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.DeptName, id = f.DeptID, pid = f.ParentID };
                    //if (f.ISLAST != 1)//如果不是末级，则加子级
                    //    tree.children = new List<TreeEntityForLayui>();
                    retValue.Add(tree);
                });
            }
            return retValue;
        }


        /// <summary>
        /// 通过病区判别获得科室或者病区
        /// </summary>
        /// <param name="IsInpatient">0科室，1病区</param>
        /// <returns></returns>
        public List<AI_DeptInfo> GetDeptInfoByIsInpatient(string IsInpatient,string keyword = "")
        {
            //如果IsInpatient传空，则查询所有的数据
            string filter = string.IsNullOrWhiteSpace(IsInpatient)?"": " IsInpatient="+ IsInpatient +" and ";
            filter += string.IsNullOrWhiteSpace(keyword) ? "" : " (DeptName like '%"+ keyword + "%' or SpellCode like '%"+ keyword.ToUpper() + "%') and";
            List<AI_DeptInfo> list = EntityOperate<AI_DeptInfo>.GetEntityList(" "+ filter + " IsCance=0 ", "DeptID");
            return list;
        }

        #region 用户科室对照

        /// <summary>
        /// 根据用户id查找关联的科室（病区）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public List<AI_DeptInfo> GetDeptInfoByUserId(string UserId) {
            List<AI_DeptInfo> list= EntityOperate<AI_DeptInfo>.GetEntityList(" DeptID in (select DeptID from AI_UserDept where Userid='"+UserId+"')");
            return list;
        }
        #endregion
    }
}
