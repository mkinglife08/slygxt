
using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class API_Payment
    {
        /// <summary>
        /// 预缴款
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string InpatientId { get; set; }

        /// <summary>
        /// 预缴款
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string AdvancePayment { get; set; }


        /// <summary>
        /// 余额
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string Balance { get; set; }

        /// <summary>
        /// 总额
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string Total { get; set; }

        /// <summary>
        /// 自理
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string SelfCare { get; set; }

        /// <summary>
        /// 自费
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string SelfPay { get; set; }

        /// <summary>
        /// 现金
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string Cash { get; set; }

        /// <summary>
        /// 催款
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string PressMoney { get; set; }

        /// <summary>
        /// 催款时间
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public DateTime? PressTime { get; set; }

    }
}