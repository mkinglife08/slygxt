/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：InpatientService.cs
// 文件功能描述： 住院病人服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供住院病人相关数据的服务，一般返回与住院病人相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-24 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using EMR.Services.Server.Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Server.Doctor
{
    public class InpatientService
    {
        InpatientAuthorizedService inpatientauthorizedservice = new InpatientAuthorizedService();//住院病人授权服务层

        


        #region 增删改查
        /// <summary>
        /// 保存住院病人
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_Inpatient entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.InpatientId) && entity.InpatientId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("InpatientId");
            }
            else
            {
                entity.InpatientId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_Inpatient", ColumnName = "InpatientId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询住院病人数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <param name="where">其他条件</param>
        /// <returns></returns>
        public List<CD_Inpatient> GetAll(InpatientFilter iFilter,string where="")
        {
            string filter = "1=1";
            //关键词
            if (!string.IsNullOrWhiteSpace(iFilter.keyword)) { filter += string.Format(" and {1} like '%{0}%'", iFilter.keyword, iFilter.KeywordType); }
            //档案状态，1：在院，2：已出院，3：待归档，4：已归档
            if (!string.IsNullOrWhiteSpace(iFilter.Status)) {
                switch (iFilter.Status) {
                    case "1": filter += string.Format(" and LeaveTime is null ");break;//在院
                    case "2": filter += string.Format(" and LeaveTime is not null and  MedicalRecordState<>1 "); break;//已出院 不包括已归档
                    case "3": filter += string.Format(" and MedicalRecordState=0 "); break;//待归档
                    case "4": filter += string.Format(" and MedicalRecordState=1 "); break;//已归档
                    default:break;
                }
            }
            //病历所属
            if (!string.IsNullOrWhiteSpace(iFilter.Group)&& !string.IsNullOrWhiteSpace(iFilter.UserID)) {
                switch (iFilter.Group) {
                    case "1": filter += string.Format(" and AttendingDoctorId='{0}' ",iFilter.UserID);break;//主诊医生过滤
                    case "4": filter += string.Format(" and INPATIENTID in (select INPATIENTID from CD_InpatientAuthorized where AUTHORIZEDPERSONID='{0}' and sysdate+numtodsinterval(-" + inpatientauthorizedservice.AuthorizedHours + ",'hour')<= AUTHORIZEDPERSONTIME) ", iFilter.UserID); break;//授权病人
                    case "5": filter += string.Format(" and CurrentDeptID in (select DPETID from GI_USERINFO where USERID='{0}') ", iFilter.UserID); ; break;//本科室
                    default:break;
                }
            }


            filter += iFilter.GetQueryString() + where;
            List<CD_Inpatient> list = EntityOperate<CD_Inpatient>.GetEntityList(filter, "OrganID");
            
            if (list == null || list.Count <= 0)
            {
                return new List<CD_Inpatient>();
            }
            list.ForEach((f) => {
                #region 科室和病区组
                //科室
                AI_DeptInfo deptInfo = EntityOperate<AI_DeptInfo>.GetEntityById(f.CurrentDeptID, "DeptID");
                f.CurrentDeptName = deptInfo == null ? "" : deptInfo?.DeptName;
                //病区
                AI_DeptInfo Ward = EntityOperate<AI_DeptInfo>.GetEntityById(f.CurrentWardID, "DeptID");
                f.CurrentWardName = Ward == null ? "" : Ward?.DeptName;
                #endregion
            });

            return list;
        }

        /// <summary>
        /// 根据病人住院id获得病人实体
        /// </summary>
        /// <param name="InpatientId"></param>
        /// <returns></returns>
        public CD_Inpatient GetInfoByInpatientId(string InpatientId) {
            CD_Inpatient info = EntityOperate<CD_Inpatient>.GetEntityById(InpatientId, "InpatientId");
            return info;
        }
        #endregion

        #region 检查汇总明细

        #region 超时时间
        /// <summary>
        /// 住院记录
        /// </summary>
        public int ryjl_pysj = 24;
        /// <summary>
        /// 住院记录单位
        /// </summary>
        public string ryjl_pysj_dw = "h";
        /// <summary>
        /// 首次病程记录
        /// </summary>
        public int scbcjl_pysj = 48;
        /// <summary>
        /// 首次病程记录 单位
        /// </summary>
        public string scbcjl_pysj_dw = "h";
        /// <summary>
        /// 诊疗知情同意记录
        /// </summary>
        public int zlzqtyjl_pysj = 72;
        /// <summary>
        /// 诊疗知情同意记录 单位
        /// </summary>
        public string zlzqtyjl_pysj_dw = "h";
        /// <summary>
        /// 首次主治查房
        /// </summary>
        public int sczzcf_pysj = 72;
        /// <summary>
        /// 首次主治查房单位
        /// </summary>
        public string sczzcf_pysj_dw = "h";
        /// <summary>
        /// 手术记录
        /// </summary>
        public int ssjl_pysj = 24;
        /// <summary>
        /// 手术记录单位
        /// </summary>
        public string ssjl_pysj_dw = "h";
        /// <summary>
        /// 术后首次病程兼谈话记录
        /// </summary>
        public int shscbc_pysj = 48;
        /// <summary>
        /// 术后首次病程兼谈话记录单位
        /// </summary>
        public string shscbc_pysj_dw = "h";
        /// <summary>
        /// 转科相关
        /// </summary>
        public int zrjl_pysj = 24;
        /// <summary>
        /// 转科相关单位
        /// </summary>
        public string zrjl_pysj_dw = "h";
        /// <summary>
        /// 手术知情同意记录
        /// </summary>
        public int sszqtyjl_pysj = -1;
        /// <summary>
        /// 手术知情同意记录 单位
        /// </summary>
        public string sszqtyjl_pysj_dw = "d";
        /// <summary>
        /// 日常病程记录
        /// </summary>
        public int rcbcjl_pysj_zq = 3;
        /// <summary>
        /// 主治查房
        /// </summary>
        public int zzcf_pysj_zq = 7;
        /// <summary>
        /// 主任查房
        /// </summary>
        public int zrcf_pysj_zq = 7;
        /// <summary>
        /// 阶段小结
        /// </summary>
        public int jdxj_pysj_zq = 31;
        #endregion

        public string CheckSummaryDetail(string InpatientId,string CheckSummaryTime) {

            StringBuilder sb = new StringBuilder();
            string sql = "";
            //住院记录-查询保存状态的住院记录
            sb.Append(SetWwcXm(ryjl_pysj_dw, ryjl_pysj, CheckSummaryTime, "select RecordTime jlsj from CD_HospitalRecord where InpatientId=" + InpatientId, "住院记录"));
            //首次病程记录
            sb.Append(SetWwcXm(scbcjl_pysj_dw, scbcjl_pysj, CheckSummaryTime, "select ProgressNoteTime jlsj from CD_ProgressNote where ProgressTypeId='50' and  InpatientId=" + InpatientId, "首次病程记录"));
            //首次主治查房
            sb.Append(SetWwcXm(sczzcf_pysj_dw, sczzcf_pysj, CheckSummaryTime, "select min(ProgressNoteTime) jlsj,PROGRESSTYPEID from CD_ProgressNote where PROGRESSTYPEID='1' and InpatientId=" + InpatientId + " group by PROGRESSTYPEID", "首次主治查房"));
            //手术相关（手术记录、术后主刀医师查房）
            //转科相关
            //日常病程记录
            #region 日常病程记录
            //DateTime bxwcsj = Convert.ToDateTime(Convert.ToDateTime(CheckSummaryTime).ToString("yyyy-MM-dd 23:59:59")).AddDays(rcbcjl_pysj_zq);
            //sql = string.Format(@"select ProgressNoteTime jlsj,PROGRESSTYPEID from CD_ProgressNote where PROGRESSTYPEID='1' and ProgressNoteTime>'{0}' and ProgressNoteTime<='{1}' and InpatientId='{2}' order by ProgressNoteTime desc", InpatientId);
            //DataSet dsBcJL = dac.DataSetQuery(sql);
            //for (int i = 0; i < dsBcJL.Tables[0].Rows.Count; i++)
            //{
            //    DataRow drBcJl = dsBcJL.Tables[0].Rows[i];
            //    if (Convert.ToDateTime(drBcJl["jlsj"].ToString()) > bxwcsj)
            //        wwcxm += "<font style=\"color:red\">【应在" + bxwcsj + "之前完成的日常病程记录超时完成，完成时间" + drBcJl["jlsj"].ToString() + "】</font><br/>";

            //    bxwcsj = Convert.ToDateTime(Convert.ToDateTime(drBcJl["jlsj"]).ToString("yyyy-MM-dd 23:59:59")).AddDays(rcbcjl_pysj_zq);
            //}
            //if (System.DateTime.Now > bxwcsj)
            //    wwcxm += "【应在" + bxwcsj + "之前完成的日常病程记录超时未完成】<br/>";
            //dsBcJL.Clear();
            #endregion
            //主治查房
            for (DateTime dt = Convert.ToDateTime(CheckSummaryTime); dt < System.DateTime.Now; dt = dt.AddDays(zzcf_pysj_zq))
            {
                sql = string.Format(@"select ProgressNoteTime jlsj,PROGRESSTYPEID from CD_ProgressNote where PROGRESSTYPEID='1' and ProgressNoteTime>'{0}' and ProgressNoteTime<='{1}' and InpatientId='{2}' order by ProgressNoteTime desc"
                                       , dt.ToString("yyyy-MM-dd HH:mm:ss"), dt.AddDays(zzcf_pysj_zq).ToString("yyyy-MM-dd HH:mm:ss"), InpatientId);
                sb.Append(SetWwcXm("d", zzcf_pysj_zq, dt.ToString("yyyy-MM-dd 23:59:59"), sql, "主治查房"));
            }
            //主任查房
            for (DateTime dt = Convert.ToDateTime(CheckSummaryTime); dt < System.DateTime.Now; dt = dt.AddDays(zrcf_pysj_zq))
            {
                sql = string.Format(@"select ProgressNoteTime jlsj,PROGRESSTYPEID from CD_ProgressNote where PROGRESSTYPEID='18' and ProgressNoteTime>'{0}' and ProgressNoteTime<='{1}' and InpatientId='{2}' order by ProgressNoteTime desc"
                                       , dt.ToString("yyyy-MM-dd HH:mm:ss"), dt.AddDays(zrcf_pysj_zq).ToString("yyyy-MM-dd HH:mm:ss"), InpatientId);
                sb.Append(SetWwcXm("d", zrcf_pysj_zq, dt.ToString("yyyy-MM-dd 23:59:59"), sql, "主任查房"));
            }
            //阶段小结

            return sb.ToString();
        }


        public string SetWwcXm(string dw, int pysj, string xdsj,string sql, string jlmc)
        {
            string wwcxm = "";
            string bxwcsj = "";
            switch (dw)
            {
                case "d":
                    bxwcsj = Convert.ToDateTime(xdsj).AddDays(pysj).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case "h":
                    bxwcsj = Convert.ToDateTime(xdsj).AddHours(pysj).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                case "m":
                    bxwcsj = Convert.ToDateTime(xdsj).AddMinutes(pysj).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
            }
            DataSet dsWs = EntityOperate<object>.GetDataSetBySql(sql);
            if (dsWs.Tables[0].Rows.Count <= 0)
            {
                if (System.DateTime.Now > Convert.ToDateTime(bxwcsj))
                {
                    wwcxm += "【应在" + bxwcsj + "之前完成的" + jlmc + "超时未完成】<br/>";
                }
            }
            else if (Convert.ToDateTime(dsWs.Tables[0].Rows[0]["jlsj"].ToString()) > Convert.ToDateTime(bxwcsj))
            {
                wwcxm += "<font style=\"color:red\">【应在" + bxwcsj + "之前完成的" + jlmc + "超时完成，实际完成时间" + dsWs.Tables[0].Rows[0]["jlsj"].ToString() + "】</font><br/>";
            }
            dsWs.Clear();
            return wwcxm;
        }

        #endregion
    }
}
