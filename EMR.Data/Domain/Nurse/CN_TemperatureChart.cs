using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.Models
{
    public partial class CN_TemperatureChart
    {
    }

    #region 用于体温单作画

    public class TWPoint
    {
        public int x;
        public int y;
        public int z;
        public TWPoint()
        {

        }
        public TWPoint(int xx, int yy, int zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }
        public TWPoint(int xx, int yy)
        {
            x = xx;
            y = yy;
            z = 0;
        }
    }

    /// <summary>
    /// 体温单补充描述
    /// </summary>
    public class TwdBCMS
    {
        public string[] strBC1 = new string[14];
        public string[] strBC2 = new string[14];
        public string[] strBC3 = new string[14];
        public string[] strBC4 = new string[14];
        public string[] strBC5 = new string[14];
        public string[] strBC6 = new string[14];
    }

    public class TimeTwMbHx
    {
        public DateTime dt;
        public float fTemp;//体温         
        public int nMiaobo = 0;
        /// <summary>
        /// 脉搏类型
        /// </summary>
        public string MiaoboLeixing = "0";
        //public int nHuxi = 0;
        public string nHuxi;
        /// <summary>
        /// 体温类型代码
        /// </summary>
        public string TiwenLeixing = "0";
        /// <summary>
        /// 测量类型
        /// </summary>
        public string CeliangLeixing = "0";
        /// <summary>
        /// 体温补充内容
        /// </summary>
        public string sBC;
        /// <summary>
        /// 收缩压
        /// </summary>
        public string sXy1;
        /// <summary>
        /// 舒张压
        /// </summary>
        public string sXy2;
        /// <summary>
        /// 氧饱和度
        /// </summary>
        public string sSpo2;
        public TimeTwMbHx(DateTime d, float t)
        {
            dt = d;
            fTemp = t;
        }
        public TimeTwMbHx()
        {

        }

        public TimeTwMbHx(DateTime d, float t, int nMb)
        {
            dt = d;
            fTemp = t;
            nMiaobo = nMb;
        }
        public TimeTwMbHx(DateTime d, float t, int nMb, string nHx, float tl)
        {
            dt = d;
            fTemp = t;
            nMiaobo = nMb;
            nHuxi = nHx;
        }
        public TimeTwMbHx(DateTime d, float t, int nMb, string nHx)
        {
            dt = d;
            fTemp = t;
            nMiaobo = nMb;
            nHuxi = nHx;
        }
    }

    /// <summary>
    /// 疼痛类
    /// </summary>
    public class TTClass
    {
        public DateTime dt;
        public float tt;//疼痛 
        public string TengTongLeixing = "0";
        public string CeliangLeixing = "0";
        public TTClass(DateTime d, float ftt)
        {
            dt = d;
            tt = ftt;
        }
    }
    #endregion

}
