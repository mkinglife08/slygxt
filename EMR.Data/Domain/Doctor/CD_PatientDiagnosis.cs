
using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class CD_PatientDiagnosis
    {   
        public string DiagnosisFlagName { get; set; }
        public string DiagnosisTypeName { get; set; }
        /// <summary>
        /// 住院病人名字
        /// </summary>
        public string InpatientName { get; set; }

        /// <summary>
        /// 创建用户电子签名图片地址
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string RecordUserESign { get; set; }

    }
}