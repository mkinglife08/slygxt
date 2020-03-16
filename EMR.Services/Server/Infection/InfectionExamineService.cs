using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EMR.Common;


namespace EMR.Services.Server.Infection
{
    /// <summary>
    /// 医院感染病例个案调查 service
    /// </summary>
    public class InfectionExamineService
    {
        /// <summary>
        /// 医院感染病例个案调查列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_INFECTIONEXAMINE> GetAllInfectionExamineService(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_INFECTIONEXAMINE> list = EntityOperate<BUS_INFECTIONEXAMINE>.GetEntityList(filter, "EXID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_INFECTIONEXAMINE>();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取医院感染病例个案调查和血清学和病原学检测 数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns>依次返回：感染调查表数据，血清学病原学检测列表，发生感染时所在科室，曾住科室</returns>
        public Tuple<BUS_INFECTIONEXAMINE, List<BUS_INFECTIONEXAMINE_BLOOD>, List<AI_DeptInfo>, List<AI_DeptInfo>> GetInfectionExamineSource(CommonFilter iFilter, string EXID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();

            var model = EntityOperate<BUS_INFECTIONEXAMINE>.GetEntityById(EXID, "EXID");
            List<BUS_INFECTIONEXAMINE_BLOOD> bloodList = EntityOperate<BUS_INFECTIONEXAMINE_BLOOD>.GetEntityList(filter + (string.IsNullOrWhiteSpace(EXID) == true ? "" : " and EXID='" + EXID + "'"));

            var departList1 = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.SZKSID + "'"), "ParentID,DeptID");  //所在科室
            var departList2 = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.CZKSID + "'"), "ParentID,DeptID");  //曾住科室
            var tupe = new Tuple<BUS_INFECTIONEXAMINE, List<BUS_INFECTIONEXAMINE_BLOOD>, List<AI_DeptInfo>, List<AI_DeptInfo>>(model, bloodList, departList1, departList2);
            return tupe;
        }

        /// <summary>
        /// 批量医院感染病例个案调查和血清学 和 病原学检测，采用的方式是根据主表ID 删掉数据表中的数据，再批量添加进去
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_INFECTIONEXAMINE examModel, string examBloodSource)
        {
            if (!string.IsNullOrWhiteSpace(examModel.EXID))
            {
                //根据父ID删掉 BUS_DRUGRESISTQUAR_SOURCE 数据库表中的数据 
                EntityOperate<BUS_INFECTIONEXAMINE_BLOOD>.DeleteByFilter("EXID='" + examModel.EXID + "' and ORGANID = '" + examModel.ORGANID + "'");
            }

            if (string.IsNullOrWhiteSpace(examModel.EXID))
            {
                examModel.EXID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_INFECTIONEXAMINE", ColumnName = "EXID", OrganID = examModel.ORGANID }) + "";
                examModel.SaveModelM();
            }
            else
            {
                examModel.UpdateM("EXID");
            }

            var examBloodSourceList = JSONHelper.DeserializeObject<List<BUS_INFECTIONEXAMINE_BLOOD>>(examBloodSource,"yyyy-MM-dd HH:ss:mm");
            Func<string, bool> checkEmNull = a =>
            {
                return string.IsNullOrWhiteSpace(a);
            };

            var examBloodSourceFiltered = examBloodSourceList.Where(p => checkEmNull(p.BBLX) != true || p.CYSJ != null || checkEmNull(p.JCXM) != true || checkEmNull(p.JCFF) != true || checkEmNull(p.JCDW) != true || checkEmNull(p.JCJG) != true);
            //过滤后的数据集合大于0
            if (examBloodSourceFiltered.Count() > 0)
            {
                //把过滤后的数据插入数据库
                foreach (var examSourceModel in examBloodSourceFiltered)
                {
                    examSourceModel.BLOODID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_INFECTIONEXAMINE_BLOOD", ColumnName = "BLOODID", OrganID = examModel.ORGANID }) + "";
                    examSourceModel.ORGANID = examModel.ORGANID;
                    examSourceModel.EXID = examModel.EXID;
                    examSourceModel.SaveModelM();
                }
            } 
        }
        

    }
}
