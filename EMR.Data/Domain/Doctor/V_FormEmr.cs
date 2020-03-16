using System;

namespace EMR.Data.Models
{
    public partial class V_FormEmr : CD_FormEmr
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// 模板内容
        /// </summary>
        public string TemplateContent { get; set; }

        /// <summary>
        /// 模板类型10知情同意书，11营养评估，12康复评估，13手术风险评估表，14手术安全核查表，15心血管介入治疗术安全核查表
        /// </summary>
        public string TemplateType { get; set; }
    }
}
