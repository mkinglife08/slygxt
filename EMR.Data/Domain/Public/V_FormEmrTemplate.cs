using System;

namespace EMR.Data.Models
{
    public partial class V_FormEmrTemplate : CD_FormEmrTemplate
    {
        /// <summary>
        /// 模板类型名称
        /// </summary>
        public string TemplateTypeName { get; set; }
        /// <summary>
        /// 作废判别名称0正常1作废
        /// </summary>
        public string DelName { get; set; }
        /// <summary>
        ///  父类名称
        /// </summary>
        public string ParentTempName { get; set; }


    }
}
