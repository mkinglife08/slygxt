using System;

namespace DataModel.CN
{
    /// <summary>
 	/// CN_TemperatureChartExtra 体温单额外
	/// </summary>
    public class CN_TEMPERATURECHARTEXTRA
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
 	    /// 是否卧床
	    /// </summary>
		public decimal? BEDRIDDEN{ get; set; }

        /// <summary>
 	    /// 身高
	    /// </summary>
		public string HEIGHT{ get; set; }

        /// <summary>
 	    /// 体重
	    /// </summary>
		public string WEIGHT{ get; set; }

        /// <summary>
 	    /// 时间阶段代码
	    /// </summary>
		public string PERIODCODE{ get; set; }

        /// <summary>
 	    /// 时间阶段
	    /// </summary>
		public string PERIOD{ get; set; }

        /// <summary>
 	    /// 入量时间间隔
	    /// </summary>
		public string INTAKEHOUR{ get; set; }

        /// <summary>
 	    /// 入量
	    /// </summary>
		public string INTAKE{ get; set; }

        /// <summary>
 	    /// 出量时间间隔
	    /// </summary>
		public string OUTPUTHOUR{ get; set; }

        /// <summary>
 	    /// 出量
	    /// </summary>
		public string OUTPUT{ get; set; }

        /// <summary>
 	    /// 尿量时间间隔
	    /// </summary>
		public string UPDOUR{ get; set; }

        /// <summary>
 	    /// 尿量
	    /// </summary>
		public string UPD{ get; set; }

        /// <summary>
 	    /// 排便方式代码
	    /// </summary>
		public string STOOLTYPECODE{ get; set; }

        /// <summary>
 	    /// 排便方式
	    /// </summary>
		public string STOOLTYPE{ get; set; }

        /// <summary>
 	    /// 大便次数
	    /// </summary>
		public string STOOLTREQ{ get; set; }

        /// <summary>
 	    /// 灌肠后大便次数
	    /// </summary>
		public string STOOLFREQAFTER{ get; set; }

        /// <summary>
 	    /// 胆汁颜色
	    /// </summary>
		public string BILECOLOR{ get; set; }

        /// <summary>
 	    /// 胆汁
	    /// </summary>
		public string BILE{ get; set; }

        /// <summary>
 	    /// 鼻饲
	    /// </summary>
		public string NASALFEEDING{ get; set; }

        /// <summary>
 	    /// 胃液
	    /// </summary>
		public string SUCCUSGASTRICUS{ get; set; }

        /// <summary>
 	    /// 口入
	    /// </summary>
		public string ORALROUTE{ get; set; }

        /// <summary>
 	    /// 腹围
	    /// </summary>
		public string ABDOMEN{ get; set; }

        /// <summary>
 	    /// 引流量
	    /// </summary>
		public string DRAINAGE{ get; set; }

        /// <summary>
 	    /// 自定义项1的值
	    /// </summary>
		public string CUSTOMITME1{ get; set; }

        /// <summary>
 	    /// 自定义项2的值
	    /// </summary>
		public string CUSTOMITME2{ get; set; }

        /// <summary>
 	    /// 自定义项3的值
	    /// </summary>
		public string CUSTOMITME3{ get; set; }

        /// <summary>
 	    /// 自定义项4的值
	    /// </summary>
		public string CUSTOMITME4{ get; set; }

        /// <summary>
 	    /// 自定义项5的值
	    /// </summary>
		public string CUSTOMITME5{ get; set; }

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