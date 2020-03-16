using System;

namespace EMR.Data.Models
{
    public partial class AI_DeptInfo
    {
        /// <summary>
        /// 作废判别名称0正常1作废
        /// </summary>
        public string IsCanceName { get; set; }
        /// <summary>
        /// 病区判别名称0不是1是
        /// </summary>
        public String IsInpatientName { get; set; }
    }
}
