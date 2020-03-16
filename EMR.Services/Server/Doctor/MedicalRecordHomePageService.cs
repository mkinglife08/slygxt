/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：MedicalRecordHomePageService.cs
// 文件功能描述： 病案首页服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病案首页相关数据的服务，一般返回与病案首页相关的实体或实体集合。
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
    public class MedicalRecordHomePageService
    {
        /// <summary>
        /// 保存病案首页数据
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_MedicalRecordHomePage entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.HomePageId) && entity.HomePageId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("HomePageId");
            }
            else
            {
                entity.HomePageId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_MedicalRecordHomePage", ColumnName = "HomePageId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询病案首页数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_MedicalRecordHomePage> GetAll(InpatientFilter iFilter)
        {
            string filter = "1=1";
            if (!string.IsNullOrWhiteSpace(iFilter.keyword))
                filter += string.Format(" and {1} like '%{0}%'", iFilter.keyword, iFilter.KeywordType);
            filter += iFilter.GetQueryString();
            List<CD_MedicalRecordHomePage> list = EntityOperate<CD_MedicalRecordHomePage>.GetEntityList(filter, "OrganID");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_MedicalRecordHomePage>();
            }
            return list;
        }


        /// <summary>
        /// 根据住院病人id获得病案首页
        /// </summary>
        /// <returns></returns>
        public CD_MedicalRecordHomePage GetInfoByInpatientId(string InpatientId)
        {
            CD_MedicalRecordHomePage info = EntityOperate<CD_MedicalRecordHomePage>.GetEntityById(InpatientId, "InpatientId");

            if (info != null)
            {
                if (!string.IsNullOrWhiteSpace(info.Creator))
                {
                    GI_UserInfo Creator = EntityOperate<GI_UserInfo>.GetEntityById(info.Creator, "UserID");
                    info.CreatorName = Creator?.UserName;
                }
                if (!string.IsNullOrWhiteSpace(info.Updater))
                {
                    GI_UserInfo Updater = EntityOperate<GI_UserInfo>.GetEntityById(info.Updater, "UserID");
                    info.UpdaterName = Updater?.UserName;
                }
            }
            return info;
        }
    }
}