
using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class CD_HospitalRecord
    {
        /// <summary>
        /// 创建医生姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CreatorName { get; set; }

        /// <summary>
        /// 修改医生姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string UpdaterName { get; set; }
    }
}
