
using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class CD_ProgressNote
    {
        /// <summary>
        /// 病程类别名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string ProgressTypeName { get; set; }

        /// <summary>
        /// 创建用户名称
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CreatorName { get; set; }

        /// <summary>
        /// 创建用户电子签名图片地址
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string CreatorESign { get; set; }
        /// <summary>
        /// 查房医师姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string WardRoundUserName { get; set; }

    }

    public partial class ProgressNote_Content_Item
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}