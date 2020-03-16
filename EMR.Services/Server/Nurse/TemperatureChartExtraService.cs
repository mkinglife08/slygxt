/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：HospitalRecordService.cs
// 文件功能描述： 体温单额外服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供公用代码字典相关数据的服务，一般返回与公用代码字典相关的实体或实体集合。
// 创建标识：朱天伟 2019-03-06
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/
using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Server.Nurse
{
    /// <summary>
    /// 体温单额外服务层
    /// </summary>
    public class TemperatureChartExtraService
    {
        /// <summary>
        /// 体温单服务器
        /// </summary>
        TemperatureChartService temperaturechartservice = new TemperatureChartService();

        #region 查

        /// <summary>
        /// 根据病人id以及开始时间和结束时间获得体温额外表
        /// </summary>
        /// <param name="InpatientId"></param>
        /// <param name="StartDay"></param>
        /// <param name="EndDay"></param>
        /// <returns></returns>
        public List<CN_TemperatureChartExtra> GetListByMeasureTime(string InpatientId, string StartDay = "", string EndDay = "")
        {
            string startTime = string.IsNullOrWhiteSpace(StartDay) ? "" : "and MeasureTime >= to_date('" + StartDay + "','yyyy-mm-dd hh24:mi:ss')";//开始时间
            string endTime = string.IsNullOrWhiteSpace(EndDay) ? "" : "and MeasureTime <= to_date('" + EndDay + "','yyyy-mm-dd hh24:mi:ss')";//结束时间
            string strSQL = "select * from  CN_TemperatureChartExtra WHERE inpatientId = '" + InpatientId + "' " + startTime + "  " + endTime + " order by MeasureTime,CreateTime";
            List<CN_TemperatureChartExtra> list = EntityOperate<CN_TemperatureChartExtra>.GetEntityListBySQL(strSQL);//获得体温列表
            return list;
        }


        /// <summary>
        /// 根据病人id以及日期获得体温单额外数据
        /// </summary>
        /// <param name="InpatientId"></param>
        /// <param name="MeasureTime"></param>
        /// <returns></returns>
        public List<CN_TemperatureChartExtra> GetListByInpatientId(string InpatientId, string MeasureTime = "")
        {
            string MeasureTimeStr = "";
            //测量时间
            if (!string.IsNullOrEmpty(MeasureTime))
            {
                MeasureTimeStr = "and to_char(MeasureTime,'yyyy-mm-dd')=to_char('" + MeasureTime + "','yyyy-mm-dd')";
            }
            string sql = string.Format("select * from CN_TemperatureChartExtra where InpatientId='{0}' {1} ", InpatientId, MeasureTimeStr);
            List<CN_TemperatureChartExtra> list = EntityOperate<CN_TemperatureChartExtra>.GetEntityListBySQL(sql);
            return list;
        }


        #endregion
        #region 增删改

        /// <summary>
        /// 增加和保存
        /// </summary>
        /// <param name="info"></param>
        public void SaveInfo(CN_TemperatureChartExtra info)
        {
            //如果体温单id必选不为空
            if (!string.IsNullOrWhiteSpace(info.ChartId) && info.ChartId != "null")
            {
                //检查是否已存在该额外的体温单
                CN_TemperatureChartExtra TceInfo= EntityOperate<CN_TemperatureChartExtra>.GetEntityById(info.ChartId, "ChartId", true);
                //获得病人
                CD_Inpatient inpatient = EntityOperate<CD_Inpatient>.GetEntityById(info.InpatientId, "InpatientId");

                if (TceInfo != null)
                {
                    info.UpdaterTime = DateTime.Now;
                    info.CreateTime = null;
                    info.UpdateM("ChartId");
                }
                else {
                    info.DepartmentId = inpatient.CurrentDeptID;//当前科室
                    info.WardId = inpatient.CurrentWardID;//当前病区
                    info.Creator = info.Updater;//添加的情况下创建医生就是修改医生
                    info.CreateTime = DateTime.Now;//添加情况下
                    info.UpdaterTime = DateTime.Now;
                    info.BedNum = inpatient.BedNumber;//床号
                    info.SaveModelM();
                }
            }

        }

        #endregion
    }
}
