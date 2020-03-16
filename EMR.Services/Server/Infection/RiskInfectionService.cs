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
   public class RiskInfectionService
    {
        /// <summary>
        /// 获取医院感染风险列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_RISKINFECTION> GetAllRiskInfectionService(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_RISKINFECTION> list = EntityOperate<BUS_RISKINFECTION>.GetEntityList(filter, "RISKID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_RISKINFECTION>();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取医院感染风险评分数据表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<List<BUS_RISKINFECTION_SOURCE>, List<AI_DeptInfo>, BUS_RISKINFECTION> GetRiskInfectionSourceList(CommonFilter iFilter, string RISKID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            //if (!string.IsNullOrWhiteSpace(RISKID)) { filter += " and RISKID='" + RISKID + "'"; }

            List<BUS_RISKINFECTION_SOURCE> list = EntityOperate<BUS_RISKINFECTION_SOURCE>.GetEntityList(filter + (string.IsNullOrWhiteSpace(RISKID) == true ? "" :" and RISKID='" + RISKID + "'"));
            var model = EntityOperate<BUS_RISKINFECTION>.GetEntityById(RISKID, "RISKID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.DEPTID + "'"), "ParentID,DeptID");
            var tupe = new Tuple<List<BUS_RISKINFECTION_SOURCE>, List<AI_DeptInfo>, BUS_RISKINFECTION>(list, departList,model);
            return tupe;
        }


        /// <summary>
        /// 批量保存感染风险评估数据，采用的方式是根据风险表ID 删掉数据表中的数据，再批量添加进去
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_RISKINFECTION riskModel, string riskSource)
        {
            if (!string.IsNullOrWhiteSpace(riskModel.RISKID))
            {
                //根据父ID删掉BUS_RISKINFECTION_SOURCE数据库表中的数据 
                EntityOperate<BUS_RISKINFECTION_SOURCE>.DeleteByFilter("RISKID='" + riskModel.RISKID + "' and ORGANID = '" + riskModel.ORGANID + "'");
            }

            if (string.IsNullOrWhiteSpace(riskModel.RISKID))
            {
                riskModel.RISKID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_RISKINFECTION", ColumnName = "RISKID", OrganID = riskModel.ORGANID }) + "";
                riskModel.SaveModelM();
            }
            else
            {
                riskModel.UpdateM("RISKID");
            }

            var riskSourceList = JSONHelper.DeserializeObject<List<BUS_RISKINFECTION_SOURCE>>(riskSource);
            var riskSourceFiltered =  riskSourceList.Where(p => string.IsNullOrWhiteSpace(p.FLMC)!=true|| string.IsNullOrWhiteSpace(p.NR) != true || string.IsNullOrWhiteSpace(p.QZ) != true || string.IsNullOrWhiteSpace(p.KNX) != true || string.IsNullOrWhiteSpace(p.HGSS) != true || string.IsNullOrWhiteSpace(p.DQTX) != true || string.IsNullOrWhiteSpace(p.FZ) != true);

            //过滤后的数据集合大于0
            if (riskSourceFiltered.Count()>0)
            {
                //把过滤后的数据插入数据库
                foreach (var riskSourceModel in riskSourceFiltered)
                {
                    riskSourceModel.SOURCEID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_RISKINFECTION_SOURCE", ColumnName = "SOURCEID", OrganID = riskModel.ORGANID }) + "";
                    riskSourceModel.ORGANID = riskModel.ORGANID;
                    riskSourceModel.RISKID = riskModel.RISKID;
                    riskSourceModel.SaveModelM();
                }
            }
             
        }
    }
}
