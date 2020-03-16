using System;
using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Models
{
    /// <summary>
    /// 医院感染病例个案调查 血清学和病原学检测表
    /// </summary>
    [Serializable]
    public partial class BUS_INFECTIONEXAMINE_BLOOD
    { 
        /// <summary>
        /// 血清学和病原学检测ID 主键
        /// </summary>
        [Display(Name = "血清学和病原学检测ID")]
        [StringLength(20)]
        public virtual string BLOODID { get; set; } 
        /// <summary>
        /// 标本类型
        /// </summary>
        [Display(Name = "标本类型")]
        [StringLength(40)]
        public virtual string BBLX { get; set; } 
        /// <summary>
        /// 采样时间
        /// </summary>
        [Display(Name = "采样时间")]
        public virtual DateTime? CYSJ { get; set; }
        /// <summary>
        /// 检测项目
        /// </summary>
        [Display(Name = "检测项目")]
        [StringLength(40)]
        public virtual string JCXM { get; set; }
        /// <summary>
        /// 检测方法
        /// </summary>
        [Display(Name = "检测方法")]
        [StringLength(40)]
        public virtual string JCFF { get; set; }
        /// <summary>
        /// 检测单位
        /// </summary>
        [Display(Name = "检测单位")]
        [StringLength(40)]
        public virtual string JCDW { get; set; }
        /// <summary>
        /// 检测结果
        /// </summary>
        [Display(Name = "检测结果")]
        [StringLength(40)]
        public virtual string JCJG { get; set; }
        /// <summary>
        ///  医院感染病例个案调查表 主键
        /// </summary>
        [Display(Name = " 医院感染病例个案调查表主键")]
        [StringLength(40)]
        public virtual string EXID { get; set; }

        /// <summary>
        ///组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }
    }
}
