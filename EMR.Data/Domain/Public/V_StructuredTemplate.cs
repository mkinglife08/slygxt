using System;

namespace EMR.Data.Models
{
    public partial class V_StructuredTemplate:AI_StructuredTemplate
    {
        /// <summary>
        /// 作废判别名称0正常1作废
        /// </summary>
        public string DelName { get; set; }
        /// <summary>
        /// 是否末级判别0不是末级1末级
        /// </summary>
        public string IsCategoryName { get; set; }
        /// <summary>
        /// 模板类型名称
        /// </summary>
        public string TemplateTypeName { get; set; }
        /// <summary>
        /// 共享类型名称
        /// </summary>
        public string ShareTypeName { get; set; }
        /// <summary>
        ///  父类名称
        /// </summary>
        public string ParentTempName { get; set; }


    }
}
