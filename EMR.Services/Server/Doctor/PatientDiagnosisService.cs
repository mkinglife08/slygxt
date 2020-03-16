/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：PatientDiagnosisService.cs
// 文件功能描述： 病案首页中有关病人诊断的服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病人诊断相关数据的服务，一般返回与病人诊断相关的实体或实体集合。
// 创建标识：吕屹凌 2019-1-21
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.SystemSupport;
using EMR.Services.Extension;
using EMR.Services.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Server.Doctor
{
    public class PatientDiagnosisService
    {
        //公用代码服务
        CodeDictService codedictService = new CodeDictService();

        /// <summary>
        /// 保存病人诊断数据
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_PatientDiagnosis entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.DiagnosisId) && entity.DiagnosisId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("DiagnosisId");
            }
            else
            {
                entity.DiagnosisId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_PatientDiagnosis", ColumnName = "DiagnosisId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询病人诊断数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_PatientDiagnosis> GetAll(PatientDiagnosisFilter iFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(iFilter.keyword))
                filter += string.Format(" and DiagnosisName like '%{0}%'", iFilter.keyword);
            filter += iFilter.GetQueryString();
            List<CD_PatientDiagnosis> list = EntityOperate<CD_PatientDiagnosis>.GetEntityList(filter, "SortOrder,OrganID");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_PatientDiagnosis>();
            }
            list.ForEach((f) =>
            {
                var Inpatient = new InpatientService().GetInfoByInpatientId(f.InpatientId);
                f.InpatientName = Inpatient != null ? Inpatient.Name : "";//病人名字
                if (f.DiagnosisFlag != null) { f.DiagnosisFlagName = codedictService.GetCodeDictByDictCodeAndEName(f.DiagnosisFlag.ToString(), "DiagnosisFlag").DictName; }//确诊标志中文
                GI_UserInfo RecordUser = EntityOperate<GI_UserInfo>.GetEntityById(f.RecordUserId, "USERID");//记录医生实体类
                f.RecordUserESign = RecordUser?.ESign;//电子签名
            });
            return list;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="entity">排序实体</param>
        /// <param name="orderType">上移:up,下移down</param>
        /// <returns></returns>
        public Boolean Order(CD_PatientDiagnosis entity, string orderType)
        {
            string iFilter = "";
            switch (orderType)
            {
                case "up":
                    iFilter = " and sortorder<" + entity.SortOrder + "  order by sortorder desc";
                    break;
                case "down":
                    iFilter = " and sortorder>" + entity.SortOrder + "  order by sortorder";
                    break;
                default:
                    return false;
            }
            string sql = string.Format("select a.*,rownum  from (select * from CD_PatientDiagnosis where 1=1 and nvl(DEL,0) <> 1 {0}) a where rownum=1", iFilter);
            CD_PatientDiagnosis other = EntityOperate<CD_PatientDiagnosis>.GetEntityBySQL(sql);
            if (other == null)
            {
                return false;
            }
            //互换
            int SortOrder = other.SortOrder;
            other.SortOrder = entity.SortOrder;
            entity.SortOrder = SortOrder;
            SaveInfo(entity);
            SaveInfo(other);
            return true;
        }
    }
}
