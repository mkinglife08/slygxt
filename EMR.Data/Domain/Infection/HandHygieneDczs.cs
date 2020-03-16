using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.Models
{

    /// <summary>
    /// 调查总数返回实体
    /// </summary>
    public class HandHygieneDczs
    {
        /// <summary>
        /// 医生
        /// </summary>
        public int ys { get; set; }
        /// <summary>
        /// 护士
        /// </summary>
        public int hs { get; set; }
        /// <summary>
        /// 医技
        /// </summary>
        public int yj { get; set; }
        /// <summary>
        /// 工人
        /// </summary>
        public int gr { get; set; }
    }
}
