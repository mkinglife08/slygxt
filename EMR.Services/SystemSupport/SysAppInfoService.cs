/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：SysAppInfoService.cs
// 文件功能描述： 系统模块服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供系统模块相关数据的服务，一般返回与系统模块相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using EMR.Services.Interface;
using System;
using System.Collections.Generic;

namespace EMR.Services.SystemSupport
{
    public class SysAppInfoService : ISerialPrimaryKey
    {
        /// <summary>
        /// 获取自增主键
        /// </summary>
        /// <param name="OrganId">组织机构ID</param>
        /// <returns>主键ID</returns>
        public string GetPrimaryId(string OrganId = "0")
        {
            return CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "GI_SYSAPPINFO", ColumnName = "SYSID", OrganID = OrganId }) + "";
        }
        public void SaveInfo(GI_SYSAPPINFO entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.SYSID) && entity.SYSID != "null")
            {
                entity.UpdateM("SYSID");
            }
            else
            {
                entity.SYSID = GetPrimaryId();
                entity.ModifyTime = DateTime.Now;
                entity.SaveModelM();
            }
        }

        public List<GI_SYSAPPINFO> GetAll(CommonFilter commonFilter)
        {
            string Filter = "ISCANCE != 1";
            if (!string.IsNullOrWhiteSpace(commonFilter.keyword))
                Filter += string.Format(" and (MODULENAME like '%{0}%' or MODULESHORTNAME like '%{0}%')", commonFilter.keyword);
            Filter += commonFilter.GetQueryString();
            List<GI_SYSAPPINFO> list = EntityOperate<GI_SYSAPPINFO>.GetEntityList(Filter).FindAll(f=>f.IsCance != 1);
            if (list == null || list.Count <= 0)
            {
                return new List<GI_SYSAPPINFO>();
            }
            list.ForEach((f) =>
            {
                f.IsCanceName = f.IsCance != 1 ? "正常" : "作废";
            });
            return list;
        }
    }
}
