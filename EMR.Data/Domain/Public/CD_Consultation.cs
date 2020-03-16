using EMR.Data.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.Models
{
    public partial class CD_Consultation
    {
        //病人名称
        [FieldType(FieldTypeEnum.Ignore)]
        public string InpatientName { get; set; }
        //病人住院号
        [FieldType(FieldTypeEnum.Ignore)]
        public string InpatientCode { get; set; }
        //病人科室
        [FieldType(FieldTypeEnum.Ignore)]
        public string InpatientDeptName { get; set; }
        //病人病区
        [FieldType(FieldTypeEnum.Ignore)]
        public string InpatientWardName { get; set; }
        //会诊类型：1：普通 2：紧急
        [FieldType(FieldTypeEnum.Ignore)]
        public string ConsultationTypeName { get; set; }
        //会诊单状态 1新开 2已回复
        [FieldType(FieldTypeEnum.Ignore)]
        public string ConsultationStateName { get; set; }
        // 会诊医院类型：1：本院 2：外院
        [FieldType(FieldTypeEnum.Ignore)]
        public string HospitalTypeName { get; set; }
        // 申请人姓名
        [FieldType(FieldTypeEnum.Ignore)]
        public string RequesterName { get; set; }
        // 申请人科室
        [FieldType(FieldTypeEnum.Ignore)]
        public string RequestDepartName { get; set; }
    }
}
