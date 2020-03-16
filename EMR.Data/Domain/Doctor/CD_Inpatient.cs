
using EMR.Data.CustomAttribute;
using System;
using System.Collections.Generic;

namespace EMR.Data.Models
{
    public partial class CD_Inpatient
    {
        /// <summary>
        /// 是否有病案首页ID，用于判断是否首次导入。
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string HomePageId { get; set; }

        /// <summary>
        /// 入院诊断 诊断类型为 2
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string Diagnosis { get; set; }

        /// <summary>
        /// 报告
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string Report { get; set; }

        /// <summary>
        /// 主治医师
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string VisitingName { get; set; }

        /// <summary>
        /// 付费类型名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string PaymentTypeName { get; set; }

        /// <summary>
        /// 病历类型名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string RecordTypeName { get; set; }

        /// <summary>
        /// 临床路径名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CpManageName { get; set; }

        /// <summary>
        /// 当前科室名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CurrentDeptName { get; set; }

        /// <summary>
        /// 当前病区名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CurrentWardName { get; set; }

        /// <summary>
        /// 审阅状态
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public int? AccessState { get; set; }

        /// <summary>
        /// 申请审阅人数
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public int? ApplyAccessNumber { get; set; }

        /// <summary>
        /// 最后一次转科信息
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string LastConversionDept { get; set; }
    }
}