/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 科室控制层
// 创建标识：盛贵明 2018-12-10 
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
   public class UserInfoService
    {
        /// <summary>
        /// 部门服务类
        /// </summary>
        DeptInfoService deptinfoservice = new DeptInfoService();

        /// <summary>
        /// 增加和保存
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(GI_UserInfo entity)
        {
            string[] dpetlist=new string[] { } ;//科室
            string[] inpatientlist = new string[] { };//病区
            string[] medicallist = new string[] { };//医疗组
            //科室
            if (!string.IsNullOrWhiteSpace(entity.DpetID))
            {
                dpetlist = entity.DpetID.Split(',');
                entity.DpetID = dpetlist[0];//默认科室
            }
            //病区
            if (!string.IsNullOrWhiteSpace(entity.InpatientID))
            {
                inpatientlist = entity.InpatientID.Split(',');
                entity.InpatientID = inpatientlist[0];//默认病区
            }
            //医疗组
            if (!string.IsNullOrWhiteSpace(entity.MedicalID))
            {
                medicallist = entity.MedicalID.Split(',');
                entity.MedicalID = medicallist[0];//默认医疗组
            }
            //状态为正常
            entity.IsCance = 0;
            //保存或修改
            if (!string.IsNullOrWhiteSpace(entity.UserID) && entity.UserID != "null")
            {
                entity.UpdateM("UserID");
            }
            else
            {
                entity.UserID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_UserInfo", ColumnName = "UserID", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }

            #region 科室，病区关联
            //删除用户关联科室，重新关联
            EntityOperate<AI_UserDept>.DeleteByFilter(" UserID='"+entity.UserID+ "' ");
            //添加科室关联
            for (int i = 0; i < dpetlist.Length; i++) {
                AI_UserDept userdept = new AI_UserDept() { UserID = entity.UserID, DeptID = dpetlist[i], TypeCode = 1, DisplaySort = i };
                userdept.SaveModelM();
            }
            //添加病区关联
            for (int i = 0; i < inpatientlist.Length; i++)
            {
                AI_UserDept userdept = new AI_UserDept() { UserID = entity.UserID, DeptID = inpatientlist[i], TypeCode = 2, DisplaySort = i };
                userdept.SaveModelM();
            }
            #endregion
            #region 医疗组
            //获得该用户的医疗组
            DoctorGroupService doctorgroupService = new DoctorGroupService();
            List<AI_DoctorGroup> userDoctorGroupList= doctorgroupService.GetDoctorGroupByUserId(entity.UserID);
            string[] userDoctorGroup = (from u in userDoctorGroupList select u.DoctorGroupId).ToArray();
            foreach (var item in userDoctorGroup) {
                if (!((IList<string>)medicallist).Contains(item)) {
                    //保存的医疗组中不包含该医疗组对照表中-删除对照表中的信息
                    EntityOperate<AI_GroupMember>.DeleteByFilter(" DoctorGroupId='"+item+ "' and Member='"+ entity.UserID + "' ");
                }
            }
            foreach (var item in medicallist)
            {
                if (!((IList<string>)userDoctorGroup).Contains(item))
                {
                    //数据库中的医疗组对照表不包含该医疗组id-添加对照
                    AI_GroupMember groupMember = new AI_GroupMember() { DoctorGroupId = item , Member =entity.UserID, MemberNum =entity.UserCode, MemberName =entity.UserName, Creator = entity.ModifyUserID, CreateTime=entity.ModifyTime, Updater=entity.ModifyUserID, UpdateTime=entity.ModifyTime };
                    groupMember.MemberId= CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "AI_GroupMember", ColumnName = "MemberId", OrganID = entity.OrganID }) + "";
                    groupMember.SaveModelM();
                }
            }
            #endregion


        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <param name="_TreeNodeFilter">过滤条件</param>
        /// <returns></returns>
        public List<GI_UserInfo> GetAll(TreeNodeFilter _TreeNodeFilter)
        {

            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.ParentID))
                filter += string.Format("  and ParentID='{0}'", _TreeNodeFilter.ParentID);
            if (!string.IsNullOrWhiteSpace(_TreeNodeFilter.keyword))
                filter += string.Format(" and (Name like '%{0}%' or SpellCode like '%{0}%') ", _TreeNodeFilter.keyword.ToUpper());
            List<GI_UserInfo> list = EntityOperate<GI_UserInfo>.GetEntityList(filter, "UserId");
            if (list == null || list.Count <= 0)
            {
                return new List<GI_UserInfo>();
            }
            

            list.ForEach((f) =>
            {
                f.IsCanceName = f.IsCance != 1 ? "正常" : "作废";
                f.DpetName = "";
                f.InpatientName = "";
                f.MedicalName = "";
                //职位
                GI_CodeDict job = new CodeDictService().GetCodeDictByDictCodeAndEName(f.Job, "Job");
                f.JobName = job == null ? "" : job.DictName;
                //职称
                GI_CodeDict userPosition = new CodeDictService().GetCodeDictByDictCodeAndEName(f.UserPosition, "Position");
                f.UserPositionName = userPosition == null ? "" : userPosition.DictName;
                //职位级别
                GI_CodeDict joblevel = new CodeDictService().GetCodeDictByDictCodeAndEName(f.JobLevel, "JobLevel");
                f.JobLevelName = joblevel == null ? "" : joblevel.DictName;

                #region 科室和病区组
                List<AI_DeptInfo> userDepts = deptinfoservice.GetDeptInfoByUserId(f.UserID);
                //科室
                f.DpetList = (from u in userDepts where u.IsInpatient == 0 select u).ToList();
                //病区
                f.InpatientList = (from u in userDepts where u.IsInpatient == 1 select u).ToList();
                #endregion
                //用户医疗组
                f.MedicalList = new DoctorGroupService().GetDoctorGroupByUserId(f.UserID);

                

            });
            return list;
        }

        /// <summary>
        /// 根据ID获得用户实体类
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public GI_UserInfo GetInfoById(string userid) {
            GI_UserInfo info = EntityOperate<GI_UserInfo>.GetEntityById(userid, "USERID");

            //职位
            GI_CodeDict job = new CodeDictService().GetCodeDictByDictCodeAndEName(info.Job, "Job");
            info.JobName = job == null ? "" : job.DictName;
            //职称
            GI_CodeDict userPosition = new CodeDictService().GetCodeDictByDictCodeAndEName(info.UserPosition, "Position");
            info.UserPositionName = userPosition == null ? "" : userPosition.DictName;
            //职务级别
            GI_CodeDict joblevel= new CodeDictService().GetCodeDictByDictCodeAndEName(info.JobLevel, "JobLevel");
            info.JobLevelName = joblevel == null ? "" : joblevel.DictName;

            #region 科室和病区组
            List<AI_DeptInfo> userDepts = deptinfoservice.GetDeptInfoByUserId(info.UserID);
            //科室
            info.DpetList = (from u in userDepts where u.IsInpatient == 0 select u).ToList();
            //病区
            info.InpatientList = (from u in userDepts where u.IsInpatient == 1 select u).ToList();
            #endregion
            //用户医疗组
            info.MedicalList = new DoctorGroupService().GetDoctorGroupByUserId(info.UserID);

            return info;
        }
    }
}
