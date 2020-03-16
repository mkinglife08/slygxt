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
    public class FeedBackService
    {
        /// <summary>
        /// 获取所有反馈单
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_YGDCFKD> GetAllFkd(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_YGDCFKD> list = EntityOperate<BUS_YGDCFKD>.GetEntityList(filter, "FKDID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_YGDCFKD>();
            }
            return list;
        }


        /// <summary>
        /// 根据反馈单ID获取所有反馈单数据
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_YGDCFKD_SOURCE> GetAllFkdSource(CommonFilter iFilter, string FKDID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            if (!string.IsNullOrWhiteSpace(FKDID)) { filter += " and FKDID=" + FKDID + ""; } else { filter += " and FKDID=-1"; }

            List<BUS_YGDCFKD_SOURCE> list = EntityOperate<BUS_YGDCFKD_SOURCE>.GetEntityList(filter, "FKDSOURCEID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_YGDCFKD_SOURCE>();
            }
            return list;
        }

        /// <summary>
        /// 根据反馈单数据ID获取单条反馈单数据
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public BUS_YGDCFKD_SOURCE GetFkdSourceByID(string FKDSOURCEID)
        {  
            BUS_YGDCFKD_SOURCE model = EntityOperate<BUS_YGDCFKD_SOURCE>.GetEntityById(FKDSOURCEID, "FKDSOURCEID");
            return model;
        }

        /// <summary>
        /// 根据反馈单数据ID 查询单条反馈单数据
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<BUS_YGDCFKD, BUS_YGDCFKD_SOURCE> GetFkdSourceModel(CommonFilter iFilter, string fkdSourceId)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
           // if (string.IsNullOrWhiteSpace(fkdSourceId)) { filter += " and FKDSOURCEID=" + fkdSourceId + ""; }

            BUS_YGDCFKD_SOURCE bus_ygdcfkd_source = EntityOperate<BUS_YGDCFKD_SOURCE>.GetEntityById(fkdSourceId, "FKDSOURCEID");

            BUS_YGDCFKD bus_ygdcfkd = EntityOperate<BUS_YGDCFKD>.GetEntityById((bus_ygdcfkd_source == null ? "" : bus_ygdcfkd_source.FKDID), "FKDID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (bus_ygdcfkd_source == null ? "" : " and deptid='" + bus_ygdcfkd.DEPTID + "'"), "ParentID,DeptID");
            bus_ygdcfkd_source.DpetList = departList;

            var tupe = new Tuple<BUS_YGDCFKD, BUS_YGDCFKD_SOURCE>(bus_ygdcfkd, bus_ygdcfkd_source);

            return tupe;
        }

        /// <summary>
        /// 保存反馈单和反馈单数据
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_YGDCFKD fkdModel, BUS_YGDCFKD_SOURCE fkdSourceModel)
        {
            if (string.IsNullOrWhiteSpace(fkdModel.FKDID))
            {
                fkdModel.FKDID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_YGDCFKD", ColumnName = "FKDID", OrganID = fkdModel.ORGANID }) + "";
                fkdModel.SaveModelM();
            }

            if (string.IsNullOrWhiteSpace(fkdSourceModel.FKDSOURCEID))
            {
                fkdSourceModel.FKDSOURCEID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_YGDCFKD_SOURCE", ColumnName = "FKDSOURCEID", OrganID = fkdSourceModel.ORGANID }) + "";
                fkdSourceModel.FKDID = fkdModel.FKDID;
                fkdSourceModel.SaveModelM();
            }
            else
            {
                var model = EntityOperate<BUS_YGDCFKD_SOURCE>.GetEntityById(fkdSourceModel.FKDSOURCEID, "FKDSOURCEID");
                model.CZWT = fkdSourceModel.CZWT;
                model.XCZP = fkdSourceModel.XCZP;
                model.ZGJY = fkdSourceModel.ZGJY;
                model.KSYYFX = fkdSourceModel.KSYYFX;
                model.KSZGCS = fkdSourceModel.KSZGCS;
                model.XGPJ = fkdSourceModel.XGPJ;
                model.BZ = fkdSourceModel.BZ;
                model.UpdateM("FKDSOURCEID");
            }
        }
    }
}
