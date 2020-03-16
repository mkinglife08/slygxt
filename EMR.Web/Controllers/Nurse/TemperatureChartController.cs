/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：TemperatureChartController.cs
// 文件功能描述： 体温单控制层
// 创建标识：朱天伟 2019-03-01
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Nurse;
using EMR.Web.Controllers.Page;
using EMR.Web.Extension.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Drawing2D;

namespace EMR.Web.Controllers.Nurse
{
    public class TemperatureChartController : BaseController
    {
        TemperatureChartService temperatureChartService = new TemperatureChartService();

        #region 增删改查

        /// <summary>
        /// 根据住院病人id以及测量日期获得体温单记录
        /// </summary>
        /// <returns></returns>
        public string GetInfoByInpatientId()
        {
            return base.ExecuteActionJsonResult("获取体温单记录", () =>
            {
                List<CN_TemperatureChart> list = temperatureChartService.GetListByInpatientId(Request["InpatientId"], Request["day"]);
                int curpage = 0, limit = 10;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }


        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string Save()
        {

            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                CN_TemperatureChart info = base.GetPageData<CN_TemperatureChart>(0);
                info.ChartId = string.IsNullOrWhiteSpace(info.ChartId) ? null : info.ChartId;
                temperatureChartService.SaveInfo(info);
                return new WebApi_Result();
            });
        }

        #endregion

