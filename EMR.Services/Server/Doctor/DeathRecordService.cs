﻿/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：DeathRecordService.cs
// 文件功能描述： 死亡记录服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供死亡记录相关数据的服务，一般返回与死亡记录相关的实体或实体集合。
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
    public class DeathRecordService
    {
        /// <summary>
        /// 保存死亡记录
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_DeathRecord entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.DeathId) && entity.DeathId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("DeathId");
            }
            else
            {
                entity.DeathId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_DeathRecord", ColumnName = "DeathId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询死亡记录数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_DeathRecord> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<CD_DeathRecord> list = EntityOperate<CD_DeathRecord>.GetEntityList(filter, "DeathId");
            
            if (list == null || list.Count <= 0)
            {
                return new List<CD_DeathRecord>();
            }
            return list;
        }
    }
}
