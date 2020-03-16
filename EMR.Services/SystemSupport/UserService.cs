/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：UserService.cs
// 文件功能描述： 用户人员服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供用户相关数据的服务，一般返回与用户相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using EMR.Services.Interface;
using EMR.Services.Server.Public;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMR.Services.SystemSupport
{
    public class UserService: ISerialPrimaryKey
    {
        /// <summary>
        /// 部门服务类
        /// </summary>
        DeptInfoService deptinfoservice = new DeptInfoService();

        /// <summary>
        /// 获取自增主键
        /// </summary>
        /// <param name="OrganId">组织机构ID</param>
        /// <returns>主键ID</returns>
        public string GetPrimaryId(string OrganId="0")
        {
             return CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_UserInfo", ColumnName = "UserID", OrganID = OrganId }) + ""; 
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="entity">用户实体</param>
        public void SaveUserInfo(GI_UserInfo entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.UserID) && entity.UserID != "null")
            {
                entity.ModifyTime = DateTime.Now;
                entity.PassWord = null;
                //user.PASSWORD = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(user.PASSWORD, "md5");
                entity.UpdateM("USERID");
            }
            else
            {
                entity.UserID = this.GetPrimaryId(entity.OrganID) + "";
                entity.LoginTime = entity.ModifyTime = DateTime.Now;
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 获取用户数据列表
        /// </summary>
        /// <param name="commonFilter"></param>
        /// <returns></returns>
        public List<GI_UserInfo> GetAll(CommonFilter commonFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(commonFilter.keyword))
                filter += string.Format(" and USERNAME like '%{0}%'", commonFilter.keyword);
            filter += commonFilter.GetQueryString();
            List<GI_UserInfo> list = EntityOperate<GI_UserInfo>.GetEntityList(filter);
            if (list == null || list.Count <= 0)
            {
                return new List<GI_UserInfo>();
            }
            
            return list;
        }


        /// <summary>
        /// 根据ID获得用户实体类
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public GI_UserInfo GetInfoById(string userid)
        {
            GI_UserInfo info = EntityOperate<GI_UserInfo>.GetEntityById(userid, "USERID");

            //职位
            GI_CodeDict job = new CodeDictService().GetCodeDictByDictCodeAndEName(info.Job, "Job");
            info.JobName = job == null ? "" : job.DictName;
            //职称
            GI_CodeDict userPosition = new CodeDictService().GetCodeDictByDictCodeAndEName(info.UserPosition, "Position");
            info.UserPositionName = userPosition == null ? "" : userPosition.DictName;
            //职务级别
            GI_CodeDict joblevel = new CodeDictService().GetCodeDictByDictCodeAndEName(info.JobLevel, "JobLevel");
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

        #region 用户关联用户组
        public List<GI_RoleMember> GetUserGroup(string userid)
        {
            string filter = "USERID = '" + userid + "'";
            List<GI_RoleMember> list_ROLEMEMBER = EntityOperate<GI_RoleMember>.GetEntityList(filter);
            return list_ROLEMEMBER;
        }

        public void SaveUserGroup(string userid, string groups)
        {
            EntityOperate<GI_RoleMember>.DeleteByFilter("USERID = '" + userid + "'");
            if (!string.IsNullOrWhiteSpace(groups))
            {
                foreach (string each in groups.Trim(',').Split(','))
                {
                    GI_RoleMember rolemem = new GI_RoleMember() { RoleID = each, UserID = userid };
                    rolemem.SaveModelM();
                }
            }
        }
        #endregion

        #region 用户关联系统模块

        /// <summary>
        /// 保存用户模块数据
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="sysApp">系统模块ID字符串，多个ID以逗号隔开</param>
        /// <param name="defaultAppId">默认系统ID</param>
        public void SaveUserSys(string userid, string sysApp, string defaultAppId)
        {
            EntityOperate<GI_UserSYS>.DeleteByFilter("USERID = '" + userid + "'");
            if (!string.IsNullOrWhiteSpace(sysApp))
            {
                foreach (string each in sysApp.Trim(',').Split(','))
                {
                    GI_UserSYS rolemem = new GI_UserSYS() { SYSID = each, UserID = userid };
                    if (each == defaultAppId)
                        rolemem.IsDefault = 1;
                    rolemem.SaveModelM();
                }
            }
        }

        /// <summary>
        /// 更新用户默认系统
        /// </summary>
        /// <param name="_GI_USERSYS"></param>
        public void UpdateDefaultUserSysApp(GI_UserSYS _GI_USERSYS)
        {
            EntityOperate<GI_UserSYS>.ExecSqlString(string.Format("update GI_USERSYS set ISDEFAULT = 0 where USERID = '{0}' and SYSID <> '{1}'", _GI_USERSYS.UserID, _GI_USERSYS.SYSID));
            EntityOperate<GI_UserSYS>.ExecSqlString(string.Format("update GI_USERSYS set ISDEFAULT = 1 where USERID = '{0}' and SYSID = '{1}'", _GI_USERSYS.UserID, _GI_USERSYS.SYSID));
        }

        /// <summary>
        /// 获取与用户相关的系统模块
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>用户模块列表</returns>
        public List<V_USERSYS> GetUserSysAppList(string userid)
        {
            return EntityOperate<V_USERSYS>.GetEntityList("userid='" + userid + "'", "DISPLAYSORT,SYSID");
        }
        #endregion

        #region 获取用户相关的功能定义集合
        /// <summary>
        /// 获取用户相关的功能定义集合
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="SYSID">模块ID</param>
        /// <param name="funLevel">功能定义级别</param>
        /// <returns></returns>
        public List<GI_FunInfo> GetUserFunInfo(string userID, string SYSID,int funLevel)
        {
            string filter = " 1=1 ";
            if (!string.IsNullOrWhiteSpace(userID))
                filter += " and FUNID in (select FUNID from GI_ROLERIGHT where ROLEID in (select ROLEID from GI_ROLEMEMBER where userid = '" + userID + "')) ";
            if (!string.IsNullOrWhiteSpace(SYSID))
                filter += " and SYSID = '" + SYSID + "' ";
            else
                filter += " and 1 = 2 ";
            if(funLevel>-1)
                filter += " and funLevel = "+ funLevel;
            //filter += " and SYSID in (select SYSID  from GI_USERSYS where userid = '" + userid + "') ";
            List<GI_FunInfo> list = EntityOperate<GI_FunInfo>.GetEntityList(filter, "DISPLAYSORT,funid");
            
            return list;
        }
        #endregion

        #region 获取相关用户
        public List<GI_UserInfo> GetUserInfoByFilter(UserFilter userFilter)
        {
            string filter = "1=1";
            filter += userFilter.GetQueryString();
            List<GI_UserInfo> list = EntityOperate<GI_UserInfo>.GetEntityList(filter);
            if(list==null || list.Count <= 0)
            {
                return new List<GI_UserInfo>();
            }
            return list;
        }
        #endregion
    }
}
