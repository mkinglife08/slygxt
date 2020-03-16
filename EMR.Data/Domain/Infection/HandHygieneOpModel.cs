using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.Models
{
    /// <summary>
    /// 医生，护士，医技，工人执行人数实体
    /// </summary>
    public class HandHygieneOpModel
    {
        /// <summary>
        /// 职业名称
        /// </summary>
        public string zyName { get; set; }

        /// <summary>
        /// 医生执行列表  1，
        /// </summary>
        /// public List<ItemName> itemList { get; set; } 
        
        //操作类型列表
        public List<OpCategory> opList { get; set; }
    } 

    /// <summary>
    /// 操作类别，消，洗，未
    /// </summary>
    public class OpCategory {
        /// <summary>
        /// 消
        /// </summary>
        public int x { get; set; }  

        /// <summary>
        /// 洗
        /// </summary>
        public int xx { get; set; }

        /// <summary>
        /// 未
        /// </summary>
        public int w { get; set; }
    }

}
