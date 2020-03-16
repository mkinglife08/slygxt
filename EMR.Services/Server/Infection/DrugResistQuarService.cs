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
    /// 多重耐药菌隔离措施
    /// </summary>
    public class DrugResistQuarService
    {
        /// <summary>
        /// 多重耐药菌隔离措施列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_DRUGRESISTQUAR> GetAllDrugResistQuarService(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_DRUGRESISTQUAR> list = EntityOperate<BUS_DRUGRESISTQUAR>.GetEntityList(filter, "DCID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_DRUGRESISTQUAR>();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取多重耐药菌隔离措施数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<List<BUS_DRUGRESISTQUAR_SOURCE>, List<AI_DeptInfo>, BUS_DRUGRESISTQUAR> GetDrugResistQuarSourceList(CommonFilter iFilter, string DCID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString(); 

            List<BUS_DRUGRESISTQUAR_SOURCE> list = EntityOperate<BUS_DRUGRESISTQUAR_SOURCE>.GetEntityList(filter + (string.IsNullOrWhiteSpace(DCID) == true ? "" : " and DCID='" + DCID + "'"));
            var model = EntityOperate<BUS_DRUGRESISTQUAR>.GetEntityById(DCID, "DCID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.DEPTID + "'"), "ParentID,DeptID");
            var tupe = new Tuple<List<BUS_DRUGRESISTQUAR_SOURCE>, List<AI_DeptInfo>, BUS_DRUGRESISTQUAR>(list, departList, model);
            return tupe;
        }

        /// <summary>
        /// 批量保存多重耐药菌隔离措施数据，采用的方式是根据主表ID 删掉数据表中的数据，再批量添加进去
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_DRUGRESISTQUAR drugModel, string drugSource)
        {
            if (!string.IsNullOrWhiteSpace(drugModel.DCID))
            {
                //根据父ID删掉 BUS_DRUGRESISTQUAR_SOURCE 数据库表中的数据 
                EntityOperate<BUS_DRUGRESISTQUAR_SOURCE>.DeleteByFilter("DCID='" + drugModel.DCID + "' and ORGANID = '" + drugModel.ORGANID + "'");
            }

            if (string.IsNullOrWhiteSpace(drugModel.DCID))
            {
                drugModel.DCID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_DRUGRESISTQUAR", ColumnName = "DCID", OrganID = drugModel.ORGANID }) + "";
                drugModel.SaveModelM();
            }
            else
            {
                drugModel.UpdateM("DCID"); 
            }

            var drugSourceFiltered = JSONHelper.DeserializeObject<List<BUS_DRUGRESISTQUAR_SOURCE>>(drugSource);

            //过滤后的数据集合大于0
            if (drugSourceFiltered.Count() > 0)
            {
                //把过滤后的数据插入数据库
                foreach (var drugSourceModel in drugSourceFiltered)
                {
                    drugSourceModel.DRUGID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_DRUGRESISTQUAR_SOURCE", ColumnName = "DRUGID", OrganID = drugModel.ORGANID }) + "";
                    drugSourceModel.ORGANID = drugModel.ORGANID;
                    drugSourceModel.DCID = drugModel.DCID;
                    drugSourceModel.SaveModelM();
                }
            }

        }



    }
}
