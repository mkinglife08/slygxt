/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FilterAttribute.cs
// 文件功能描述： 过滤器特性。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMR.Data.CustomAttribute
{
    /// <summary>
    /// 过滤器特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FilterAttribute : Attribute
    {
        public FilterAttribute(Filter_Type _type, string operatorFormat = "")
        {
            _FilterType = _type;
            _operatorFormat = operatorFormat;
        }
        private Filter_Type _FilterType;
        public Filter_Type FilterType
        {
            get
            {
                return _FilterType;
            }
        }

        private string _operatorFormat;
        public string OperatorFormat
        {
            get
            {
                return _operatorFormat;
            }
        }

        /// <summary>
        /// 根据过滤类型枚举，获取相应的操作符
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public string GetOperator(ref string strValue)
        {
            string strRet = "";
            switch (FilterType)
            {
                case Filter_Type.equal:
                    strRet = " = ";
                    break;
                case Filter_Type.greater:
                    strRet = " > ";
                    break;
                case Filter_Type.LessThan:
                    strRet = " < ";
                    break;
                case Filter_Type.like:
                    strRet = " like ";
                    strValue = "%" + strValue + "%";
                    break;
                case Filter_Type.QueryIn:
                    strRet = " in ";
                    strValue = "(" + strValue + ")";
                    break;
                case Filter_Type.SqlFilter:
                    strRet = " ";
                    strValue = "(" + strValue + ")";
                    break;
            }
            return strRet;
        }
    }

    /// <summary>
    /// 过滤类型枚举
    /// </summary>
    public enum Filter_Type : short
    {
        /// <summary>
        /// 等于
        /// </summary>
        equal = 0,

        like = 1,

        greater = 2,//大于

        LessThan = 3,//小于

        contains = 4,

        QueryIn = 5,

        /// <summary>
        /// 完整的SQL语句查询条件
        /// </summary>
        SqlFilter = 6,

        Range = 7,//范围
    }
}