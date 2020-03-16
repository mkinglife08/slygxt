/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：StructuredTemplateService.cs
// 文件功能描述： 结构化模板服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供结构化模板相关数据的服务，一般返回与结构化模板相关的实体或实体集合。
// 创建标识：吕屹凌 2019-2-20
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
    public class StructuredTemplateService
    {
        /// <summary>
        /// 保存模板数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string SaveInfo(AI_StructuredTemplate entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.TemplateId) && entity.TemplateId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("TemplateId");
            }
            else
            {
                entity.TemplateId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "AI_StructuredTemplate", ColumnName = "TemplateId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
            return entity.TemplateId;
        }

        /// <summary>
        /// 根据筛选条件查询模板数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<AI_StructuredTemplate> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<AI_StructuredTemplate> list = EntityOperate<AI_StructuredTemplate>.GetEntityList(filter, "CreateTime");
            if (list == null || list.Count <= 0)
            {
                return new List<AI_StructuredTemplate>();
            }
            return list;
        }
    }
}
