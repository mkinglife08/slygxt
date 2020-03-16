/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：MedicalRecordAccessRecordService.cs
// 文件功能描述： 病历查阅记录，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病案首页相关数据的服务，一般返回与病案首页相关的实体或实体集合。
// 创建标识：朱天伟 2019年4月15日
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
using System.Configuration;

namespace EMR.Services.Server.Doctor
{
    /// <summary>
    /// 病历查阅记录服务层
    /// </summary>
    public class MedicalRecordAccessRecordService
    {
        /// <summary>
        /// 审阅通过后可审阅多久（小时）
        /// </summary>
        public int AccessStateHour = ConfigurationManager.AppSettings["AccessStateHour"] == null ? 24 : int.Parse(ConfigurationManager.AppSettings["AccessStateHour"]);

        #region 增删改
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        public void save(CD_MedicalRecordAccessRecord entity) {

            if (!string.IsNullOrWhiteSpace(entity.AccessID) && entity.AccessID != "null")
            {
                entity.UpdateM("HomePageId");
            }
            else
            {
                entity.AccessID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_MedicalRecordAccessRecord", ColumnName = "AccessID", OrganID = entity.OrganID }) + "";
                //申请状态默认为0未审阅
                entity.AccessState = 0;
                //如果申请人id为空，则创建人为申请人
                if (string.IsNullOrWhiteSpace(entity.ApplyUserID)) { entity.ApplyUserID = entity.Creator; entity.ApplyDate = entity.CreateTime; }
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 更新病历查阅状态
        /// </summary>
        /// <param name="AccessIDs">需要更新的id(多个以逗号分隔)</param>
        /// <param name="AccessState">查阅状态0审阅1已审阅</param>
        public void UpdateAccessState(string AccessIDs, string AccessState) {

            if (!string.IsNullOrWhiteSpace(AccessIDs))
            {
                foreach (string AccessID in AccessIDs.Trim(',').Split(','))
                {
                    CD_MedicalRecordAccessRecord entity = EntityOperate<CD_MedicalRecordAccessRecord>.GetEntityById(AccessID, "AccessID");
                    if (entity != null) {
                        entity.AccessState = int.Parse(AccessState);
                        entity.UpdateTime = DateTime.Now;
                        entity.UpdateM("AccessID");
                    }
                }
            }

        }

        #endregion

        #region 查

        /// <summary>
        /// 根据病人ID和申请人ID查询病历查阅记录
        /// </summary>
        /// <param name="InpatientId">病人ID</param>
        /// <param name="ApplyUserID">申请人ID</param>
        /// <returns></returns>
        public CD_MedicalRecordAccessRecord GetInfoByInpatientIdAndApplyUserID(string InpatientId, string ApplyUserID) {
            CD_MedicalRecordAccessRecord info = EntityOperate<CD_MedicalRecordAccessRecord>.GetEntityBySQL("select * from CD_MedicalRecordAccessRecord where InpatientId='" +InpatientId + "' and ApplyUserID='" + ApplyUserID + "' and sysdate+numtodsinterval(-"+ AccessStateHour + ",'hour')<= UpdateTime "); 
            return info;
        }

        /// <summary>
        /// 根据病人ID查询病历查阅记录
        /// </summary>
        /// <param name="InpatientId">病人ID</param>
        /// <param name="AccessState">审阅状态</param>
        /// <returns></returns>
        public List<CD_MedicalRecordAccessRecord> GetListByInpatientId(string InpatientId, int AccessState=-1, string ApplyUserName = "")
        {
            string filter = "";
            //审阅状态
            if (AccessState >= 0) {filter += " and AccessState=" + AccessState;}
            //申请医生姓名
            if (!string.IsNullOrWhiteSpace(ApplyUserName)) { filter += " and u.UserName like '%"+ ApplyUserName + "%' "; }

            string sql = "select m.*,u.UserName as ApplyUserName from CD_MedicalRecordAccessRecord m left join GI_UserInfo u on u.UserId=m.applyuserid where m.InpatientId='" + InpatientId + "' " + filter;
            List<CD_MedicalRecordAccessRecord> list = EntityOperate<CD_MedicalRecordAccessRecord>.GetEntityListBySQL(sql);
            return list;
        }

        #endregion


    }
}