        #region 体温单甘特图
        /// <summary>
        /// 获得体温甘特图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTemperatureChartImg()
        {
            string BirthRecordId = string.IsNullOrWhiteSpace(Request.QueryString["BirthRecordId"]) ? "" : Request.QueryString["BirthRecordId"];
            string sFirstDate = Request["StartDay"];
            string InpatientId = Request["InpatientId"];

            string strFontName = "Arial, " + "宋体";
            int iFontSize = 8;
            int iSmallFontSize = 8;
            int iXueYaFontSize = 7;
            int iMaxFontSize = 12;

            Font foreFont = new Font(strFontName, iFontSize, FontStyle.Regular); //FontStyle.Bold );
            Font foreSmallFont = new Font(strFontName, iSmallFontSize, FontStyle.Regular);
            Font foreXueYaFont = new Font(strFontName, iXueYaFontSize, FontStyle.Regular);
            Font foreMaxFont = new Font(strFontName, iMaxFontSize, FontStyle.Regular);

            //行数 
            int nVerticalPointCount = 46;
            //列数
            int nHorizonPointCount = 42;
            //脉搏最大值
            int nMaxMaibo = 200;// 160;
                                //体温最大值
            int nMaxTiwen = 42;
            //小方格的宽度
            int nWidthPerGrid = 12;
            //小方格的高度
            int nHeightPerGrid = 8;
            //中间横线的位置
            int nRedLine = 25;

            int nLeftSpace = 99;   //左边坐标
            int nDotOffset = 0;     //体温和脉搏点的偏移量，目的是将点置于格子的中央7
            int nTopSpace = 20 + 1;   //绘制时间2,6,10
            int nBottomSpace = 40;  // 绘制呼吸次数
            int nBottomXy = 25;     //绘制血压
            int nBottomSpo2 = 25;//绘制Spo2
            int iWidth = nWidthPerGrid * nHorizonPointCount + nLeftSpace + 1; //必须+1
            int iHeight = nHeightPerGrid * nVerticalPointCount + nTopSpace + 1 + nBottomSpace + nBottomXy + nBottomSpo2;
            Color bgColor = Color.White;
            Color foreColor = Color.Blue;
            Bitmap Pic = new Bitmap(iWidth, iHeight, PixelFormat.Format32bppArgb);
            Graphics graph = Graphics.FromImage(Pic);
            Rectangle r = new Rectangle(0, 0, iWidth, iHeight);
            graph.FillRectangle(new SolidBrush(bgColor), r);

            Pen penSlimLine = new Pen(Color.Gray);    //坐标线           
            Pen penRedLine = new Pen(Color.Red, 3);
            Pen penThickLine = new Pen(Color.Black, 2);    //Gray
            int nLeftScalarCount = 0;
            //呼吸
            int yHuxicishu = 0;
            //血压
            int yXueYa = 0;
            //spo2
            int ySpo2 = 0;

            #region 写左边坐标的刻度
            for (int i = 0; i <= nVerticalPointCount; i++)  //写左边坐标的刻度
            {
                int x1 = 0;
                int y1 = i * nHeightPerGrid + nTopSpace;
                if (i == 0)
                {
                    graph.DrawString("    脉搏         体温", foreSmallFont, new SolidBrush(Color.Black), new Point(x1, y1 - 18));
                    StringFormat stringFormat1 = new StringFormat();
                    stringFormat1.FormatFlags = StringFormatFlags.DirectionVertical;
                    graph.DrawString("疼痛强度", foreSmallFont, new SolidBrush(Color.Black), new Point(x1 + 20, (nVerticalPointCount * nHeightPerGrid - 29)), stringFormat1);
                }
                x1 += 5;
                y1 += 2;

                //if (i % 5 == 0 && i != nVerticalPointCount)
                if (i % 5 == 0 && i != nVerticalPointCount - 1 && i != nVerticalPointCount - 6)
                {
                    if (nMaxTiwen - nLeftScalarCount > 34)
                    {
                        string sScalar = "";
                        if (nMaxMaibo - nLeftScalarCount * 20 > 99)
                            sScalar = string.Format(" {0,3}         {1}℃", nMaxMaibo - nLeftScalarCount * 20, nMaxTiwen - nLeftScalarCount);
                        else
                            sScalar = string.Format(" {0,3}          {1}℃", nMaxMaibo - nLeftScalarCount * 20, nMaxTiwen - nLeftScalarCount);
                        graph.DrawString(sScalar, foreFont, new SolidBrush(Color.Black), new Point(x1, y1));
                        nLeftScalarCount++;
                    }
                }

                if (i == nVerticalPointCount)
                {
                    string sScalar = "呼吸(次/分钟)";
                    yHuxicishu = y1 + 10;
                    graph.DrawString(sScalar, foreFont, new SolidBrush(Color.Black), new Point(x1, y1 + 10));
                    nLeftScalarCount++;

                    sScalar = "血压(mmHg)";
                    yXueYa = y1 + nBottomSpace;
                    graph.DrawString(sScalar, foreFont, new SolidBrush(Color.Black), new Point(x1, y1 + 43));
                    nLeftScalarCount++;


                    sScalar = "SpO2(%)";
                    ySpo2 = y1 + nBottomXy + nBottomSpace + 5;
                    graph.DrawString(sScalar, foreFont, new SolidBrush(Color.Black), new Point(x1, ySpo2));
                    nLeftScalarCount++;

                }
            }
            #endregion

            #region 画水平线
            for (int i = 0; i <= nVerticalPointCount; i++)  //画水平线
            {
                int x1 = 0;
                int y1 = i * nHeightPerGrid + nTopSpace;
                int x2 = iWidth;
                int y2 = i * nHeightPerGrid + nTopSpace;
                if (i == nRedLine)
                {
                    graph.DrawLine(penRedLine, new Point(x1, y1), new Point(x2, y2));
                }
                else if (i > (nVerticalPointCount - 6) && i != nVerticalPointCount)
                {
                    graph.DrawLine(penSlimLine, new Point(nLeftSpace - 50, y1), new Point(x2, y2));
                }
                else if ((i % 5 == 0 || i == nVerticalPointCount) && i != nVerticalPointCount - 1)//else if (i % 5 == 0 || i == nVerticalPointCount)
                {
                    graph.DrawLine(penThickLine, new Point(x1, y1), new Point(x2, y2));
                }
                else
                {
                    x1 += nLeftSpace;
                    graph.DrawLine(penSlimLine, new Point(x1, y1), new Point(x2, y2));
                }
            }
            graph.DrawLine(penThickLine, new Point(0, nVerticalPointCount * nHeightPerGrid + nTopSpace + nBottomSpace), new Point(iWidth, nVerticalPointCount * nHeightPerGrid + nTopSpace + nBottomSpace));//血压
            graph.DrawLine(penThickLine, new Point(0, nVerticalPointCount * nHeightPerGrid + nTopSpace + nBottomSpace + nBottomXy), new Point(iWidth, nVerticalPointCount * nHeightPerGrid + nTopSpace + nBottomSpace + nBottomXy));//Spo2

            #endregion

            #region 写顶部坐标的刻度
            int nTopScalarCount = 2;
            int num = 0;
            for (int i = 0; i < nHorizonPointCount; i++)    //写顶部坐标的刻度
            {
                int x1 = i * nWidthPerGrid - 3;
                int y1 = 0;
                x1 += nLeftSpace;
                y1 += nTopSpace - 15;
                if (i % 3 == 0)
                {
                    nTopScalarCount = 2;
                }
                if (i % 3 == 2)
                {
                    x1 -= 3;
                }
                if ((num % 6 > 1) && (num % 6 < 5))
                    graph.DrawString(string.Format(" {0}", nTopScalarCount), foreSmallFont, new SolidBrush(Color.Black), new Point(x1, y1 - 7));
                else
                    graph.DrawString(string.Format(" {0}", nTopScalarCount), foreSmallFont, new SolidBrush(Color.Red), new Point(x1, y1 - 7));
                nTopScalarCount += 4;
                num++;
            }

            //疼痛刻度
            int nOffsetX = 3;
            for (int i = 0; i < 6; i++)
            {
                if (i > 0)
                {
                    nOffsetX = 0;
                }
                graph.DrawString(string.Format(" {0}", 10 - (i * 2)), foreXueYaFont, new SolidBrush(Color.Black), new Point(nLeftSpace - 20 - nOffsetX, (50 + i) * nHeightPerGrid + nTopSpace - 82));
            }

            #endregion

            #region 画垂直线
            for (int i = 0; i <= nHorizonPointCount; i++)   //画垂直线
            {
                int x1 = i * nWidthPerGrid;
                int y1 = 0;
                int x2 = i * nWidthPerGrid;
                int y2 = iHeight;
                x1 += nLeftSpace;
                x2 += nLeftSpace;
                if (i == 0)
                {
                    graph.DrawLine(penThickLine, new Point(1, y1), new Point(1, y2));
                    graph.DrawLine(penThickLine, new Point(49, y1), new Point(49, y2 - nBottomSpace - nBottomXy - nBottomSpo2));
                    graph.DrawLine(penThickLine, new Point(x1, y1), new Point(x2, y2));
                }
                else if (i == nHorizonPointCount)
                {
                    graph.DrawLine(penThickLine, new Point(x1, y1), new Point(x2, y2));
                }
                else
                {
                    if (i % 6 == 0)
                    {
                        graph.DrawLine(penRedLine, new Point(x1, y1), new Point(x2, y2 + 21));
                    }
                    else
                    {
                        if (i % 2 == 1)
                            graph.DrawLine(penSlimLine, new Point(x1, y1), new Point(x2, y2 - nBottomXy - 2 - nBottomSpo2));
                        else
                            graph.DrawLine(penSlimLine, new Point(x1, y1), new Point(x2, y2));
                    }
                }
            }
            #endregion

            //口温用篮（黑）点●表示，腋温用篮叉×表示，肛温用蓝圆内点◎表示，以蓝线相连
            //降温后半（一）小时的体温用红○表示，以红虚线与降温前的体温相连
            //脉搏用红●表示,心率用红圆内点◎表示，以红线相连
            Pen penJwtwDot = new Pen(Color.Red, 2);
            Pen penTiwenDot = new Pen(Color.DarkBlue, 4);
            Pen penTiwenLine = new Pen(Color.DarkBlue, 1);
            Pen penTiwenXLine = new Pen(Color.DarkBlue, 1);
            Pen penMiaoboDot = new Pen(Color.Red, 4);
            Pen penMiaoboLine = new Pen(Color.Red, 1);


            DateTime dtBase = DateTime.Parse(sFirstDate);
            float fMaxTemp = 42.0F;
            float fCheckTemp = 31.0F;
            float fCheckMaibo = 40.0F;

            // 从数据库读取一周的数据，以测量时间排序保存在alTT中
            ArrayList bcData = new ArrayList();
            ArrayList alTT= temperatureChartService.ReadTemperatureData(sFirstDate, BirthRecordId, InpatientId);

            Point StartPoint;
            Point EndPoint;


            int nTempCount = alTT.Count;
            TWPoint[] twPoint = new TWPoint[nTempCount];
            TWPoint[] pointsMiaobo = new TWPoint[nTempCount];

            int nIndex = 0;
            int huxiNum = 0;

            bool XyOneBool = false;
            bool XyTwoBool = false;
            bool XyThreeBool = false;
            int dayWitdh = 0;
            int days = 0;
            int hzsmwzIndex = 0; //记录下上次写文字的坐标，防止重复写文字
            int INDEX = 0;
            string HasT = "no";
            string HasP = "no";
            ArrayList alXQ = new ArrayList();
            int t = 0;
            while (t < 7)
            {
                TwdBCMS bcms = new TwdBCMS();
                alXQ.Add(bcms);
                t++;
            }
            for (int i = 0; i < alTT.Count; i++)
            {
                TimeTwMbHx tw = alTT[i] as TimeTwMbHx;
                TimeSpan ts = tw.dt - dtBase;//时间差

                #region 补充

                TwdBCMS bc = alXQ[ts.Days] as TwdBCMS;
                if (tw.sBC != "")
                {
                    if (tw.dt.Hour >= 0 && tw.dt.Hour < 4)
                    {
                        if (tw.sBC == "入院" || tw.sBC.Substring(0, 2) == "入院")
                        {
                            bc.strBC1[0] = tw.sBC;
                        }
                        else if (tw.sBC == "手术" || tw.sBC.Substring(0, 2) == "手术")
                        {
                            bc.strBC1[1] = tw.sBC;
                        }
                        else if (tw.sBC == "转科" || tw.sBC.Substring(0, 2) == "转科")
                        {
                            bc.strBC1[2] = tw.sBC;
                        }
                        else if (tw.sBC == "分娩" || tw.sBC.Substring(0, 2) == "分娩")
                        {
                            bc.strBC1[3] = tw.sBC;
                        }
                        else if (tw.sBC == "死亡" || tw.sBC.Substring(0, 2) == "死亡")
                        {
                            bc.strBC1[4] = tw.sBC;
                        }
                        else if (tw.sBC == "出院" || tw.sBC.Substring(0, 2) == "出院")
                        {
                            bc.strBC1[5] = tw.sBC;
                        }
                        else if (tw.sBC == "请假" || tw.sBC.Substring(0, 2) == "请假")
                        {
                            bc.strBC1[6] = tw.sBC;
                        }
                        else if (tw.sBC == "外出" || tw.sBC.Substring(0, 2) == "外出")
                        {
                            bc.strBC1[7] = tw.sBC;
                        }
                        else if (tw.sBC == "血透" || tw.sBC.Substring(0, 2) == "血透")
                        {
                            bc.strBC1[8] = tw.sBC;
                        }
                        else if (tw.sBC == "拒测" || tw.sBC.Substring(0, 2) == "拒测")
                        {
                            bc.strBC1[9] = tw.sBC;
                        }
                        else if (tw.sBC == "高压氧" || tw.sBC.Substring(0, 3) == "高压氧")
                        {
                            bc.strBC1[13] = tw.sBC;
                        }
                        else if (tw.sBC == "机械通气" || tw.sBC.Substring(0, 4) == "机械通气")
                        {
                            bc.strBC1[10] = tw.sBC;
                        }
                        else if (tw.sBC == "明日出院" || tw.sBC.Substring(0, 4) == "明日出院")
                        {
                            bc.strBC1[12] = tw.sBC;
                        }
                        else if (tw.sBC == "停机械通气" || tw.sBC.Substring(0, 5) == "停机械通气")
                        {
                            bc.strBC1[11] = tw.sBC;
                        }

                    }
                    else if (tw.dt.Hour >= 4 && tw.dt.Hour < 8)
                    {
                        if (tw.sBC == "入院" || tw.sBC.Substring(0, 2) == "入院")
                        {
                            bc.strBC2[0] = tw.sBC;
                        }
                        else if (tw.sBC == "手术" || tw.sBC.Substring(0, 2) == "手术")
                        {
                            bc.strBC2[1] = tw.sBC;
                        }
                        else if (tw.sBC == "转科" || tw.sBC.Substring(0, 2) == "转科")
                        {
                            bc.strBC2[2] = tw.sBC;
                        }
                        else if (tw.sBC == "分娩" || tw.sBC.Substring(0, 2) == "分娩")
                        {
                            bc.strBC2[3] = tw.sBC;
                        }
                        else if (tw.sBC == "死亡" || tw.sBC.Substring(0, 2) == "死亡")
                        {
                            bc.strBC2[4] = tw.sBC;
                        }
                        else if (tw.sBC == "出院" || tw.sBC.Substring(0, 2) == "出院")
                        {
                            bc.strBC2[5] = tw.sBC;
                        }
                        else if (tw.sBC == "请假" || tw.sBC.Substring(0, 2) == "请假")
                        {
                            bc.strBC2[6] = tw.sBC;
                        }
                        else if (tw.sBC == "外出" || tw.sBC.Substring(0, 2) == "外出")
                        {
                            bc.strBC2[7] = tw.sBC;
                        }
                        else if (tw.sBC == "血透" || tw.sBC.Substring(0, 2) == "血透")
                        {
                            bc.strBC2[8] = tw.sBC;
                        }
                        else if (tw.sBC == "拒测" || tw.sBC.Substring(0, 2) == "拒测")
                        {
                            bc.strBC2[9] = tw.sBC;
                        }
                        else if (tw.sBC == "高压氧" || tw.sBC.Substring(0, 3) == "高压氧")
                        {
                            bc.strBC2[13] = tw.sBC;
                        }
                        else if (tw.sBC == "机械通气" || tw.sBC.Substring(0, 4) == "机械通气")
                        {
                            bc.strBC2[10] = tw.sBC;
                        }
                        else if (tw.sBC == "明日出院" || tw.sBC.Substring(0, 4) == "明日出院")
                        {
                            bc.strBC2[12] = tw.sBC;
                        }
                        else if (tw.sBC == "停机械通气" || tw.sBC.Substring(0, 5) == "停机械通气")
                        {
                            bc.strBC2[11] = tw.sBC;
                        }
                    }
                    else if (tw.dt.Hour >= 8 && tw.dt.Hour < 12)
                    {
                        if (tw.sBC == "入院" || tw.sBC.Substring(0, 2) == "入院")
                        {
                            bc.strBC3[0] = tw.sBC;
                        }
                        else if (tw.sBC == "手术" || tw.sBC.Substring(0, 2) == "手术")
                        {
                            bc.strBC3[1] = tw.sBC;
                        }
                        else if (tw.sBC == "转科" || tw.sBC.Substring(0, 2) == "转科")
                        {
                            bc.strBC3[2] = tw.sBC;
                        }
                        else if (tw.sBC == "分娩" || tw.sBC.Substring(0, 2) == "分娩")
                        {
                            bc.strBC3[3] = tw.sBC;
                        }
                        else if (tw.sBC == "死亡" || tw.sBC.Substring(0, 2) == "死亡")
                        {
                            bc.strBC3[4] = tw.sBC;
                        }
                        else if (tw.sBC == "出院" || tw.sBC.Substring(0, 2) == "出院")
                        {
                            bc.strBC3[5] = tw.sBC;
                        }
                        else if (tw.sBC == "请假" || tw.sBC.Substring(0, 2) == "请假")
                        {
                            bc.strBC3[6] = tw.sBC;
                        }
                        else if (tw.sBC == "外出" || tw.sBC.Substring(0, 2) == "外出")
                        {
                            bc.strBC3[7] = tw.sBC;
                        }
                        else if (tw.sBC == "血透" || tw.sBC.Substring(0, 2) == "血透")
                        {
                            bc.strBC3[8] = tw.sBC;
                        }
                        else if (tw.sBC == "拒测" || tw.sBC.Substring(0, 2) == "拒测")
                        {
                            bc.strBC3[9] = tw.sBC;
                        }
                        else if (tw.sBC == "高压氧" || tw.sBC.Substring(0, 3) == "高压氧")
                        {
                            bc.strBC3[13] = tw.sBC;
                        }
                        else if (tw.sBC == "机械通气" || tw.sBC.Substring(0, 4) == "机械通气")
                        {
                            bc.strBC3[10] = tw.sBC;
                        }
                        else if (tw.sBC == "明日出院" || tw.sBC.Substring(0, 4) == "明日出院")
                        {
                            bc.strBC3[12] = tw.sBC;
                        }
                        else if (tw.sBC == "停机械通气" || tw.sBC.Substring(0, 5) == "停机械通气")
                        {
                            bc.strBC3[11] = tw.sBC;
                        }

                    }
                    else if (tw.dt.Hour >= 12 && tw.dt.Hour < 16)
                    {
                        if (tw.sBC == "入院" || tw.sBC.Substring(0, 2) == "入院")
                        {
                            bc.strBC4[0] = tw.sBC;
                        }
                        else if (tw.sBC == "手术" || tw.sBC.Substring(0, 2) == "手术")
                        {
                            bc.strBC4[1] = tw.sBC;
                        }
                        else if (tw.sBC == "转科" || tw.sBC.Substring(0, 2) == "转科")
                        {
                            bc.strBC4[2] = tw.sBC;
                        }
                        else if (tw.sBC == "分娩" || tw.sBC.Substring(0, 2) == "分娩")
                        {
                            bc.strBC4[3] = tw.sBC;
                        }
                        else if (tw.sBC == "死亡" || tw.sBC.Substring(0, 2) == "死亡")
                        {
                            bc.strBC4[4] = tw.sBC;
                        }
                        else if (tw.sBC == "出院" || tw.sBC.Substring(0, 2) == "出院")
                        {
                            bc.strBC4[5] = tw.sBC;
                        }
                        else if (tw.sBC == "请假" || tw.sBC.Substring(0, 2) == "请假")
                        {
                            bc.strBC4[6] = tw.sBC;
                        }
                        else if (tw.sBC == "外出" || tw.sBC.Substring(0, 2) == "外出")
                        {
                            bc.strBC4[7] = tw.sBC;
                        }
                        else if (tw.sBC == "血透" || tw.sBC.Substring(0, 2) == "血透")
                        {
                            bc.strBC4[8] = tw.sBC;
                        }
                        else if (tw.sBC == "拒测" || tw.sBC.Substring(0, 2) == "拒测")
                        {
                            bc.strBC4[9] = tw.sBC;
                        }
                        else if (tw.sBC == "高压氧" || tw.sBC.Substring(0, 3) == "高压氧")
                        {
                            bc.strBC4[13] = tw.sBC;
                        }
                        else if (tw.sBC == "机械通气" || tw.sBC.Substring(0, 4) == "机械通气")
                        {
                            bc.strBC4[10] = tw.sBC;
                        }
                        else if (tw.sBC == "明日出院" || tw.sBC.Substring(0, 4) == "明日出院")
                        {
                            bc.strBC4[12] = tw.sBC;
                        }
                        else if (tw.sBC == "停机械通气" || tw.sBC.Substring(0, 5) == "停机械通气")
                        {
                            bc.strBC4[11] = tw.sBC;
                        }
                    }
                    else if (tw.dt.Hour >= 16 && tw.dt.Hour < 20)
                    {
                        if (tw.sBC == "入院" || tw.sBC.Substring(0, 2) == "入院")
                        {
                            bc.strBC5[0] = tw.sBC;
                        }
                        else if (tw.sBC == "手术" || tw.sBC.Substring(0, 2) == "手术")
                        {
                            bc.strBC5[1] = tw.sBC;
                        }
                        else if (tw.sBC == "转科" || tw.sBC.Substring(0, 2) == "转科"
                                || tw.sBC == "转入" || tw.sBC.Substring(0, 2) == "转入")
                        {
                            bc.strBC5[2] = tw.sBC;
                        }
                        else if (tw.sBC == "分娩" || tw.sBC.Substring(0, 2) == "分娩")
                        {
                            bc.strBC5[3] = tw.sBC;
                        }
                        else if (tw.sBC == "死亡" || tw.sBC.Substring(0, 2) == "死亡")
                        {
                            bc.strBC5[4] = tw.sBC;
                        }
                        else if (tw.sBC == "出院" || tw.sBC.Substring(0, 2) == "出院")
                        {
                            bc.strBC5[5] = tw.sBC;
                        }
                        else if (tw.sBC == "请假" || tw.sBC.Substring(0, 2) == "请假")
                        {
                            bc.strBC5[6] = tw.sBC;
                        }
                        else if (tw.sBC == "外出" || tw.sBC.Substring(0, 2) == "外出")
                        {
                            bc.strBC5[7] = tw.sBC;
                        }
                        else if (tw.sBC == "血透" || tw.sBC.Substring(0, 2) == "血透")
                        {
                            bc.strBC5[8] = tw.sBC;
                        }
                        else if (tw.sBC == "拒测" || tw.sBC.Substring(0, 2) == "拒测")
                        {
                            bc.strBC5[9] = tw.sBC;
                        }
                        else if (tw.sBC == "高压氧" || tw.sBC.Substring(0, 3) == "高压氧")
                        {
                            bc.strBC5[13] = tw.sBC;
                        }
                        else if (tw.sBC == "机械通气" || tw.sBC.Substring(0, 4) == "机械通气")
                        {
                            bc.strBC5[10] = tw.sBC;
                        }
                        else if (tw.sBC == "明日出院" || tw.sBC.Substring(0, 4) == "明日出院")
                        {
                            bc.strBC5[12] = tw.sBC;
                        }
                        else if (tw.sBC == "停机械通气" || tw.sBC.Substring(0, 5) == "停机械通气")
                        {
                            bc.strBC5[11] = tw.sBC;
                        }
                    }
                    else if (tw.dt.Hour >= 20 && tw.dt.Hour <= 23)
                    {
                        if (tw.sBC == "入院" || tw.sBC.Substring(0, 2) == "入院")
                        {
                            bc.strBC6[0] = tw.sBC;
                        }
                        else if (tw.sBC == "手术" || tw.sBC.Substring(0, 2) == "手术")
                        {
                            bc.strBC6[1] = tw.sBC;
                        }
                        else if (tw.sBC == "转科" || tw.sBC.Substring(0, 2) == "转科"
                                || tw.sBC == "转入" || tw.sBC.Substring(0, 2) == "转入")
                        {
                            bc.strBC6[2] = tw.sBC;
                        }
                        else if (tw.sBC == "分娩" || tw.sBC.Substring(0, 2) == "分娩")
                        {
                            bc.strBC6[3] = tw.sBC;
                        }
                        else if (tw.sBC == "死亡" || tw.sBC.Substring(0, 2) == "死亡")
                        {
                            bc.strBC6[4] = tw.sBC;
                        }
                        else if (tw.sBC == "出院" || tw.sBC.Substring(0, 2) == "出院")
                        {
                            bc.strBC6[5] = tw.sBC;
                        }
                        else if (tw.sBC == "请假" || tw.sBC.Substring(0, 2) == "请假")
                        {
                            bc.strBC6[6] = tw.sBC;
                        }
                        else if (tw.sBC == "外出" || tw.sBC.Substring(0, 2) == "外出")
                        {
                            bc.strBC6[7] = tw.sBC;
                        }
                        else if (tw.sBC == "血透" || tw.sBC.Substring(0, 2) == "血透")
                        {
                            bc.strBC6[8] = tw.sBC;
                        }
                        else if (tw.sBC == "拒测" || tw.sBC.Substring(0, 2) == "拒测")
                        {
                            bc.strBC6[9] = tw.sBC;
                        }
                        else if (tw.sBC == "高压氧" || tw.sBC.Substring(0, 3) == "高压氧")
                        {
                            bc.strBC6[13] = tw.sBC;
                        }
                        else if (tw.sBC == "机械通气" || tw.sBC.Substring(0, 4) == "机械通气")
                        {
                            bc.strBC6[10] = tw.sBC;
                        }
                        else if (tw.sBC == "明日出院" || tw.sBC.Substring(0, 4) == "明日出院")
                        {
                            bc.strBC6[12] = tw.sBC;
                        }
                        else if (tw.sBC == "停机械通气" || tw.sBC.Substring(0, 5) == "停机械通气")
                        {
                            bc.strBC6[11] = tw.sBC;
                        }
                    }
                }
                #endregion
            }

            //同一天内只取前三次血压记录,后面忽略
            int threeInOneDay = 0;
            string OneDay = "";
            for (int z = 0; z < alTT.Count; z++)
            {
                string strBC = "";
                TimeTwMbHx tt = alTT[z] as TimeTwMbHx;
                TimeSpan ts = tt.dt - dtBase;//时间差
                float fTemp = tt.fTemp;//体温值
                int nMiaobo = tt.nMiaobo;//脉搏值
                float fMaiBo = (float)(nMaxMaibo - nMiaobo);//计算脉搏值与最高值差值，用于计算y坐标

                float fx = (float)(nWidthPerGrid * (float)ts.TotalMinutes / (4 * 60) + (float)nLeftSpace);
                int x = (int)fx;
                //计算体温值y坐标
                int yTemp = (int)((fMaxTemp - fTemp) / 0.2 * nHeightPerGrid) + nTopSpace;
                //计算脉搏值y坐标
                int yMiaobo = (int)((fMaiBo / 4) * nHeightPerGrid) + nTopSpace;
                int cllx = int.Parse(tt.CeliangLeixing);

                Pen penForTiwen;

                #region 绘制说明文字
                //绘制说明文字   文字说明显示只限于偶数小时数。(ts.Hours == 0 || ts.Hours == 2 || ts.Hours == 4 || ts.Hours == 6 || ts.Hours == 8 || ts.Hours == 10 || ts.Hours == 12 ||
                // ts.Hours == 14 || ts.Hours == 16 ||
                // ts.Hours == 18 || ts.Hours == 20 ||
                //  ts.Hours == 22)
                if (tt.sBC != "")
                {
                    string sBC = tt.sBC + tt.dt.ToString("yyyy-MM-dd HH:mm");
                    int xx = 0;
                    int sd = ts.Days;
                    TwdBCMS bc = alXQ[sd] as TwdBCMS;
                    xx = sd * 6 * 12 + nLeftSpace;
                    if (tt.dt.Hour >= 0 && tt.dt.Hour < 4)
                    {
                        xx += 0 * nWidthPerGrid;
                        strBC = bc.strBC1[0] + "   " + bc.strBC1[1] + "   " + bc.strBC1[2] + "   " + bc.strBC1[3] + "   " + bc.strBC1[4] + "   " + bc.strBC1[5] + "   " + bc.strBC1[6] + "   " + bc.strBC1[7] + "   " + bc.strBC1[8] + "   " + bc.strBC1[9] + "   " + bc.strBC1[10] + "   " + bc.strBC1[11] + "   " + bc.strBC1[12] + "   " + bc.strBC1[13];
                    }
                    else if (tt.dt.Hour >= 4 && tt.dt.Hour < 8)
                    {
                        xx += 1 * nWidthPerGrid;
                        strBC = bc.strBC2[0] + "   " + bc.strBC2[1] + "   " + bc.strBC2[2] + "   " + bc.strBC2[3] + "   " + bc.strBC2[4] + "   " + bc.strBC2[5] + "   " + bc.strBC2[6] + "   " + bc.strBC2[7] + "   " + bc.strBC2[8] + "   " + bc.strBC2[9] + "   " + bc.strBC2[10] + "   " + bc.strBC2[11] + "   " + bc.strBC2[12] + "   " + bc.strBC2[13];
                    }
                    else if (tt.dt.Hour >= 8 && tt.dt.Hour < 12)
                    {
                        xx += 2 * nWidthPerGrid;
                        strBC = bc.strBC3[0] + "   " + bc.strBC3[1] + "   " + bc.strBC3[2] + "   " + bc.strBC3[3] + "   " + bc.strBC3[4] + "   " + bc.strBC3[5] + "   " + bc.strBC3[6] + "   " + bc.strBC3[7] + "   " + bc.strBC3[8] + "   " + bc.strBC3[9] + "   " + bc.strBC3[10] + "   " + bc.strBC3[11] + "   " + bc.strBC3[12] + "   " + bc.strBC3[13];
                    }
                    else if (tt.dt.Hour >= 12 && tt.dt.Hour < 16)
                    {
                        xx += 3 * nWidthPerGrid;
                        strBC = bc.strBC4[0] + "   " + bc.strBC4[1] + "   " + bc.strBC4[2] + "   " + bc.strBC4[3] + "   " + bc.strBC4[4] + "   " + bc.strBC4[5] + "   " + bc.strBC4[6] + "   " + bc.strBC4[7] + "   " + bc.strBC4[8] + "   " + bc.strBC4[9] + "   " + bc.strBC4[10] + "   " + bc.strBC4[11] + "   " + bc.strBC4[12] + "   " + bc.strBC4[13];
                    }
                    else if (tt.dt.Hour >= 16 && tt.dt.Hour < 20)
                    {
                        xx += 4 * nWidthPerGrid;
                        strBC = bc.strBC5[0] + "   " + bc.strBC5[1] + "   " + bc.strBC5[2] + "   " + bc.strBC5[3] + "   " + bc.strBC5[4] + "   " + bc.strBC5[5] + "   " + bc.strBC5[6] + "   " + bc.strBC5[7] + "   " + bc.strBC5[8] + "   " + bc.strBC5[9] + "   " + bc.strBC5[10] + "   " + bc.strBC5[11] + "   " + bc.strBC5[12] + "   " + bc.strBC5[13];
                    }
                    else if (tt.dt.Hour >= 20 && tt.dt.Hour <= 23)
                    {
                        xx += 5 * nWidthPerGrid;
                        strBC = bc.strBC6[0] + "   " + bc.strBC6[1] + "   " + bc.strBC6[2] + "   " + bc.strBC6[3] + "   " + bc.strBC6[4] + "   " + bc.strBC6[5] + "   " + bc.strBC6[6] + "   " + bc.strBC6[7] + "   " + bc.strBC6[8] + "   " + bc.strBC6[9] + "   " + bc.strBC6[10] + "   " + bc.strBC6[11] + "   " + bc.strBC6[12] + "   " + bc.strBC6[13];
                    }


                    int yy = nTopSpace;

                    Font font = new Font(
                    strFontName,
                       7,
                       FontStyle.Regular,
                       GraphicsUnit.Point);
                    Point point1 = new Point(xx, yy);
                    StringFormat stringFormat = new StringFormat();
                    SolidBrush solidBrush = new SolidBrush(Color.Red);

                    stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

                    //if (hzsmwzIndex != xx && cllx != -2)//hzsmwzIndex保存了上次文字说明的文字，如果位置相同，则不再写，避免重叠
                    //{
                    graph.DrawString(strBC.Trim(), font, solidBrush, point1, stringFormat);
                    hzsmwzIndex = xx;
                    //}
                }
                #endregion

                #region   // 绘制体温和脉搏点

                #region 超常脉搏点
                int cMiaobo = (int)(((float)(nMaxMaibo - fCheckMaibo) / 4) * nHeightPerGrid) + nTopSpace;
                if (yMiaobo > cMiaobo)//40次以下画向下的箭头
                {
                    yMiaobo = cMiaobo;
                    Font font = new Font(strFontName, 8);
                    graph.DrawString("↓", font, new SolidBrush(Color.Red), new Point(x - 7, yMiaobo));
                }
                if (nMiaobo > 200)//200次以上
                {
                    Font font = new Font(strFontName, 8);
                    graph.DrawString("↑", font, new SolidBrush(Color.Red), new Point(x - 7, nTopSpace - 11));
                }
                #endregion

                #region 超常体温点fCheckTemp
                int cTemp = (int)((fMaxTemp - 35) / 0.2 * nHeightPerGrid) + nTopSpace + 40;
                if (yTemp > cTemp && cllx != -2)//35度以下画向下的箭头
                {
                    yTemp = cTemp;
                    Font font = new Font(strFontName, 8);
                    graph.DrawString("↓", font, new SolidBrush(Color.DarkBlue), new Point(x - 7, yTemp));
                }
                if (fTemp > 42 && cllx != -2)//44度以上
                {
                    Font font = new Font(strFontName, 8);
                    graph.DrawString("↑", font, new SolidBrush(Color.DarkBlue), new Point(x - 7, nTopSpace - 11));
                }
                #endregion

                pointsMiaobo[nIndex] = new TWPoint(x, yMiaobo, cllx);

                twPoint[nIndex] = new TWPoint(x, yTemp, cllx);
                #region //画脉搏体温点
                switch (tt.CeliangLeixing)
                {
                    case "0":
                        //case "2":
                        //正常体温记录
                        penForTiwen = penTiwenDot;
                        //脉搏|| nMiaobo > 200
                        if (yMiaobo > nTopSpace)
                        {
                            if (tt.MiaoboLeixing == "0")        //脉搏
                            {
                                if (yMiaobo == yTemp)
                                {
                                    graph.FillEllipse(Brushes.DarkBlue, x - 4, yMiaobo - 4, 8, 8);
                                    graph.DrawEllipse(penMiaoboLine, x - 6, yMiaobo - 6, 12, 12);
                                }
                                else
                                {
                                    graph.FillEllipse(Brushes.Red, x - 3, yMiaobo - 3, 7, 7);
                                }
                            }
                            else if (tt.MiaoboLeixing == "1")       //心率
                            {
                                if (yMiaobo == yTemp)
                                {
                                    graph.FillEllipse(Brushes.DarkBlue, x - 4, yMiaobo - 4, 8, 8);
                                    graph.DrawEllipse(penMiaoboLine, x - 4, yMiaobo - 4, 8, 8);
                                    graph.DrawEllipse(penMiaoboLine, x - 6, yMiaobo - 6, 12, 12);
                                }
                                else
                                {
                                    graph.FillEllipse(Brushes.Red, x - 4, yMiaobo - 4, 6, 6);
                                    graph.DrawEllipse(penMiaoboLine, x - 6, yMiaobo - 6, 10, 10);
                                }
                            }
                            if (HasP == "no")
                            {
                                Font font = new Font(strFontName, 8);
                                graph.DrawString("P", font, new SolidBrush(Color.Red), new Point(x - 3, yMiaobo + 5));
                                HasP = "yes";
                            }
                        }

                        //体温 
                        if (tt.CeliangLeixing == "2")//如果是2表示为降温1小时体温，那么该点的位置稍微向右偏差2像素
                        {
                            x = x + 2;
                        }
                        if (yTemp > nTopSpace)
                        {
                            if (tt.TiwenLeixing == "0")//一般体温
                            {
                                graph.FillEllipse(Brushes.DarkBlue, x - 3, yTemp - 3, 7, 7);

                            }
                            else if (tt.TiwenLeixing == "1")//液温
                            {
                                penForTiwen = new Pen(Color.DarkBlue, 2);
                                graph.DrawLine(penForTiwen, x - 3, yTemp - 3, x + 3, yTemp + 3);
                                graph.DrawLine(penForTiwen, x - 3, yTemp + 3, x + 3, yTemp - 3);
                            }
                            else if (tt.TiwenLeixing == "2")//肛温
                            {
                                penForTiwen = new Pen(Color.DarkBlue, 1);
                                graph.DrawEllipse(penForTiwen, x - 5, yTemp - 5, 8, 8);
                                graph.FillEllipse(Brushes.DarkBlue, x - 3, yTemp - 3, 4, 4);
                            }
                            else if (tt.TiwenLeixing == "3")//耳温
                            {
                                graph.FillEllipse(Brushes.DarkBlue, x - 3, yTemp - 3, 7, 7);
                            }
                            if (HasT == "no")
                            {
                                Font font = new Font(strFontName, 8);
                                graph.DrawString("T", font, new SolidBrush(Color.DarkBlue), new Point(x - 3, yTemp + 5));
                                HasT = "yes";
                            }

                        }

                        break;
                    case "1"://降温半小时体温
                        penForTiwen = penJwtwDot;
                        graph.DrawEllipse(penForTiwen, x - 4, yTemp - 4, 8, 8);
                        break;
                    case "2":
                        penForTiwen = penJwtwDot;
                        graph.DrawEllipse(penForTiwen, x - 4, yTemp - 4, 8, 8);
                        break;
                    default:
                        break;
                }
                #endregion

                nIndex++;

                #region //绘制呼吸次数
                //if (ts.Hours % 2 == 0)
                //{
                //    if (ts.Hours % 4 == 0)
                //        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(x - nWidthPerGrid / 2, yHuxicishu + 2));
                //    else
                //    {
                //        int tem = (ts.Days * 24 + ts.Hours + 2) / 4;
                //        if (tem % 2 == 0)
                //            graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(x - nWidthPerGrid / 2 - 2, yHuxicishu + 12));
                //        else
                //            graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(x - nWidthPerGrid / 2 - 2, yHuxicishu - 8));

                //    }
                //}
                int fy_hx = 0;
                if (huxiNum % 2 == 0)
                {
                    fy_hx = yHuxicishu + 12;
                }
                else
                {
                    fy_hx = yHuxicishu - 4;
                }
                int s = ts.Days;
                int fx_hx = s * 6 * 12 + nLeftSpace - 3;
                if (z < alTT.Count - 1)//非最后一个呼吸
                {
                    TimeTwMbHx tt1 = alTT[z + 1] as TimeTwMbHx;
                    if (tt.dt.Date == tt1.dt.Date && tt.dt.Hour >= 0 && tt.dt.Hour < 4 && tt1.dt.Hour >= 0 && tt1.dt.Hour < 4 && (tt1.CeliangLeixing != "1" && tt1.CeliangLeixing != "2") && tt1.nHuxi != "")
                    { }
                    else if (tt.dt.Date == tt1.dt.Date && tt.dt.Hour >= 4 && tt.dt.Hour < 8 && tt1.dt.Hour >= 4 && tt1.dt.Hour < 8 && (tt1.CeliangLeixing != "1" && tt1.CeliangLeixing != "2") && tt1.nHuxi != "")
                    { }
                    else if (tt.dt.Date == tt1.dt.Date && tt.dt.Hour >= 8 && tt.dt.Hour < 12 && tt1.dt.Hour >= 8 && tt1.dt.Hour < 12 && (tt1.CeliangLeixing != "1" && tt1.CeliangLeixing != "2") && tt1.nHuxi != "")
                    { }
                    else if (tt.dt.Date == tt1.dt.Date && tt.dt.Hour >= 12 && tt.dt.Hour < 16 && tt1.dt.Hour >= 12 && tt1.dt.Hour < 16 && (tt1.CeliangLeixing != "1" && tt1.CeliangLeixing != "2") && tt1.nHuxi != "")
                    { }
                    else if (tt.dt.Date == tt1.dt.Date && tt.dt.Hour >= 16 && tt.dt.Hour < 20 && tt1.dt.Hour >= 16 && tt1.dt.Hour < 20 && (tt1.CeliangLeixing != "1" && tt1.CeliangLeixing != "2") && tt1.nHuxi != "")
                    { }
                    else if (tt.dt.Date == tt1.dt.Date && tt.dt.Hour >= 20 && tt.dt.Hour <= 23 && tt1.dt.Hour >= 20 && tt1.dt.Hour <= 23 && (tt1.CeliangLeixing != "1" && tt1.CeliangLeixing != "2") && tt1.nHuxi != "")
                    { }
                    else
                    {
                        if (tt.nHuxi != "")
                        {
                            int m = 0;
                            if (tt.dt.Hour >= 0 && tt.dt.Hour < 4) m = 0;
                            if (tt.dt.Hour >= 4 && tt.dt.Hour < 8) m = 1;
                            if (tt.dt.Hour >= 8 && tt.dt.Hour < 12) m = 2;
                            if (tt.dt.Hour >= 12 && tt.dt.Hour < 16) m = 3;
                            if (tt.dt.Hour >= 16 && tt.dt.Hour < 20) m = 4;
                            if (tt.dt.Hour >= 20 && tt.dt.Hour <= 23) m = 5;
                            fx_hx += m * nWidthPerGrid;
                            graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                        }
                    }
                }
                if (z == alTT.Count - 1)//最后一个呼吸
                {
                    if (tt.dt.Hour >= 0 && tt.dt.Hour < 4 && tt.nHuxi != "")
                    {
                        fx_hx += 0 * nWidthPerGrid;
                        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                    }
                    else if (tt.dt.Hour >= 4 && tt.dt.Hour < 8 && tt.nHuxi != "")
                    {
                        fx_hx += 1 * nWidthPerGrid;
                        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                    }
                    else if (tt.dt.Hour >= 8 && tt.dt.Hour < 12 && tt.nHuxi != "")
                    {
                        fx_hx += 2 * nWidthPerGrid;
                        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                    }
                    else if (tt.dt.Hour >= 12 && tt.dt.Hour < 16 && tt.nHuxi != "")
                    {
                        fx_hx += 3 * nWidthPerGrid;
                        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                    }
                    else if (tt.dt.Hour >= 16 && tt.dt.Hour < 20 && tt.nHuxi != "")
                    {
                        fx_hx += 4 * nWidthPerGrid;
                        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                    }
                    else if (tt.dt.Hour >= 20 && tt.dt.Hour <= 23 && tt.nHuxi != "")
                    {
                        fx_hx += 5 * nWidthPerGrid;
                        graph.DrawString(tt.nHuxi, foreSmallFont, new SolidBrush(Color.Red), new Point(fx_hx, fy_hx)); huxiNum++;
                    }

                }
                #endregion

                #region  //绘制血压
                int XueYa1X = 0;
                int XueYa2X = 0;
                int XueYa3X = 0;
                if (ts.Days != days)
                {
                    XyOneBool = false;
                    XyTwoBool = false;
                    XyTwoBool = false;
                    days = ts.Days;
                }

                dayWitdh = (int)(((float)ts.Days * 24 + 2) / 4 * (float)nWidthPerGrid + (float)nLeftSpace - (float)nWidthPerGrid / 2);

                if (tt.sXy1 != "")
                {
                    ////判断当前点的区间
                    //string timerang = TimeRange(tt);

                    //bool isDraw = true;
                    //int m = z + 1;
                    //for (; m < alTT.Count; m++)//判断后面的点是否有存在同天同区间有血压值的点，有则不画。无则画
                    //{

                    //    TimeTwMbHx tt_m = alTT[m] as TimeTwMbHx;//下个点
                    //    if (tt_m.dt.Date == tt.dt.Date && timerang == TimeRange(tt_m) && tt_m.sXy1 != "" && tt_m.sXy2 != "")//存在，则本点不画
                    //    {
                    //        isDraw = false;
                    //        break;
                    //    }
                    TimeTwMbHx tt_z = alTT[z] as TimeTwMbHx;
                    if (tt_z.dt.Date.ToString() == OneDay)
                    {
                        threeInOneDay++;
                    }
                    else
                    {
                        OneDay = tt_z.dt.Date.ToString();
                        threeInOneDay = 1;
                    }
                    #region 计算血压坐标
                    if (z != alTT.Count - 1)
                    {
                        if (threeInOneDay == 1)
                        {
                            if (tt.sXy1.Length > 2)
                                XueYa1X = dayWitdh + 12 - nWidthPerGrid / 2;
                            else
                                XueYa1X = dayWitdh + 15 - nWidthPerGrid / 2;
                            if (tt.sXy2.Length > 2)
                                XueYa2X = dayWitdh + 25 - nWidthPerGrid / 2;
                            else
                                XueYa2X = dayWitdh + 27 - nWidthPerGrid / 2;
                            XueYa3X = dayWitdh + 17 - nWidthPerGrid / 2;
                            XyOneBool = true;
                        }
                        else if (threeInOneDay == 2)
                        {
                            if (tt.sXy1.Length > 2)
                                XueYa1X = dayWitdh + 36 - nWidthPerGrid / 2;
                            else
                                XueYa1X = dayWitdh + 39 - nWidthPerGrid / 2;
                            if (tt.sXy2.Length > 2)
                                XueYa2X = dayWitdh + 49 - nWidthPerGrid / 2;
                            else
                                XueYa2X = dayWitdh + 51 - nWidthPerGrid / 2;
                            XueYa3X = dayWitdh + 41 - nWidthPerGrid / 2;
                            XyTwoBool = true;
                        }
                        else if (threeInOneDay == 3)
                        {
                            if (tt.sXy1.Length > 2)
                                XueYa1X = dayWitdh + 61 - nWidthPerGrid / 2;
                            else
                                XueYa1X = dayWitdh + 64 - nWidthPerGrid / 2;
                            if (tt.sXy2.Length > 2)
                                XueYa2X = dayWitdh + 75 - nWidthPerGrid / 2;//87
                            else
                                XueYa2X = dayWitdh + 74 - nWidthPerGrid / 2;//88
                            XueYa3X = dayWitdh + 65 - nWidthPerGrid / 2;//76
                            XyThreeBool = true;
                        }
                    }
                    else//最后一个血压
                    {
                        if (threeInOneDay == 1)
                        {
                            if (tt.sXy1.Length > 2)
                                XueYa1X = dayWitdh + 12 - nWidthPerGrid / 2;
                            else
                                XueYa1X = dayWitdh + 15 - nWidthPerGrid / 2;
                            if (tt.sXy2.Length > 2)
                                XueYa2X = dayWitdh + 24 - nWidthPerGrid / 2;
                            else
                                XueYa2X = dayWitdh + 26 - nWidthPerGrid / 2;
                            XueYa3X = dayWitdh + 16 - nWidthPerGrid / 2;
                            XyOneBool = true;
                        }
                        else if (threeInOneDay == 2)
                        {
                            if (tt.sXy1.Length > 2)
                                XueYa1X = dayWitdh + 36 - nWidthPerGrid / 2;
                            else
                                XueYa1X = dayWitdh + 39 - nWidthPerGrid / 2;
                            if (tt.sXy2.Length > 2)
                                XueYa2X = dayWitdh + 49 - nWidthPerGrid / 2;
                            else
                                XueYa2X = dayWitdh + 51 - nWidthPerGrid / 2;
                            XueYa3X = dayWitdh + 41 - nWidthPerGrid / 2;
                            XyTwoBool = true;
                        }
                        else if (threeInOneDay == 3)
                        {
                            if (tt.sXy1.Length > 2)
                                XueYa1X = dayWitdh + 61 - nWidthPerGrid / 2;
                            else
                                XueYa1X = dayWitdh + 64 - nWidthPerGrid / 2;
                            if (tt.sXy2.Length > 2)
                                XueYa2X = dayWitdh + 72 - nWidthPerGrid / 2;
                            else
                                XueYa2X = dayWitdh + 74 - nWidthPerGrid / 2;//74
                            XueYa3X = dayWitdh + 66 - nWidthPerGrid / 2;//66
                            XyThreeBool = true;
                        }

                    }
                    #endregion

                    if (threeInOneDay <= 3 && XueYa1X != 0 && XueYa2X != 0 && XueYa3X != 0)
                    {
                        graph.DrawString(tt.sXy1, foreXueYaFont, new SolidBrush(Color.Black), new Point(XueYa1X - 8, yXueYa + 0));
                        graph.DrawString("／", foreMaxFont, new SolidBrush(Color.Black), new Point(XueYa3X - 8, yXueYa + 2));
                        graph.DrawString(tt.sXy2, foreXueYaFont, new SolidBrush(Color.Black), new Point(XueYa2X - 8, yXueYa + 11));
                    }
                    INDEX++;
                }

                #endregion

                //绘制Spo2
                #region Spo2
                int XSpo2 = 0;
                if (tt.sSpo2 != "")
                {
                    if (ts.Hours >= 0 && ts.Hours <= 6)
                    {
                        XSpo2 = ts.Days * (6 * nWidthPerGrid) + nLeftSpace;
                    }
                    else if (ts.Hours > 6 && ts.Hours < 18)
                    {
                        XSpo2 = ts.Days * (6 * nWidthPerGrid) + (2 * nWidthPerGrid) + nLeftSpace;
                    }
                    else if (ts.Hours >= 18)
                    {
                        XSpo2 = ts.Days * (6 * nWidthPerGrid) + (4 * nWidthPerGrid) + nLeftSpace;
                    }
                    graph.DrawString(tt.sSpo2, foreXueYaFont, new SolidBrush(Color.Black), new Point(XSpo2 + 5, ySpo2 + 0));
                }
                #endregion
                #endregion
            }



            #region 绘制体温和脉搏连线
            //pointsMiaobo[index].z=twPoint[index].z=celiangLeiXing:正常0；不画-2（请假等）；半小时1；一小时2
            //TiwenLeixing:口温0；液温1；肛温2
            //MiaoboLeixing:脉搏0；心率1

            #region 画脉搏连线
            for (int i = 0; i < nTempCount - 1;)
            {
                int index = i;
                if (pointsMiaobo[index].z != -2)
                {
                    StartPoint = new Point(pointsMiaobo[index].x, pointsMiaobo[index].y);
                    index = temperatureChartService.GetAvaPoint(index + 1, pointsMiaobo);
                    if (index == -1)//下个点不画，再遍历下个点i++
                    { i++; continue; }
                    i = index;
                    EndPoint = new Point(pointsMiaobo[index].x, pointsMiaobo[index].y);

                    if ((twPoint[index].z != -1) && (twPoint[index].z != -2) && ((StartPoint.X != EndPoint.X) && (StartPoint.Y > nTopSpace) && (EndPoint.Y > nTopSpace)))
                    {
                        graph.DrawLine(penMiaoboLine, StartPoint, EndPoint);   //脉搏相连线   
                    }
                }
                else
                {
                    i = index + 1;
                }

            }
            #endregion

            #region //画除了非降温体温连线
            for (int i = 0; i < nTempCount - 1;)
            {
                int index = i;
                if (twPoint[index].z != -2)//-2代表不需要画（请假外出检查）
                {
                    StartPoint = new Point(twPoint[index].x, twPoint[index].y);//依次检索体温点， 开始体温点
                    if (i > 0 && twPoint[i].z == 2)//如果为一小时降温，则X稍微偏右2像素
                    {
                        StartPoint.X += 2;
                    }
                    index = temperatureChartService.GetAvaPoint(index + 1, twPoint);//判断下一个体温是否为该画体温点，不该画返回-1，否则返回点的索引
                    if (index == -1)//下个点不画，再遍历下个点i++
                    { i++; continue; }
                    i = index;
                    EndPoint = new Point(twPoint[index].x, twPoint[index].y);//结束体温点
                                                                             //if (twPoint[i].z == 2)//如果结束体温点是一小时降温体温，则降温体温往右2像素
                                                                             //{
                                                                             //    EndPoint = new Point(twPoint[index].x + 2, twPoint[index].y);
                                                                             //}
                    if ((twPoint[index].z != -1) && (twPoint[index].z != -2) && ((StartPoint.X != EndPoint.X) && (StartPoint.Y > nTopSpace) && (EndPoint.Y > nTopSpace)))
                    {
                        graph.DrawLine(penTiwenXLine, StartPoint, EndPoint);   //体温相连线 
                    }
                }
                else
                {
                    i = index + 1;
                }
            }

            #endregion

            #region //画降温半小时体温和降温1小时体温
            Pen penXuXian = new Pen(Color.Red, 2);
            penXuXian.DashStyle = DashStyle.Dash;
            for (int i = 0; i < nTempCount - 1; i++)
            {
                int x1 = twPoint[i].x;
                int y1 = twPoint[i].y;
                int z1 = twPoint[i].z;
                if (y1 < 0)//如果y1是大于42°（大于42°的体温降温半小时画图）则，虚线开始起点从y=20开始
                {
                    y1 = 20;
                }

                int x2 = twPoint[i + 1].x;
                int y2 = twPoint[i + 1].y;
                int z2 = twPoint[i + 1].z;

                int yy0, yy1;
                if (z1 + z2 == 1 || z1 + z2 == 2)//z1+z2=1为降温半小时,z1+z2=2为降温1小时,z=0代表非降温体温，1代表半小时降温体温，2代表1小时降温体温。只有半小时降温体温需要画虚线+红圈，-2代表不需要画（请假外出检查）
                {
                    if (x1 == x2)
                    {
                        yy0 = y1 < y2 ? y1 : y2;
                        yy1 = y1 < y2 ? y2 : y1;

                        int y0 = yy0;
                        for (int yy = yy0 + 5; yy <= yy1; yy += 5)
                        {
                            graph.DrawLine(penXuXian, x1, y0, x1, yy);
                            //体温虚线   
                            y0 = yy + 8;
                        }
                    }
                }
            }



            #endregion

            #endregion


            #region 疼痛画图
            float minTt = 0;
            float maxTt = 11;
            // 从数据库读取一周的数据，以测量时间排序保存在alTT中
            Pen penTengTong = new Pen(Color.Red, 2);//疼痛蓝空心圆
            Pen penTengTongLine = new Pen(Color.Red, 2);//疼痛蓝色连线
            Pen penTtXuXian = new Pen(Color.Red, 2);//疼痛蓝色虚线
            Font fontTtSj = new Font("宋体", 8F, ((FontStyle)((FontStyle.Bold))), GraphicsUnit.Point, ((byte)(134)));
            ArrayList alTengTong = temperatureChartService.ReadTTData(sFirstDate,InpatientId);
            int BackX = 0;
            int BackY = 0;
            for (int z = 0; z < alTengTong.Count; z++)
            {
                TTClass ttclass = alTengTong[z] as TTClass;
                TimeSpan ts = ttclass.dt - dtBase;//时间差
                float fTt = ttclass.tt;//疼痛值
                float fx = (float)(nWidthPerGrid * (float)ts.TotalMinutes / (4 * 60) + (float)nLeftSpace);
                int x = (int)fx;
                //计算疼痛值y坐标
                int yTemp = (int)(((maxTt - fTt) / 2) * nHeightPerGrid) + nTopSpace + (50 * nHeightPerGrid) - 80;
                if (ttclass.CeliangLeixing != "-2")
                {
                    if (ttclass.CeliangLeixing == "0")
                    {
                        graph.DrawString("X", fontTtSj, new SolidBrush(Color.Red), new Point(x - 5, yTemp - 5));
                        if (BackX != 0 || BackY != 0)
                        {
                            graph.DrawLine(penTengTongLine, BackX - 2, BackY, x, yTemp);   //疼痛相连线 
                        }
                        BackX = x;
                        BackY = yTemp;
                    }
                    else if (ttclass.CeliangLeixing == "1")//降疼后
                    {
                        int y0 = BackY;
                        for (int yy = BackY; yy <= yTemp; yy += 5)
                        {
                            graph.DrawLine(penTtXuXian, BackX - 2, y0, x, yy);   //疼痛相连线 

                            y0 = yy + 8;
                        }
                        graph.DrawEllipse(penTengTong, x - 3, yTemp - 3, 6, 6);
                    }
                }
                else
                {
                    BackX = 0;
                    BackY = 0;
                }
            }
            #endregion
            
            MemoryStream mStream = new MemoryStream();
            Pic.Save(mStream, ImageFormat.Gif);//试验说明对于此类图片gif的压缩比例比jpg高很多
            graph.Dispose();
            Pic.Dispose();
            return File(mStream.ToArray(), "image/GIF");//.gif == image/GIF		//.jpg==image/jpeg
        }

        #endregion
    }
}