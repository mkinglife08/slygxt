
using System;

namespace EMR.Data.Models
{
    public partial class CD_OperationRecord
    {
        /// <summary>
        /// 麻醉方式 名称     450
        /// </summary>
        public string AnesthesiaWayName { get; set; }

        /// <summary>
        /// 手术级别 名称     170
        /// </summary>
        public string OperationLevelName { get; set; }

        /// <summary>
        /// 手术切口愈合等级 名称     343
        /// </summary>
        public string HealingLevelName { get; set; }

        /// <summary>
        /// 手术切口分级 名称       238
        /// </summary>
        public string IncisionLevelName { get; set; }

        /// <summary>
        /// 手术类型 名称     802
        /// </summary>
        public string OperationTypeName { get; set; }

        /// <summary>
        /// 手术类别 名称     797
        /// </summary>
        public string OperationCategoryName { get; set; }
    }
}