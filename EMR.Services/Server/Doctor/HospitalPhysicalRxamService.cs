/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictService.cs
// 文件功能描述： 体格检查服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供公用代码字典相关数据的服务，一般返回与公用代码字典相关的实体或实体集合。
// 创建标识：朱天伟 2019-02-19
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
    public class HospitalPhysicalRxamService
    {
        #region 增删改
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="info"></param>
        public void SaveInfo(CD_HospitalPhysicalRxam info) {
            if (!string.IsNullOrWhiteSpace(info.PhysicalExamId) && info.PhysicalExamId != "null")
            {
                info.UpdateTime = DateTime.Now;
                info.CreateTime = null;
                info.UpdateM("HospitalRecordId");
            }
            else {
                if (!string.IsNullOrWhiteSpace(info.InpatientId) && info.InpatientId != "null")
                {
                    CD_HospitalPhysicalRxam nowinfo = GetInfoByInpatientId(info.InpatientId);
                    if (nowinfo != null)
                    {
                        info.UpdateTime = DateTime.Now;
                        info.CreateTime = null;
                        info.UpdateM("InpatientId");
                    }
                    else
                    {
                        info.PhysicalExamId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_HospitalPhysicalRxam", ColumnName = "PhysicalExamId", OrganID = info.OrganID }) + "";
                        info.Creator = info.Updater;//添加的情况下创建医生就是修改医生
                        info.CreateTime = DateTime.Now;//添加情况下
                        info.UpdateTime = DateTime.Now;
                        info.SaveModelM();
                    }
                }
            }
        }
        #endregion


        /// <summary>
        /// 根据住院病人id获得体格检查
        /// </summary>
        /// <returns></returns>
        public CD_HospitalPhysicalRxam GetInfoByInpatientId(string InpatientId)
        {
            CD_HospitalPhysicalRxam info = EntityOperate<CD_HospitalPhysicalRxam>.GetEntityById(InpatientId, "InpatientId");

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
