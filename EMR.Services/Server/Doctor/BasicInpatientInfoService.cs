/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：BasicInpatientInfoService.cs
// 文件功能描述： 病人基本信息服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病人基本信息相关数据的服务，一般返回与病人基本信息相关的实体或实体集合。
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
    public class BasicInpatientInfoService
    {
        /// <summary>
        /// 保存病人基本信息
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_BasicInpatientInfo entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.HealthCard) && entity.HealthCard != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("HealthCard");
            }
        }

        /// <summary>
        /// 根据筛选条件查询病人基本信息数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_BasicInpatientInfo> GetAll(InpatientFilter iFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(iFilter.keyword))
                filter += string.Format(" and {1} like '%{0}%'", iFilter.keyword, iFilter.KeywordType);
            filter += iFilter.GetQueryString();
            List<CD_BasicInpatientInfo> list = EntityOperate<CD_BasicInpatientInfo>.GetEntityList(filter, "OrganID");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_BasicInpatientInfo>();
            }
            return list;
        }
    }
}
