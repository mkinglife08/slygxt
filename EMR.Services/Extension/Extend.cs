using EMR.Data;
using EMR.Data.CustomAttribute;
using EMR.Data.Domain;
using System;
using System.Data;
using System.Reflection;

namespace EMR.Services.Extension
{
    public static class Extend
    {
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static int GetRandom(int minVal, int maxVal)
        {
            //这样产生0 ~ 100的强随机数（不含100）
            int m = maxVal - minVal;
            int rnd = int.MinValue;
            decimal _base = (decimal)long.MaxValue;
            byte[] rndSeries = new byte[8];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(rndSeries);
            long l = BitConverter.ToInt64(rndSeries, 0);
            rnd = (int)(Math.Abs(l) / _base * m);
            return minVal + rnd;
        }

        /// <summary>
        /// 根据过滤器获取查询字符串
        /// </summary>
        /// <typeparam name="T">Filter</typeparam>
        /// <param name="t">过滤器实体</param>
        /// <returns></returns>
        public static string GetQueryString<T>(this T t) where T : Filter.IFilter
        {
            string strRet = "";
            PropertyInfo[] properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo item in properties)
            {
                FilterAttribute remarkAttribute = (FilterAttribute)item.GetCustomAttribute(typeof(FilterAttribute));
                string strValue = item.GetValue(t) + "";
                if (remarkAttribute != null && strValue != "")
                {
                    if (remarkAttribute.FilterType == Filter_Type.SqlFilter)
                        strRet += string.Format(" and {0}", strValue);
                    else if (remarkAttribute.FilterType == Filter_Type.QueryIn)
                        strRet += string.Format(" and {0} {1} {2}", item.Name, remarkAttribute.GetOperator(ref strValue), strValue);
                    else
                        strRet += string.Format(" and {0} {1} '{2}'", item.Name, remarkAttribute.GetOperator(ref strValue), strValue);
                }
            }
            return strRet;
        }

        public static DataSet GetDataSetByPagination<T>(this T t, PagingEntity page, ref string HtmlPage) where T : class
        {
            DataSet ds = EntityOperate<T>.GetDataSetByPagination(page);
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int iDataCount = 0;
                int.TryParse(ds.Tables[1].Rows[0][0] + "", out iDataCount);
                page.DataCount = iDataCount;
                HtmlPage = page.CreateHtmlPage("");
            }
            return ds;
        }


        /// <summary>
        /// NULL数据处理
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="sDefault"></param>
        /// <returns></returns>
        public static string HandleNull(object obj, string sDefault)
        {
            if (obj == System.DBNull.Value || obj == null)
            {
                return sDefault;
            }
            else
            {
                if (obj.ToString() == "") return sDefault;
                return obj.ToString();
            }
        }

        public static string HandleNull(object obj, string etram, string sDefault, bool preorsuf)
        {
            if (obj == System.DBNull.Value || obj == null)
            {
                return sDefault;
            }
            else
            {
                if (obj.ToString() == "") return sDefault;
                return preorsuf ? etram + obj.ToString() : obj.ToString() + etram;
            }
        }

        public static decimal HandleNullDec(object obj, decimal dDefault)
        {
            if (obj == System.DBNull.Value || obj == null || obj.ToString() == "")
            {
                return dDefault;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        public static int HandleNull(object obj, int iDefault)
        {
            if (obj == System.DBNull.Value || obj == null || obj.ToString() == "")
            {
                return iDefault;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public static DateTime HandleNull(object obj, DateTime dateDefault)
        {
            if (obj == System.DBNull.Value || obj == null || obj.ToString() == "")
            {
                return dateDefault;
            }
            else
            {
                return Convert.ToDateTime(obj);
            }
        }

        public static string HandleNull(object obj, string dateDefault, string dateformat)
        {
            if (obj == System.DBNull.Value || obj == null || obj.ToString() == "")
            {
                return dateDefault;
            }
            else
            {
                return Convert.ToDateTime(obj).ToString(dateformat);
            }
        }

    }
}
