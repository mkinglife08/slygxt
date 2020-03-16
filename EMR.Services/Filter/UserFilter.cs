/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：UserFilter.cs
// 文件功能描述： 用户数据检索器。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：李荷 2018-12-29
// 修改描述：新增了用户类型USERTYPE的筛选字段
----------------------------------------------------------------*/

using EMR.Data.CustomAttribute;
using System;

namespace EMR.Services.Filter
{
    public class UserFilter : CommonFilter
    {
        [Filter(Filter_Type.equal)]
        public string USERID { get; set; }

        [Filter(Filter_Type.equal)]
        public string USERCODE { get; set; }

        public string PASSWORD { get; set; }

        public string SYSID { get; set; }

        [Filter(Filter_Type.equal)]
        public int USERTYPE { get; set; }
    }
}
