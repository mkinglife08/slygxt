using EMR.Data;
using EMR.Data.Models;
using EMR.Services;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Doctor
{
    public class OperationRecordController : BaseController
    {
        private OperationRecordService operationRecordService = new OperationRecordService();
        /// <summary>
        /// 保存手术记录
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("手术记录保存", () =>
            {
                CD_OperationRecord entity = base.GetPageData<CD_OperationRecord>(0);
                entity.OperationId = string.IsNullOrWhiteSpace(entity.OperationId) ? null : entity.OperationId;
                var OperationIdList = (entity.OperationId + "").Split(',');
                for (int i = 0; i < entity.OperationCode.Split(',').Length; i++)
                {
                    var cur_entity = base.GetPageData<CD_OperationRecord>(0);
                    if (OperationIdList.Length > i)
                        cur_entity.OperationId = OperationIdList[i];
                    else
                        cur_entity.OperationId = "";
                    cur_entity.OperationCode = entity.OperationCode.Split(',')[i];
                    cur_entity.OperationName = entity.OperationName.Split(',')[i];
                    operationRecordService.SaveInfo(cur_entity);
                }
                return new WebApi_Result();
            });
        }
        /// <summary>
        /// 获取手术记录列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取手术记录列表", () =>
            {
                InpatientFilter filter = GetPageData<InpatientFilter>(0);
                //List<CD_BasicInpatientInfo> list = inpatientService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<CD_OperationRecord> list = operationRecordService.GetAll(filter);
                list.ForEach(f => {
                    f.AnesthesiaWayName = CommonService.GetDictNameByID("450", f.AnesthesiaWayCode+"");
                    f.HealingLevelName = CommonService.GetDictNameByID("343", f.HealingLevel + "");
                    f.OperationLevelName = CommonService.GetDictNameByID("170", f.OperationLevel + "");
                });
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取手术记录信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取手术记录信息", () =>
            {
                CD_OperationRecord entity = EntityOperate<CD_OperationRecord>.GetEntityById(Request["OperationId"], "OperationId");
                entity.OperationLevelName = CommonService.GetDictNameByID("170", entity.OperationLevel + "");
                entity.AnesthesiaWayName = CommonService.GetDictNameByID("450", entity.AnesthesiaWayCode + "");
                return new WebApi_Result() { data = entity };
            });
        }
        /// <summary>
        /// 获取标准诊断列表
        /// </summary>
        /// <returns></returns>
        public string GetDiagnosisList()
        {
            return base.ExecuteActionJsonResult("获取标准诊断列表", () =>
            {
                InpatientFilter filter = GetPageData<InpatientFilter>(0);
                //List<CD_BasicInpatientInfo> list = inpatientService.GetAll(_CommonFilter).Where(f => f.IsCance != 1).ToList();//该表并无作废标志
                List<AI_Diagnosis> list = operationRecordService.GetDiagnosisList(filter);
                return new WebApi_Result() { data = list, count = list.Count };
            });
        }
    }
}