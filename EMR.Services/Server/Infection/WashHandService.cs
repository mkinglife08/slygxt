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
    public class WashHandService
    {
        /// <summary>
        /// 获取所有洗手考核标准
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_WASHHANDOPERATION> GetAllWashHand(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_WASHHANDOPERATION> list = EntityOperate<BUS_WASHHANDOPERATION>.GetEntityList(filter, "WHOID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_WASHHANDOPERATION>();
            }
            return list;
        }

        /// <summary>
        /// 根据洗手考核ID获取单个洗手考核数据
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<BUS_WASHHANDOPERATION, List<AI_DeptInfo>> GetWashHandModel(CommonFilter iFilter, string WHOID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
          //  if (!string.IsNullOrWhiteSpace(WHOID)) { filter += " and WHOID=" + WHOID + ""; }

            BUS_WASHHANDOPERATION model = EntityOperate<BUS_WASHHANDOPERATION>.GetEntityById(WHOID, "WHOID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.DEPTID + "'"), "ParentID,DeptID");
            var tupe = new Tuple<BUS_WASHHANDOPERATION, List<AI_DeptInfo>>(model, departList);
            return tupe;
        }

        /// <summary>
        /// 保存反馈单和反馈单数据
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_WASHHANDOPERATION model)
        {
            if (string.IsNullOrWhiteSpace(model.WHOID))
            {
                model.WHOID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_WASHHANDOPERATION", ColumnName = "WHOID", OrganID = model.ORGANID }) + "";
                model.SaveModelM();
            } 
            else
            {
                var entity = EntityOperate<BUS_WASHHANDOPERATION>.GetEntityById(model.WHOID, "WHOID");
                model.XZRYID = entity.XZRYID;
                model.XZRYMC = entity.XZRYMC;
                model.XZRQ = entity.XZRQ;
                model.ORGANID = entity.ORGANID; 
                model.UpdateM("WHOID");
            }
        }
    }
}
