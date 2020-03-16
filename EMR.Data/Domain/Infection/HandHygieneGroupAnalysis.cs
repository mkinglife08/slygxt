using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.Models
{
    /// <summary>
    /// 手卫生依从性，数据分组类
    /// </summary>
    public class HandHygieneGroupAnalysis
    { 
        /// <summary>
        /// 职业
        /// </summary>
        public string zy { get; set; }
        /// <summary>
        ///排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 分组后的数量
        /// </summary>
        public int currentSum { get; set; }

        public IEnumerable<BUS_HANDHYGIENE_SOURCE> handhygiene_source { get; set; }
         
    }
}
