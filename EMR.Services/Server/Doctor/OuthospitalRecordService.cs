/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：OuthospitalRecordService.cs
// 文件功能描述： 出院记录服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供出院记录相关数据的服务，一般返回与出院记录相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-24 
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
    public class OuthospitalRecordService
    {
        /// <summary>
        /// 保存出院记录
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_OuthospitalRecord entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.OuthospitalRecordId) && entity.OuthospitalRecordId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("OuthospitalRecordId");
            }
            else
            {
                entity.OuthospitalRecordId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_OuthospitalRecord", ColumnName = "OuthospitalRecordId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询出院记录数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_OuthospitalRecord> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<CD_OuthospitalRecord> list = EntityOperate<CD_OuthospitalRecord>.GetEntityList(filter, "OrganID");
            
            if (list == null || list.Count <= 0)
            {
                return new List<CD_OuthospitalRecord>();
            }
            return list;
        }
    }
}
