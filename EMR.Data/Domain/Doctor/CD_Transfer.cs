using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class CD_Transfer
    {
        /// <summary>
        /// 住院病人姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string InpatientName { get; set; }

        /// <summary>
        /// 病人健康卡号
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string HealthCard { get; set; }

        /// <summary>
        /// 转前科室名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string OldDeptName { get; set; }

        /// <summary>
        /// 转前病区名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string OldWardName { get; set; }

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
    }
}
