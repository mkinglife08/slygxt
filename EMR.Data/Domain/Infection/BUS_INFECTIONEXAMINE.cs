
using System;
using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Models
{
    /// <summary>
    /// 医院感染病例个案调查表
    /// </summary>
    [Serializable]
    public partial class BUS_INFECTIONEXAMINE
    {
        /// <summary>
        /// 医院感染病例个案调查表 主键
        /// </summary>
        [Display(Name = "主键")]
        [StringLength(20)]
        public virtual string EXID { get; set; }


        /// <summary>
        /// 患者姓名
        /// </summary>
        [Display(Name = "患者姓名")]
        [StringLength(50)]
        public virtual string HZXM { get; set; }
        /// <summary>
        /// 家长姓名
        /// </summary>
        [Display(Name = "家长姓名")]
        [StringLength(50)]
        public virtual string JZXM { get; set; }

        /// <summary>
        /// 患者ID
        /// </summary>
        [Display(Name = "患者ID")]
        [StringLength(20)]
        public virtual string HZID { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        [StringLength(20)]
        public virtual string XB { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄")]
        [StringLength(20)]
        public virtual string NL { get; set; }
        /// <summary>
        /// 发病序号
        /// </summary>
        [Display(Name = "发病序号")]
        [StringLength(20)]
        public virtual string FBXH { get; set; }
        /// <summary>
        /// 发生感染时所在科室ID
        /// </summary>
        [Display(Name = "发生感染时所在科室ID")]
        [StringLength(20)]
        public virtual string SZKSID { get; set; }
        /// <summary>
        /// 发生感染时所在科室名称
        /// </summary>
        [Display(Name = "发生感染时所在科室名称")]
        [StringLength(20)]
        public virtual string SZKSNAME { get; set; }
        /// <summary>
        /// 曾住科室ID
        /// </summary>
        [Display(Name = "曾住科室ID")]
        [StringLength(20)]
        public virtual string CZKSID { get; set; }
        /// <summary>
        /// 曾住科室名称
        /// </summary>
        [Display(Name = "曾住科室名称")]
        [StringLength(20)]
        public virtual string CZKSNAME { get; set; } 
        /// <summary>
        /// 发病日期
        /// </summary>
        [Display(Name = "发病日期")]
        public virtual DateTime? FBRQ { get; set; }
        /// <summary>
        /// 发现日期
        /// </summary>
        [Display(Name = "发现日期")]
        public virtual DateTime? FXRQ { get; set; }
         
        /// <summary>
        /// 感染诊断部位
        /// </summary>
        [Display(Name = "感染诊断部位")]
        [StringLength(20)]
        public virtual string GRZDBW { get; set; }
        /// <summary>
        /// 入院日期
        /// </summary>
        [Display(Name = "入院日期")]
        public virtual DateTime? RYRQ { get; set; }
         
        /// <summary>
        /// 可能的感染原因
        /// </summary>
        [Display(Name = "可能的感染原因")]
        [StringLength(40)]
        public virtual string KNGRYY { get; set; }
        /// <summary>
        /// 原发疾病
        /// </summary>
        [Display(Name = "原发疾病")]
        [StringLength(40)]
        public virtual string YFJB { get; set; }
        /// <summary>
        /// 临床症状
        /// </summary>
        [Display(Name = "临床症状")]
        [StringLength(40)]
        public virtual string LCZZ { get; set; }
        /// <summary>
        /// 临床体征
        /// </summary>
        [Display(Name = "临床体征")]
        [StringLength(40)]
        public virtual string LCTZ { get; set; }
        /// <summary>
        /// 微生物送检结果
        /// </summary>
        [Display(Name = "微生物送检结果")]
        [StringLength(40)]
        public virtual string WSWJG { get; set; }
        /// <summary>
        /// 微生物送检日期
        /// </summary>
        [Display(Name = "微生物送检日期")]
        public virtual DateTime? WSWRQ { get; set; }

        /// <summary>
        /// 病室环境
        /// </summary>
        [Display(Name = "病室环境")]
        [StringLength(20)]
        public virtual string BSHJ { get; set; }
        /// <summary>
        /// 主管护士
        /// </summary>
        [Display(Name = "主管护士")]
        [StringLength(40)]
        public virtual string ZGHS { get; set; }
        /// <summary>
        /// 日常护士
        /// </summary>
        [Display(Name = "日常护士")]
        [StringLength(40)]
        public virtual string RCHS { get; set; }
        /// <summary>
        /// 主管医生
        /// </summary>
        [Display(Name = "主管医生")]
        [StringLength(40)]
        public virtual string ZGYS { get; set; }
        /// <summary>
        /// 使用快速手消毒剂
        /// </summary>
        [Display(Name = "使用快速手消毒剂")]
        [StringLength(20)]
        public virtual string KSXD { get; set; }
        /// <summary>
        /// 医务人员出勤情况
        /// </summary>
        [Display(Name = "医务人员出勤情况")]
        [StringLength(80)]
        public virtual string YWCQ { get; set; }
        /// <summary>
        /// 周围患者是否有类似临床症状、体征
        /// </summary>
        [Display(Name = "周围患者是否有类似临床症状、体征")]
        [StringLength(20)]
        public virtual string ZWHZTZ { get; set; }
        /// <summary>
        ///  患者接触的相关医疗器械
        /// </summary>
        [Display(Name = " 患者接触的相关医疗器械")]
        [StringLength(40)]
        public virtual string XGYLQX { get; set; }
        /// <summary>
        ///  患者接触的相关医疗器械 消毒  灭菌
        /// </summary>
        [Display(Name = " 患者接触的相关医疗器械 消毒  灭菌")]
        [StringLength(20)]
        public virtual string XGYLQXSY { get; set; }

        /// <summary>
        ///  近期环境抽查结果 空气
        /// </summary>
        [Display(Name = "近期环境抽查结果 空气")]
        [StringLength(40)]
        public virtual string CCJGKQ { get; set; }
        /// <summary>
        ///  近期环境抽查结果 空气
        /// </summary>
        [Display(Name = "近期环境抽查结果 物表")]
        [StringLength(40)]
        public virtual string CCJGWB { get; set; }
        /// <summary>
        ///  近期环境抽查结果 空气
        /// </summary>
        [Display(Name = "近期环境抽查结果 手部")]
        [StringLength(40)]
        public virtual string CCJGSB { get; set; }


        /// <summary>
        ///  有无可疑的使用中消毒液
        /// </summary>
        [Display(Name = "有无可疑的使用中消毒液")]
        [StringLength(40)]
        public virtual string KYXDY { get; set; }
        /// <summary>
        ///  有无可疑的使用中消毒液批号
        /// </summary>
        [Display(Name = "有无可疑的使用中消毒液批号")]
        [StringLength(40)]
        public virtual string KYXDYPH { get; set; }
        /// <summary>
        ///  有无可疑的静脉注射液体
        /// </summary>
        [Display(Name = "有无可疑的静脉注射液体")]
        [StringLength(40)]
        public virtual string KYZSY { get; set; }
        /// <summary>
        ///  有无可疑的静脉注射液体批号
        /// </summary>
        [Display(Name = "有无可疑的静脉注射液体批号")]
        [StringLength(40)]
        public virtual string KYZSYPH { get; set; }


        /// <summary>
        ///   本组共有患者   例
        /// </summary>
        [Display(Name = " 本组共有患者   例")]
        [StringLength(20)]
        public virtual string BZHZSL { get; set; } 
        /// <summary>
        /// 本患者为第  例
        /// </summary>
        [Display(Name = "本患者为第  例")]
        [StringLength(20)]
        public virtual string BZHZXL { get; set; }
        /// <summary>
        /// 患者感染源可能来自
        /// </summary>
        [Display(Name = "患者感染源可能来自")]
        [StringLength(20)]
        public virtual string BZHZGRY { get; set; }


        /// <summary>
        /// 患者易感因素  手术名称
        /// </summary>
        [Display(Name = "患者易感因素  手术名称")]
        [StringLength(40)]
        public virtual string SSMC { get; set; }
        /// <summary>
        /// 是否急诊
        /// </summary>
        [Display(Name = "是否急诊")]
        [StringLength(40)]
        public virtual string JZ { get; set; }

        /// <summary>
        /// 手术日期
        /// </summary>
        [Display(Name = "手术日期")]
        public virtual DateTime? SSRQ { get; set; }
        /// <summary>
        /// 参与手术人员
        /// </summary>
        [Display(Name = "参与手术人员")]
        [StringLength(80)]
        public virtual string CYSSRY { get; set; }
        /// <summary>
        /// 手术持续时间
        /// </summary>
        [Display(Name = "手术持续时间")]
        [StringLength(20)]
        public virtual string SSCXSJ { get; set; }
        /// <summary>
        /// 手术植入物
        /// </summary>
        [Display(Name = "手术植入物")]
        [StringLength(20)]
        public virtual string SSZRW { get; set; }
        /// <summary>
        /// 手术切口类型
        /// </summary>
        [Display(Name = "手术切口类型")]
        [StringLength(20)]
        public virtual string SSQKLX { get; set; }
        /// <summary>
        /// 麻醉（ASA）评分
        /// </summary>
        [Display(Name = "麻醉（ASA）评分")]
        [StringLength(20)]
        public virtual string MZPF { get; set; }
        /// <summary>
        /// 全麻  硬膜外麻    腰麻
        /// </summary>
        [Display(Name = "全麻  硬膜外麻    腰麻")]
        [StringLength(20)]
        public virtual string MZLX { get; set; }
        /// <summary>
        /// 糖尿病
        /// </summary>
        [Display(Name = "糖尿病")]
        [StringLength(20)]
        public virtual string TNB { get; set; }
        /// <summary>
        /// 免疫缺陷
        /// </summary>
        [Display(Name = "免疫缺陷")]
        [StringLength(20)]
        public virtual string MYQX { get; set; }
        /// <summary>
        /// 泌尿道插管
        /// </summary>
        [Display(Name = "泌尿道插管")]
        [StringLength(20)]
        public virtual string MNDCG { get; set; }
        /// <summary>
        /// 泌尿道插管时间
        /// </summary>
        [Display(Name = "泌尿道插管时间")]
        [StringLength(20)]
        public virtual string MNDCGSJ { get; set; }
        /// <summary>
        /// 肿瘤
        /// </summary>
        [Display(Name = "肿瘤")]
        [StringLength(20)]
        public virtual string ZL { get; set; }
        /// <summary>
        /// 免疫抑制剂
        /// </summary>
        [Display(Name = "免疫抑制剂")]
        [StringLength(20)]
        public virtual string MYYZJ { get; set; }
        /// <summary>
        /// 动静脉插管
        /// </summary>
        [Display(Name = "动静脉插管")]
        [StringLength(20)]
        public virtual string DJMCG { get; set; }
        /// <summary>
        /// 动静脉插管时间
        /// </summary>
        [Display(Name = "动静脉插管时间")]
        [StringLength(20)]
        public virtual string DJMCGSJ { get; set; }
        /// <summary>
        /// 昏迷
        /// </summary>
        [Display(Name = "昏迷")]
        [StringLength(20)]
        public virtual string HM { get; set; }
        /// <summary>
        /// 低蛋白血症
        /// </summary>
        [Display(Name = "低蛋白血症")]
        [StringLength(20)]
        public virtual string DDBXZ { get; set; }
        /// <summary>
        /// 引流管部位
        /// </summary>
        [Display(Name = "引流管部位")]
        [StringLength(20)]
        public virtual string YLGBW { get; set; }
        /// <summary>
        /// 引流管部位时间
        /// </summary>
        [Display(Name = "引流管部位时间")]
        [StringLength(20)]
        public virtual string YLGBWSJ { get; set; }
        /// <summary>
        /// </summary>
        /// 肝硬化
        /// </summary>
        [Display(Name = "肝硬化")]
        [StringLength(20)]
        public virtual string GYH { get; set; }
        /// </summary>
        /// WBC
        /// </summary>
        [Display(Name = "WBC")]
        [StringLength(20)]
        public virtual string WBC { get; set; }
        /// </summary>
        /// 激素及使用方法
        /// </summary>
        [Display(Name = "激素及使用方法")]
        [StringLength(80)]
        public virtual string JSSYFF { get; set; }
        /// </summary>
        /// 放疗
        /// </summary>
        [Display(Name = "放疗")]
        [StringLength(20)]
        public virtual string FL { get; set; }
        /// </summary>
        /// 化疗
        /// </summary>
        [Display(Name = "化疗")]
        [StringLength(20)]
        public virtual string HL { get; set; }
        /// </summary>
        /// 气管切开
        /// </summary>
        [Display(Name = "气管切开")]
        [StringLength(20)]
        public virtual string QGQK { get; set; }
        /// </summary>
        /// 气管切开时间
        /// </summary>
        [Display(Name = "气管切开时间")]
        [StringLength(20)]
        public virtual string QGQKSJ { get; set; }
        /// </summary>
        /// 上呼吸机
        /// </summary>
        [Display(Name = "上呼吸机")]
        [StringLength(20)]
        public virtual string SHXJ { get; set; }
        /// </summary>
        /// 上呼吸机时间
        /// </summary>
        [Display(Name = "上呼吸机时间")]
        [StringLength(20)]
        public virtual string SHXJSJ { get; set; }
        /// </summary>
        /// 哮喘
        /// </summary>
        [Display(Name = "哮喘")]
        [StringLength(20)]
        public virtual string XC { get; set; }
        /// </summary>
        /// 冠心病
        /// </summary>
        [Display(Name = "冠心病")]
        [StringLength(20)]
        public virtual string GXB { get; set; }
        /// </summary>
        /// 肾病
        /// </summary>
        [Display(Name = "肾病")]
        [StringLength(20)]
        public virtual string SZJB { get; set; }
        /// </summary>
        /// 慢性支气管炎
        /// </summary>
        [Display(Name = "慢性支气管炎")]
        [StringLength(20)]
        public virtual string MXZQGY { get; set; }
        /// </summary>
        /// 其它慢性肺部疾病
        /// </summary>
        [Display(Name = "其它慢性肺部疾病")]
        [StringLength(20)]
        public virtual string MXFBJB { get; set; }
        /// </summary>
        /// 其它慢性疾病
        /// </summary>
        [Display(Name = "其它慢性疾病")]
        [StringLength(20)]
        public virtual string QTMXJB { get; set; }



        /// </summary>
        /// A.6  患者生活习惯、既往健康史   A.6.1 饭前洗手
        /// </summary>
        [Display(Name = "饭前洗手")]
        [StringLength(20)]
        public virtual string FQXS { get; set; }
        /// </summary>
        /// 本次感染前是否其它部位感染
        /// </summary>
        [Display(Name = "本次感染前是否其它部位感染")]
        [StringLength(20)]
        public virtual string QTBWGR { get; set; }
        /// </summary>
        /// 感染部位
        /// </summary>
        [Display(Name = "感染部位")]
        [StringLength(40)]
        public virtual string GRBW { get; set; }

        /// </summary>
        /// A.7.1  品种A.7 患者发病前抗菌药物应用情况  
        /// </summary>
        [Display(Name = "抗菌药物应用情况")]
        [StringLength(40)]
        public virtual string KJYWPZ { get; set; }
        /// </summary>
        ///药品名称
        /// </summary>
        [Display(Name = "药品名称")]
        [StringLength(40)]
        public virtual string KJYWMC { get; set; }


        /// <summary>
        /// 抗菌药物开始时间
        /// </summary>
        [Display(Name = "抗菌药物开始时间")]
        public virtual DateTime? KJYWRQKS { get; set; }
        /// <summary>
        /// 抗菌药物结束时间
        /// </summary>
        [Display(Name = "抗菌药物结束时间")]
        public virtual DateTime? KJYWRQJS { get; set; }



        /// <summary>
        /// A.8 实验室检查   血常规
        /// </summary>
        [Display(Name = "血常规")]
        [StringLength(40)]
        public virtual string SYSXCG { get; set; }
        /// <summary>
        ///    CPR
        /// </summary>
        [Display(Name = "CPR")]
        [StringLength(40)]
        public virtual string CPR { get; set; }
        /// <summary>
        /// PCT  
        /// </summary>
        [Display(Name = "PCT")]
        [StringLength(40)]
        public virtual string SYSPCT { get; set; }
        /// <summary>
        /// 实验室检查其他  
        /// </summary>
        [Display(Name = "其他")]
        [StringLength(40)]
        public virtual string SYSQT { get; set; }

        /// <summary>
        /// A.9  转归与最终诊断情况   最终诊断    
        /// </summary>
        [Display(Name = "最终诊断")]
        [StringLength(20)]
        public virtual string ZZZD { get; set; }
        /// <summary>
        ///诊断单位  
        /// </summary>
        [Display(Name = "诊断单位")]
        [StringLength(40)]
        public virtual string ZDDW { get; set; }
        /// <summary>
        ///转归   痊愈  死亡  其它  
        /// </summary>
        [Display(Name = "转归")]
        [StringLength(20)]
        public virtual string ZG { get; set; } 
        /// <summary>
        /// 出院日期
        /// </summary>
        [Display(Name = "出院日期")]
        public virtual DateTime? CYRQ { get; set; }
        /// <summary>
        /// 死亡日期
        /// </summary>
        [Display(Name = "死亡日期")]
        public virtual DateTime? SWRQ { get; set; }
        /// <summary>
        ///死亡原因
        /// </summary>
        [Display(Name = "死亡原因")]
        [StringLength(40)]
        public virtual string SWYY { get; set; } 
        /// <summary>
        ///转归其他原因
        /// </summary>
        [Display(Name = "转归其他原因")]
        [StringLength(40)]
        public virtual string ZGQT { get; set; }


        /// <summary>
        ///调查单位
        /// </summary>
        [Display(Name = "调查单位")]
        [StringLength(40)]
        public virtual string DCDW { get; set; }
        /// <summary>
        ///调查者签名
        /// </summary>
        [Display(Name = "调查者签名")]
        [StringLength(40)]
        public virtual string DCZQM { get; set; }
        /// <summary>
        /// 调查时间开始
        /// </summary>
        [Display(Name = "调查时间开始")]
        public virtual DateTime? DCSJKS { get; set; }
        /// <summary>
        /// 调查时间结束
        /// </summary>
        [Display(Name = "调查时间结束")]
        public virtual DateTime? DCSJJS { get; set; }

        /// <summary>
        ///人员ID
        /// </summary>
        [Display(Name = "人员ID")]
        [StringLength(20)]
        public virtual string XZRYID { get; set; }
        /// <summary>
        ///人员名称
        /// </summary>
        [Display(Name = "人员名称")]
        [StringLength(50)]
        public virtual string XZRYMC { get; set; }
        /// <summary>
        ///新增日期
        /// </summary>
        [Display(Name = "新增日期")] 
        public virtual DateTime? XZRQ { get; set; }
        /// <summary>
        ///组织机构ID
        /// </summary>
        [Display(Name = "组织机构ID")]
        [StringLength(20)]
        public virtual string ORGANID { get; set; }
         
    }

}
