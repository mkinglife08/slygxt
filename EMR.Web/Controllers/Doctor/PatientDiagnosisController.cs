using EMR.Data;
using EMR.Data.Models;
using EMR.Services;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Web.Extension.Common;
using EMR.Web.Extension.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Doctor
{
    public class PatientDiagnosisController : BaseController
    {
        private PatientDiagnosisService patientDiagnosisService = new PatientDiagnosisService();
        private HospitalRecordService hospitalrecordservice = new HospitalRecordService();
        /// <summary>
        /// 保存诊断数据
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("诊断保存", () =>
            {
                CD_PatientDiagnosis entity = base.GetPageData<CD_PatientDiagnosis>(0);
                CD_HospitalRecord hospitalRecord = hospitalrecordservice.GetInfoByInpatientId(entity.InpatientId);
                if (hospitalRecord == null) {
                    return new WebApi_Result() { code = 0,msg="请先保存入院记录" };
                }

                entity.ICDCode = string.IsNullOrWhiteSpace(entity.ICDCode) ? null : entity.ICDCode;
                var DiagnosisIdList = (entity.DiagnosisId + "").Split(',');
                for (int i = 0; i < entity.ICDCode.Split(',').Length; i++)
                {
                    var cur_entity = base.GetPageData<CD_PatientDiagnosis>(0);
                    if (DiagnosisIdList.Length > i)
                        cur_entity.DiagnosisId = DiagnosisIdList[i];
                    else
                        cur_entity.DiagnosisId = "";
                    cur_entity.ParentId = string.IsNullOrWhiteSpace(cur_entity.ParentId) ? "0" : cur_entity.ParentId;
                    cur_entity.ICDCode = entity.ICDCode.Split(',')[i];
                    cur_entity.DiagnosisName = entity.DiagnosisName.Split(',')[i];
                    UserToken ut = UserTokenManager.GetUserToken(Request["token"]);
                    cur_entity.RecordUserId = cur_entity.Creator = ut.UserId;
                    cur_entity.RecordUserName = ut.USERNAME;
                    if (cur_entity.DiagnosisTime == null) cur_entity.DiagnosisTime = DateTime.Now;
                    

                    //病历记录id
                    cur_entity.RecordId = hospitalRecord.HospitalRecordId; 

                    patientDiagnosisService.SaveInfo(cur_entity);
                }
                return new WebApi_Result();
            });
        }
        /// <summary>
        /// 获取诊断列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取诊断列表", () =>
            {
                PatientDiagnosisFilter filter = GetPageData<PatientDiagnosisFilter>(0);
                //List<CD_BasicInpatientInfo> list = inpatientService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<CD_PatientDiagnosis> list = patientDiagnosisService.GetAll(filter);
                int curpage = 0, limit = 300;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取诊断信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取诊断信息", () =>
            {
                CD_PatientDiagnosis entity = EntityOperate<CD_PatientDiagnosis>.GetEntityById(Request["DiagnosisId"], "DiagnosisId");
                entity.DiagnosisFlagName = CommonService.GetDictNameByID("489", entity.DiagnosisFlag + "");
                entity.DiagnosisTypeName = CommonService.GetDictNameByID("468", entity.DiagnosisType + "");
                return new WebApi_Result() { data = entity };
            });
        }

        /// <summary>
        /// 删除诊断信息
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除诊断信息", () =>
            {
                EntityOperate<CD_PatientDiagnosis>.DeleteById(Request["DiagnosisId"], "DiagnosisId");
                return new WebApi_Result() { };
            });
        }

        /// <summary>
        /// 获取最新排序号
        /// </summary>
        /// <returns></returns>
        public string GetLastDISPLAYSORT()
        {
            return base.ExecuteActionJsonResult("获取最新排序号", () =>
            {
                int lastDISPLAYSORT = EntityOperate<CD_PatientDiagnosis>.GetLastOrderId("", "SortOrder", "InpatientId = " + Request["InpatientId"]+ " and DiagnosisType = "+ Request["DiagnosisType"]);
                return new WebApi_Result() { data = lastDISPLAYSORT };
            });
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        public string Order() {
            return base.ExecuteActionJsonResult("排序上移或下移", () =>
            {
                CD_PatientDiagnosis entity = EntityOperate<CD_PatientDiagnosis>.GetEntityById(Request["DiagnosisId"], "DiagnosisId");
                patientDiagnosisService.Order(entity, Request["orderType"]);
                return new WebApi_Result();
            });
        }

    }
}