/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CommonFilter.cs
// 文件功能描述： 住院数据检索器，提供一些住院数据的检索字段。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data.CustomAttribute;
using System;

namespace EMR.Services.Filter
{
    public class InpatientFilter : CommonFilter
    {
        /// <summary>
        /// 关键字查询
        /// </summary>
        public string KeywordType { get; set; }

        [Filter(Filter_Type.equal)]
        public string InpatientId { get; set; }

        /// <summary>
        /// 当前病区
        /// </summary>
        [Filter(Filter_Type.equal)]
        public string CurrentWardID { get; set; }


        /// <summary>
        /// 病历状态，1：在院，2：待归档，4：已归档
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 病历所属，1：本人，4：授权病人，5：本科室
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 登入医生ID
        /// </summary>
        public string UserID { get; set; }
    }
}
