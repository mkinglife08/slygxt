/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：ConsultationController.cs
// 文件功能描述： 会诊单控制层
// 创建标识：李荷 2019-1-2 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMR.Services;
using EMR.Common;

namespace EMR.Web.Controllers.Doctor
{
    public class ConsultationController : BaseController
    {
        private ConsultationService service = new ConsultationService();
        private BasicInpatientInfoService inpatientService = new BasicInpatientInfoService();
        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {

            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                CommonFilter commonFilter = GetPageData<CommonFilter>(0);
                List<CD_Consultation> list = service.GetAll(commonFilter).Where(f => f.Del != 1).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }

        /// <summary>
        /// 获取请求会诊单列表
        /// </summary>
        /// <param name="userFilter"></param>
        /// <returns></returns>
        public string GetRequestConsultationByUser()
        {
            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                //UserFilter userFilter = GetPageData<UserFilter>(0);
                List<CD_Consultation> list = service.GetConsultationByUser(UserTokenManager.GetUId(Request["token"])).Where(f => f.Del != 1).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                return new WebApi_Result() { code= 0 ,data = list, count = list.Count };
            });
        }

        /// <summary>
        /// 获取回复会诊单列表
        /// </summary>
        /// <param name="userFilter"></param>
        /// <returns></returns>
        public string GetApplyConsultationByUser()
        {
            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                //UserFilter userFilter = GetPageData<UserFilter>(0);
                List<CD_Consultation> list = service.GetConsultationByUser(UserTokenManager.GetUId(Request["token"]),"1").Where(f => f.Del != 1).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                return new WebApi_Result() { code = 0, data = list, count = list.Count };
            });
        }
        /// <summary>
        /// 获取会诊单数量
        /// </summary>
        /// <param name="userFilter"></param>
        /// <returns></returns>
        public string GetConsulationCountByUser()
        {
            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                //UserFilter userFilter = GetPageData<UserFilter>(0);
                int cnt = service.GetConsulationCountByUser(UserTokenManager.GetUId(Request["token"]));
                return new WebApi_Result() { code = 0, data =cnt };
            });
        }
        /// <summary>
        /// 获取住院病人信息
        /// </summary>
        /// <returns></returns>
        public string GetInpatientInfoById()
        {
            return base.ExecuteActionJsonResult("获取住院病人信息", () =>
            {
                CD_Inpatient entity = EntityOperate<CD_Inpatient>.GetEntityById(Request["InpatientId"], "InpatientId");
                entity.CurrentDeptName= EntityOperate<AI_DeptInfo>.GetEntityById(entity.CurrentDeptID, "DeptID").DeptName;
                entity.CurrentWardName= EntityOperate<AI_DeptInfo>.GetEntityById(entity.CurrentWardID, "DeptID").DeptName;
                return new WebApi_Result() { data = entity };
            });
        }

        /// <summary>
        /// 获取会诊单信息
        /// </summary>
        /// <returns></returns>
        public string GetConsultationInfoById()
        {
            return base.ExecuteActionJsonResult("获取会诊单信息", () =>
            {
                CD_Consultation entity = EntityOperate<CD_Consultation>.GetEntityById(Request["ConsultationId"], "ConsultationId");
                if (!string.IsNullOrWhiteSpace(entity.RequesterCode))
                {
                    GI_UserInfo Requester = EntityOperate<GI_UserInfo>.GetEntityById(entity.RequesterCode, "UserID");
                    entity.RequesterName = Requester.UserName;
                }
                if (!string.IsNullOrWhiteSpace(entity.RequestDepartCode))
                {
                    AI_DeptInfo Dept = EntityOperate<AI_DeptInfo>.GetEntityById(entity.RequestDepartCode, "DeptID");
                    entity.RequestDepartName = Dept.DeptName;
                }
                return new WebApi_Result() { data = entity };
            });
        }
        public string SaveConsultationInfo()
        {
            return base.ExecuteActionJsonResult("会诊单信息保存", () =>
            {

                CD_Consultation entity = base.GetPageData<CD_Consultation>(0);
                if (!string.IsNullOrWhiteSpace(entity.InpatientId))
                {
                    CD_Inpatient inpatient = EntityOperate<CD_Inpatient>.GetEntityById(Request["InpatientId"], "InpatientId");
                    if (string.IsNullOrWhiteSpace(entity.ConsultationId) || entity.ConsultationId == "null")
                    {
                        entity.ConsultationState = "1";
                        entity.DeptId = inpatient.CurrentDeptID;
                         entity.WardId = inpatient.CurrentWardID;
                        entity.RequesterCode = UserTokenManager.GetUserToken(Request["token"]).UserId;
                        GI_UserInfo user = EntityOperate<GI_UserInfo>.GetEntityById(entity.RequesterCode, "USERID");
                        entity.RequestDepartCode = user.DpetID;
                    entity.OrganID = UserTokenManager.GetUserToken(Request["token"]).ORGANID;
                    }

                    entity.Del = 0;
                    service.SaveInfo(entity);
                    msgHub hub = new msgHub();
                   // hub.SendGroup(entity.ApplyDepartCode, "Con", "",  "");
                }
                return new WebApi_Result() ;
            });
        }

        /// <summary>
        /// 删除会诊单
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<CD_Consultation>.DeleteById(Request["ConsultationId"], "ConsultationId");
                return new WebApi_Result();
            });
        }
    }
}