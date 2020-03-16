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
    /// 环境检测service
    /// </summary>
    public class EnvironmentTestService
    {
        /// <summary>
        /// 环境检测列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_ENVIRONMENTTEST> GetAllEnvironmentTestService(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_ENVIRONMENTTEST> list = EntityOperate<BUS_ENVIRONMENTTEST>.GetEntityList(filter, "ENVID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_ENVIRONMENTTEST>();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取环境检测列表数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<List<BUS_ENVIRONMENTTEST_SOURCE>, List<AI_DeptInfo>, BUS_ENVIRONMENTTEST> GetEnvironmentTestSourceList(CommonFilter iFilter, string ENVID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString(); 

            List<BUS_ENVIRONMENTTEST_SOURCE> list = EntityOperate<BUS_ENVIRONMENTTEST_SOURCE>.GetEntityList(filter + (string.IsNullOrWhiteSpace(ENVID) == true ? "" : " and ENVID='" + ENVID + "'"));
            var model = EntityOperate<BUS_ENVIRONMENTTEST>.GetEntityById(ENVID, "ENVID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.DEPTID + "'"), "ParentID,DeptID");
            var tupe = new Tuple<List<BUS_ENVIRONMENTTEST_SOURCE>, List<AI_DeptInfo>, BUS_ENVIRONMENTTEST>(list, departList, model);
            return tupe;
        }

        /// <summary>
        /// 批量保存环境检测列表数据，采用的方式是根据主表ID 删掉数据表中的数据，再批量添加进去
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_ENVIRONMENTTEST envModel, string envSource)
        {
            if (!string.IsNullOrWhiteSpace(envModel.ENVID))
            {
                //根据父ID删掉 BUS_DRUGRESISTQUAR_SOURCE 数据库表中的数据 
                EntityOperate<BUS_ENVIRONMENTTEST_SOURCE>.DeleteByFilter("ENVID='" + envModel.ENVID + "' and ORGANID = '" + envModel.ORGANID + "'");
            }

            if (string.IsNullOrWhiteSpace(envModel.ENVID))
            {
                envModel.ENVID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_ENVIRONMENTTEST", ColumnName = "ENVID", OrganID = envModel.ORGANID }) + "";
                envModel.SaveModelM();
            }
            else
            {
                envModel.UpdateM("ENVID");
            }

            var envSourceList = JSONHelper.DeserializeObject<List<BUS_ENVIRONMENTTEST_SOURCE>>(envSource);
            Func<string, bool> checkEmNull = a =>
            {
                return string.IsNullOrWhiteSpace(a);
            };

            var envSourceFiltered = envSourceList.Where(p => checkEmNull(p.SQDFL) != true || checkEmNull(p.SQKSNAME) != true || checkEmNull(p.BB) != true || checkEmNull(p.XJSL) != true || checkEmNull(p.JG) != true || checkEmNull(p.HG) != true || checkEmNull(p.BZ) != true);
            //过滤后的数据集合大于0
            if (envSourceFiltered.Count() > 0)
            {
                //把过滤后的数据插入数据库
                foreach (var envSourceModel in envSourceFiltered)
                {
                    envSourceModel.ENSID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_ENVIRONMENTTEST_SOURCE", ColumnName = "ENSID", OrganID = envModel.ORGANID }) + "";
                    envSourceModel.ORGANID = envModel.ORGANID;
                    envSourceModel.ENVID = envModel.ENVID;
                    envSourceModel.SaveModelM();
                }
            }

        }



    }
}
