
using EMR.Data.CustomAttribute;
using System;

namespace EMR.Data.Models
{
    public partial class API_ExamineReport
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public string InpatientId { get; set; }
        /// <summary>
        /// 组序号
        /// </summary>
        public string zxh { get; set; }

        /// <summary>
        /// 组名称
        /// </summary>
        public string zmc { get; set; }

        /// <summary>
        /// 报告时间
        /// </summary>
        public string bgsj { get; set; }

        /// <summary>
        /// 送检时间
        /// </summary>
        public string jysj { get; set; }

        /// <summary>
        /// 标本类型
        /// </summary>
        public string bb { get; set; }

        /// <summary>
        /// 申请医生
        /// </summary>
        public string sqys { get; set; }

    }

    public partial class ExamineReport_Item
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// 检查结果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 参考范围
        /// </summary>
        public string ReferenceRange { get; set; }
    }

    public partial class API_DataGet_Config
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// HIS编号
        /// </summary>
        public string HisCode { get; set; }

        public DataProviderEnum DataProvider { get; set; }

        /// <summary>
        /// 外部数据库的连接字符串
        /// </summary>
        public string DBConnectionString { get; set; }

        /// <summary>
        /// sql语句
        /// </summary>
        public string Sql { get; set; }
    }

    public enum DataProviderEnum
    {
        sql=1,
        oracle=2
    }

    
}