/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：HospitalRecordService.cs
// 文件功能描述： 体温单服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供公用代码字典相关数据的服务，一般返回与公用代码字典相关的实体或实体集合。
// 创建标识：朱天伟 2019-3-04
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
    /// 体温单服务层
    /// </summary>
    public class TemperatureChartService
    {


        #region 增删改查


        /// <summary>
        /// 根据住院病人id体温单
        /// </summary>
        /// <param name="InpatientId">住院病人ID</param>
        /// <param name="MeasureTime">测量时间</param>
        /// <returns></returns>
        public List<CN_TemperatureChart> GetListByInpatientId(string InpatientId,string MeasureTime="")
        {
            string MeasureTimeStr = "";
            //测量时间
            if (!string.IsNullOrEmpty(MeasureTime)) {
                MeasureTimeStr = "and to_char(MeasureTime,'yyyy-mm-dd')=to_char('"+ MeasureTime + "','yyyy-mm-dd')";
            }
            string sql = string.Format("select * from CN_TemperatureChart where InpatientId='{0}' {1} ", InpatientId, MeasureTimeStr);
            List<CN_TemperatureChart> list = EntityOperate<CN_TemperatureChart>.GetEntityListBySQL(sql);
            return list;
        }


        #region 增删改
        /// <summary>
        /// 增加和保存
        /// </summary>
        /// <param name="info"></param>
        public void SaveInfo(CN_TemperatureChart info)
        {
            //如果体温单id不为空则修改
            if (!string.IsNullOrWhiteSpace(info.ChartId) && info.ChartId != "null")
            {
                info.UpdaterTime = DateTime.Now;
                info.CreateTime = null;
                info.UpdateM("ChartId");
            }
            else
            {
                //如果体温单id为空，但是病人id不为空则保存
                if (!string.IsNullOrWhiteSpace(info.InpatientId) && info.InpatientId != "null")
                {
                    //获得病人
                    CD_Inpatient inpatient = EntityOperate<CD_Inpatient>.GetEntityById(info.InpatientId, "InpatientId");

                    //获得新的体温单id
                    info.ChartId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CN_TemperatureChart", ColumnName = "ChartId", OrganID = info.OrganID }) + "";
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

        #endregion


        #region 读取体温信息
        /// <summary>
        /// 读取体温信息
        /// </summary>
        /// <param name="sFirstDate">甘特图开始时间：住院时间+（查看周数-1）*7</param>
        /// <param name="BirthRecordId">新生儿出生记录id</param>
        public ArrayList ReadTemperatureData(string sFirstDate,string BirthRecordId,string InpatientId)
        {
            ArrayList alTT = new ArrayList();//返回一周的数据

            CD_Inpatient inpatient = EntityOperate<CD_Inpatient>.GetEntityById(InpatientId, "InpatientId");//获得病人信息

            
            DateTime dateTimeQuery = DateTime.Parse(sFirstDate);//开始时间转为日期类型
            string sEndDate = dateTimeQuery.AddDays(6).ToString("yyyy-MM-dd");//结束时间
            string startTime = sFirstDate + " 00:00:00";//开始时间加上时分秒
            string endTime = sEndDate + " 23:59:59";//结束时间加上时分秒

            string strCysj = inpatient.LeaveTime.Value.ToString("yyyy-MM-dd");//出院时间

            //如果出院时间不为空，结束时间改为出院时间
            if (strCysj != "")
            {
                TimeSpan time = DateTime.Parse(strCysj.Substring(0, 10)) - DateTime.Parse(sEndDate);
                if (time.Days < 0)
                    sEndDate = strCysj.Substring(0, 10);
            }
            if (BirthRecordId == "")//如果新生儿出生记录id不为空
            {
                BirthRecordId = " and BirthRecordId is null ";
            }
            else
            {
                BirthRecordId = " and yexh='" + BirthRecordId + "' ";
            }
            StringBuilder strSQL = new StringBuilder(
                //"SELECT * FROM T_ZYHS_TWJL WHERE zyxh='" + pi.zyxh + "'" + BirthRecordId + " AND clsj>='" + startTime + "' AND clsj<='" + endTime + "' and (TWJLLB='1' or TWJLLB is null) ORDER BY  clsj,cllx"
                "SELECT * FROM CN_TemperatureChart WHERE inpatientId = '"+ inpatient.InpatientId+ "' "+ BirthRecordId + " and MeasureTime >= to_date('" + startTime + "','yyyy-mm-dd hh24:mi:ss')  and MeasureTime <=to_date('" + endTime + "','yyyy-mm-dd hh24:mi:ss')  order by MeasureTime,CreateTime,TestType"
             );
            List<CN_TemperatureChart> tcList = EntityOperate<CN_TemperatureChart>.GetEntityListBySQL(strSQL.ToString());//获得体温列表

            foreach (CN_TemperatureChart tc in tcList) {
                string sID = tc.ChartId;//体温单id
                string sNid = tc.Updater;//护士id，更新人id
                string sClsj = tc.MeasureTime.ToString();//测量时间
                string sTiwen = tc.Degree;//体温
                
                string sMianbo = tc.Pulse;//脉搏
                string sHuxi = tc.Breath;//呼吸
                string sXy1 = tc.SystolicPressure;//收缩压
                string sXy2 = tc.DiastolicPressure;//舒张压
                string sTwlx = tc.TypeCode;//体温类型代码
                string sSpo2 = tc.Spo;//氧饱和度
                string sCllx = tc.TestType.ToString(); //测量类型，有常规 - 0和降温后半小时 - 1，主要用来画图

                string sIsMb = "";//脉搏类型？0脉搏1心率
                if (!string.IsNullOrEmpty(tc.Pulse))
                {
                    sIsMb = "0";
                }
                else if(!string.IsNullOrEmpty(tc.HeartRate)){
                    sIsMb = "1";
                }
                int nClsj = Convert.ToInt32(sClsj.Substring(0, 2));
                string sBC = tc.Event;//体温补充内容
                if (sBC == "请假" || sBC == "外出" || sBC == "检查")//"请假" "外出" "检查"不需要显示
                {
                    sCllx = "-2";//出来类型=-2代表不需显示
                                 //sTiwen = "37";
                }

                if (sTiwen == "" || sTiwen == "0")//体温如果输入0度，则重新赋为42
                    sTiwen = "42";
                if (sMianbo == "" || sMianbo == "0")//如果脉搏输入0次，则脉搏赋240
                    sMianbo = "200";

                if (sHuxi == "0")
                    sHuxi = "";

                if (sCllx == "1" || sCllx == "2")//半小时1小时记录，脉搏呼吸不显示
                {
                    sMianbo = "200";//240超出了体温单范围，不会显示出来
                    sHuxi = "";
                    TimeTwMbHx ttmh = new TimeTwMbHx(DateTime.Parse(sClsj), float.Parse(sTiwen), int.Parse(sMianbo), sHuxi);
                    ttmh.TiwenLeixing = sTwlx;
                    ttmh.CeliangLeixing = sCllx;
                    ttmh.MiaoboLeixing = sIsMb;
                    ttmh.sBC = sBC;
                    ttmh.sXy1 = sXy1;
                    ttmh.sXy2 = sXy2;
                    ttmh.sSpo2 = sSpo2;
                    alTT.Add(ttmh);
                }
                else
                {
                    TimeTwMbHx ttmh = new TimeTwMbHx(DateTime.Parse(sClsj), float.Parse(sTiwen), int.Parse(sMianbo), sHuxi);
                    ttmh.TiwenLeixing = sTwlx;
                    ttmh.CeliangLeixing = sCllx;
                    ttmh.MiaoboLeixing = sIsMb;
                    ttmh.sBC = sBC;
                    ttmh.sXy1 = sXy1;
                    ttmh.sXy2 = sXy2;
                    ttmh.sSpo2 = sSpo2;
                    alTT.Add(ttmh);
                }
            }

            return alTT;
        }

        /// <summary>
        /// 画点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public int GetAvaPoint(int index, TWPoint[] point)
        {
            int nTopSpace = 21;
            int returnValue = -1;
            for (int i = index; i < point.Length; i++)
            {
                if ((point[i].z < 1) && (point[i].y > nTopSpace))//|| point[i].z==2
                {
                    returnValue = i;
                    break;
                }
                if (point[i].z == -2)//不需要画的点
                {
                    returnValue = -1; break;
                }
            }
            return returnValue;

        }


        #endregion


        #region 读取疼痛强度数据

        public ArrayList ReadTTData(string sFirstDate, string InpatientId)
        {
            ArrayList alTT = new ArrayList();//返回一周的数据
            CD_Inpatient inpatient = EntityOperate<CD_Inpatient>.GetEntityById(InpatientId, "InpatientId");//获得病人信息

            DateTime dateTimeQuery = DateTime.Parse(sFirstDate);
            string sEndDate = dateTimeQuery.AddDays(6).ToString("yyyy-MM-dd");
            string startTime = sFirstDate + " 00:00:00";
            string strCysj = "";//出院时间
            if (inpatient.LeaveTime != null)
            {
                strCysj = inpatient.LeaveTime.Value.ToString("yyyy-MM-dd");//出院时间
            }
            //if (strCysj != "")  //2010.7.13 注释 病人状态为在院时，cysj为当前时间（Doctors_PatientIofoCTR 588行 控制），所以判断条件加了病人状态
            if (strCysj != "")
            {
                TimeSpan time = DateTime.Parse(strCysj.Substring(0, 10)) - DateTime.Parse(sEndDate);
                if (time.Days < 0)
                    sEndDate = strCysj.Substring(0, 10);
            }
            string endTime = sEndDate + " 23:59:59";

            StringBuilder strSQL = new StringBuilder(
                //"SELECT * FROM T_ZYHS_TWJL WHERE zyxh='" + pi.zyxh + "' AND clsj>='" + startTime + "' AND clsj<='" + endTime + "' ORDER BY  clsj,jlsj,cllx";
                "SELECT * FROM CN_TemperatureChart WHERE inpatientId = '" + inpatient.InpatientId + "' and MeasureTime >= to_date('" + startTime + "','yyyy-mm-dd hh24:mi:ss')  and MeasureTime <=to_date('" + endTime + "','yyyy-mm-dd hh24:mi:ss') order by MeasureTime,CreateTime,TestType"
             );

            List<CN_TemperatureChart> tcList = EntityOperate<CN_TemperatureChart>.GetEntityListBySQL(strSQL.ToString());//获得体温列表


            foreach (CN_TemperatureChart tc in tcList)
            {

                string sTt = "0";// reader["ttqd"].ToString();
                string sBC = tc.Event;//体温补充内容
                if (sTt.Trim() != "" || sBC == "请假")
                {
                    string sTtlx = tc.PainScoreId;//疼痛评分 reader["TTLx"].ToString();

                    string sID = tc.ChartId;//体温单id
                    string sNid = tc.Updater;//护士id，更新人id
                    string sClsj = tc.MeasureTime.ToString();//测量时间


                    if (sTtlx.Trim() != "" && sTtlx.Trim() != "0") sTtlx = "1";
                    if (sClsj.Length > 19)
                        sClsj = sClsj.Substring(0, 19);
                    try
                    {
                        DateTime.Parse(sClsj);
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                    int nClsj = Convert.ToInt32(sClsj.Substring(0, 2));
                    if (sBC == "请假" || sBC == "外出" || sBC == "检查")//"请假" "外出" "检查"不需要显示
                    {
                        sTtlx = "-2";//出来类型=-2代表不需显示
                    }
                    float tt = 0;
                    float.TryParse(sTt, out tt);
                    TTClass ttClass = new TTClass(DateTime.Parse(sClsj), tt);
                    ttClass.CeliangLeixing = sTtlx;
                    alTT.Add(ttClass);
                }
            }
            return alTT;
        }

        #endregion
    }
}
