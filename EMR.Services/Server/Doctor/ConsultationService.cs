/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：ConsultationService.cs
// 文件功能描述： 会诊单服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供公用代码字典相关数据的服务，一般返回与公用代码字典相关的实体或实体集合。
// 创建标识：李荷 2019-1-2
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMR.Common;
namespace EMR.Services.Server.Doctor
{
   public class ConsultationService
    {
        /// <summary>
        /// 这里可以用配置文件进行控制
        /// </summary>
        public static IDataProvider dataProvider
        {
            get
            {
                return new OracleDataProvider();
            }
        }
        public List<CD_Consultation> GetAll(CommonFilter commonFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(commonFilter.keyword))
              //  filter += string.Format(" and Name like '%{0}%'", commonFilter.keyword);
            filter += commonFilter.GetQueryString();
            List<CD_Consultation> list = EntityOperate<CD_Consultation>.GetEntityList(filter, "OrganID");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_Consultation>();
            }
            return list;
        }

        public List<CD_Consultation> GetConsultationByUser(string userID,string consultationType=null)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(userID)) {
                GI_UserInfo user= EntityOperate<GI_UserInfo>.GetEntityById(userID,"USERID");
                if (user != null)
                {
                    if (consultationType == "1")
                    {
                    filter += string.Format(" and ( ApplyDoctorCode = '{0}'", userID);
                    filter += string.Format(" or ( ApplyDepartCode = '{0}' and ApplyDoctorCode is null ))", user.DpetID);
                 //   filter += string.Format(" and ApplyWardCode = '{0}'", user.InpatientID);
                    }
                    else
                    {

                    filter += string.Format(" and ( RequesterCode = '{0}'", userID);
                    filter += string.Format(" or RequestDepartCode = '{0}')", user.DpetID);
                    }
                }
            }
            filter += " order by a.consultationtype desc,a.applytime";
            List<CD_Consultation> list = EntityOperate<CD_Consultation>.GetEntityListBySQL(@"select a.consultationid,a.organid,a.inpatientid,a.deptid,
                a.wardid,a.bednum,a.consultationstate,a.consultationtype,a.hospitaltype,a.hospitalname,a.applytime,a.diseasesummary,a.applydepartcode,
                a.applydepartname,a.applywardcode,a.applywardname,a.applydoctorcode,a.applydoctorname,a.requestdepartcode,a.requestercode,a.verifiertime,
                a.verifiercode,a.replytime,a.replycontent,a.replydepartcode,a.replydepartname,a.replywardcode,a.replywardname,a.replydoctorcode,
                a.replydoctorname,a.del,a.creator,a.createtime,a.updater,a.updatetime, b.name as inpatientname,b.HEALTHCARD as InpatientCode,
                dept.DeptName as requestdepartName,ward.DeptName as InpatientWardName
                from CD_Consultation a ,cd_inpatient b,ai_deptinfo dept,ai_deptinfo ward where a.inpatientid=b.inpatientid and dept.isinpatient=0 and ward.isinpatient=1 and a.requestdepartcode=dept.DeptID and a.wardID=ward.DeptID and " + filter);
            if (list == null || list.Count <= 0)
            {
                return new List<CD_Consultation>();
            }
            list.ForEach((f) =>
            {
                f.ConsultationStateName = f.ConsultationState == "2" ? "已回复" : "新开";
                f.ConsultationTypeName = f.ConsultationType == "2" ? "<label style='color:red'>紧急</label>" : "普通";
                f.HospitalName = f.HospitalType == "2" ? f.HospitalName : "本院";
                if (!string.IsNullOrWhiteSpace(f.RequesterCode))
                {
                    GI_UserInfo Requester = EntityOperate<GI_UserInfo>.GetEntityById(f.RequesterCode, "UserID");
                    f.RequesterName = Requester.UserName;
                }
            });
            
            return list;
        }


        /// <summary>
        /// 保存会诊单
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_Consultation entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.ConsultationId) && entity.ConsultationId != "null")
            {
                entity.UpdateM("ConsultationId");
            }
            else
            {
                entity.ConsultationId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_Consultation", ColumnName = "ConsultationId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
                string[] userId = new string[] { entity.ApplyDoctorCode};
                msgHub msg = new msgHub();
                msg.Send(userId, "", entity.ApplyDoctorCode, "");
            }
        }


        public int GetConsulationCountByUser(string userID)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(userID))
            {
                GI_UserInfo user = EntityOperate<GI_UserInfo>.GetEntityById(userID, "USERID");
                if (user != null)
                {
                    filter += string.Format(" and ( ApplyDoctorCode = '{0}'", userID);
                    filter += string.Format(" or ( ApplyDepartCode = '{0}' and ApplyDoctorCode is null ))", user.DpetID);
              //      filter += string.Format(" and ApplyWardCode = '{0}'", user.InpatientID);
                }
            }
            DataTable dt = dataProvider.GetDataSet("select count(consultationid) as cnt  from CD_Consultation a where del=0 and consultationstate = 1 and "+filter ).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return Extend.HandleNull(dt.Rows[0]["cnt"], 0);
            }
            else
            {
                return 0;
            }
        }

    }
}
