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
    public class PatientDiagnosisFilter : CommonFilter
    {

        [Filter(Filter_Type.equal)]
        public string InpatientId { get; set; }

        [Filter(Filter_Type.equal)]
        public string DiagnosisType { get; set; }
    }
}
