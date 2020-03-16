/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：OperationRecordService.cs
// 文件功能描述： 手术记录服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供手术记录相关数据的服务，一般返回与手术记录相关的实体或实体集合。
// 创建标识：吕屹凌 2019-1-4 
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
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Server.Doctor
{
    public class OperationRecordService
    {
        /// <summary>
        /// 保存手术记录
        /// </summary>
        /// <param name="entity">手术记录实体</param>
        public void SaveInfo(CD_OperationRecord entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.OperationId) && entity.OperationId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("OperationId");
            }
            else
            {
                entity.OperationId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_OperationRecord", ColumnName = "OperationId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询手术记录数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_OperationRecord> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(iFilter.keyword))
                filter += string.Format(" and OperationName like '%{0}%'", iFilter.keyword);
            filter += iFilter.GetQueryString();
            List<CD_OperationRecord> list = EntityOperate<CD_OperationRecord>.GetEntityList(filter, "OperationId");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_OperationRecord>();
            }
            return list;
        }

        /// <summary>
        /// 根据筛选条件查询标准诊断数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<AI_Diagnosis> GetDiagnosisList(CommonFilter iFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(iFilter.keyword))
                filter += string.Format(" and (DiagnosisName like '%{0}%' or DiagnosisCode like '%{0}%' or SpellCode like '%{0}%')", iFilter.keyword.ToUpper());
            filter += iFilter.GetQueryString();
            List<AI_Diagnosis> list = EntityOperate<AI_Diagnosis>.GetEntityList(filter, "DiagnosisId");
            if (list == null || list.Count <= 0)
            {
                return new List<AI_Diagnosis>();
            }
            return list;
        }
    }
}
