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

namespace EMR.Services.Server.Infection
{
    public class DisInfectionService
    {
        
        /// <summary>
      /// 获取所有洗手考核标准
      /// </summary>
      /// <param name="iFilter"></param>
      /// <returns></returns>
        public List<BUS_DISINFECTION> GetAllDisInfection(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_DISINFECTION> list = EntityOperate<BUS_DISINFECTION>.GetEntityList(filter, "DISID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_DISINFECTION>();
            }
            return list;
        }

        /// <summary>
        /// 根据洗手考核ID获取单个洗手考核数据
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<BUS_DISINFECTION, List<AI_DeptInfo>> GetDisInfectionModel(CommonFilter iFilter, string DISID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
           // if (!string.IsNullOrWhiteSpace(DISID)) { filter += " and DISID=" + DISID + ""; }

            BUS_DISINFECTION model = EntityOperate<BUS_DISINFECTION>.GetEntityById(DISID, "DISID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.DEPTID + "'"), "ParentID,DeptID");
            var tupe = new Tuple<BUS_DISINFECTION, List<AI_DeptInfo>>(model, departList);
            return tupe;
        }

        /// <summary>
        /// 保存反馈单和反馈单数据
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_DISINFECTION model)
        {
            if (string.IsNullOrWhiteSpace(model.DISID))
            {
                model.DISID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_DISINFECTION", ColumnName = "DISID", OrganID = model.ORGANID }) + "";
                model.SaveModelM();
            }
            else
            {
                var entity = EntityOperate<BUS_DISINFECTION>.GetEntityById(model.DISID, "DISID");
                model.XZRYID = entity.XZRYID;
                model.XZRYMC = entity.XZRYMC;
                model.XZRQ = entity.XZRQ;
                model.ORGANID = entity.ORGANID;
                model.UpdateM("DISID");
            }
        }
    }
}
