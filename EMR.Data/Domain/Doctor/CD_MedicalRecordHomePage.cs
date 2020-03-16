
using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class CD_MedicalRecordHomePage
    {
        /// <summary>
        /// 入院途径名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string AdmissionWayName { get; set; }
        /// <summary>
        /// 血型名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string BloodTypeName { get; set; }
        /// <summary>
        /// RH名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string RHName { get; set; }
        /// <summary>
        /// 离院方式名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string LeaveHospitalWayName { get; set; }
        /// <summary>
        /// 病案质量名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string MedicalRecordMassName { get; set; }
        /// <summary>
        /// 转归情况名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string PrognosisOfDiseaseName { get; set; }
        /// <summary>
        /// 创建人姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CreatorName { get; set; }
        /// <summary>
        /// 修改人姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string UpdaterName { get; set; }
        
    }
}