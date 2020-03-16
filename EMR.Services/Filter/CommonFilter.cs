/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CommonFilter.cs
// 文件功能描述： 通用的数据检索器，提供一些通用的检索字段，比如：当前用户的组织机构ID、关键字查询等字段。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data.CustomAttribute;
using System;

namespace EMR.Services.Filter
{
    public class CommonFilter: IFilter
    {
        private string _MYORGANID;

        /// <summary>
        /// 当前用户的组织机构ID
        /// </summary>
        [Filter(Filter_Type.SqlFilter)]
        public string MYORGANID
        {
            set { _MYORGANID = value; }
            get
            {
                if (!string.IsNullOrWhiteSpace(_MYORGANID) && _MYORGANID != "0")
                    return " ORGANID = '" + _MYORGANID + "' ";
                else
                    return "";
            }
        }

        /// <summary>
        /// 关键字查询
        /// </summary>
        public string keyword { get; set; }

        /// <summary>
        /// 父类英文名
        /// </summary>
        public string ParentDictNameEN { get; set; }
    }
}
