/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：ProgressNoteService.cs
// 文件功能描述： 病程记录服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病程记录相关数据的服务，一般返回与病程记录相关的实体或实体集合。
// 创建标识：吕屹凌 2019-1-21
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
    public class ProgressNoteService
    {
        /// <summary>
        /// 保存病程记录
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_ProgressNote entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.ProgressNoteId) && entity.ProgressNoteId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("ProgressNoteId");
            }
            else
            {
                entity.ProgressNoteId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_ProgressNote", ColumnName = "ProgressNoteId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询病程记录数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_ProgressNote> GetAll(ProgressNoteFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<CD_ProgressNote> list = EntityOperate<CD_ProgressNote>.GetEntityList(filter, "CreateTime");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_ProgressNote>();
            }
            return list;
        }
    }
}
