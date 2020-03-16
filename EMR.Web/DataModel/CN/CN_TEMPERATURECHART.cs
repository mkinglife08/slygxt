using System;

namespace DataModel.CN
{
    /// <summary>
 	/// CN_TemperatureChart 体温单
	/// </summary>
    public class CN_TEMPERATURECHART
    {

        /// <summary>
 	    /// (索引)(主键)体温单id
	    /// </summary>
		public string CHARTID{ get; set; }

        /// <summary>
 	    /// 机构序号
	    /// </summary>
		public string ORGANID{ get; set; }

        /// <summary>
 	    /// 住院id
	    /// </summary>
		public string INPATIENTID{ get; set; }

        /// <summary>
 	    /// 科室id
	    /// </summary>
		public string DEPARTMENTID{ get; set; }

        /// <summary>
 	    /// 病区id
	    /// </summary>
		public string WARDID{ get; set; }

        /// <summary>
 	    /// 床号
	    /// </summary>
		public string BEDNUM{ get; set; }

        /// <summary>
 	    /// 测量时间
	    /// </summary>
		public DateTime? MEASURETIME{ get; set; }

        /// <summary>
 	    /// 体温类型代码
	    /// </summary>
		public string TYPECODE{ get; set; }

        /// <summary>
 	    /// 体温类型
	    /// </summary>
		public string TYPE{ get; set; }

        /// <summary>
 	    /// 出生记录id
	    /// </summary>
		public string BIRTHRECORDID{ get; set; }

        /// <summary>
 	    /// 体温
	    /// </summary>
		public string DEGREE{ get; set; }

        /// <summary>
 	    /// 脉搏
	    /// </summary>
		public string PULSE{ get; set; }

        /// <summary>
 	    /// 心率
	    /// </summary>
		public string HEARTRATE{ get; set; }

        /// <summary>
 	    /// 呼吸
	    /// </summary>
		public string BREATH{ get; set; }

        /// <summary>
 	    /// 舒张压
	    /// </summary>
		public string DIASTOLICPRESSURE{ get; set; }

        /// <summary>
 	    /// 收缩压
	    /// </summary>
		public string SYSTOLICPRESSURE{ get; set; }

        /// <summary>
 	    /// 氧饱和度
	    /// </summary>
		public string SPO{ get; set; }

        /// <summary>
 	    /// 病人事件代码
	    /// </summary>
		public string EVENTCODE{ get; set; }

        /// <summary>
 	    /// 病人事件
	    /// </summary>
		public string EVENT{ get; set; }

        /// <summary>
 	    /// 事件时间
	    /// </summary>
		public DateTime? EVENTTIME{ get; set; }

        /// <summary>
 	    /// 测理类型0常规1测量后半小时
	    /// </summary>
		public decimal? TESTTYPE{ get; set; }

        /// <summary>
 	    /// 疼痛评分id
	    /// </summary>
		public string PAINSCOREID{ get; set; }

        /// <summary>
 	    /// 疼痛评分
	    /// </summary>
		public string PAINSCORE{ get; set; }

        /// <summary>
 	    /// 新生儿体重
	    /// </summary>
		public string NEONATEWEIGHT{ get; set; }

        /// <summary>
 	    /// 箱温
	    /// </summary>
		public string BOXTEMP{ get; set; }

        /// <summary>
 	    /// 兰光箱
	    /// </summary>
		public string RAYBOX{ get; set; }

        /// <summary>
 	    /// 保温箱
	    /// </summary>
		public string INCUBATOR{ get; set; }

        /// <summary>
 	    /// TCB
	    /// </summary>
		public string TCB{ get; set; }

        /// <summary>
 	    /// 作废标志
	    /// </summary>
		public decimal? DEL{ get; set; }

        /// <summary>
 	    /// 创建时间
	    /// </summary>
		public DateTime? CREATETIME{ get; set; }

        /// <summary>
 	    /// 创建人
	    /// </summary>
		public string CREATOR{ get; set; }

        /// <summary>
 	    /// 创建人姓名
	    /// </summary>
		public string CREATORNAME{ get; set; }

        /// <summary>
 	    /// 更新时间
	    /// </summary>
		public DateTime? UPDATERTIME{ get; set; }

        /// <summary>
 	    /// 更新人
	    /// </summary>
		public string UPDATER{ get; set; }
      
    }
}