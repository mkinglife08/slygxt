// File:    GI_CODEDICT.cs
// Author:  Administrator
// Created: 2018年10月24日 15:28:29
// Purpose: Definition of Class GI_CODEDICT

using System;

namespace EMR.Data.Models
{
    /// <summary>
    /// - V_FUNINFO 实体类
    /// </summary>
    public partial class V_FunInfo
    {
        /// <summary>
        ///  组织机构
        /// </summary>
        public string OrganName { get; set; }
        /// <summary>
        ///  系统模块
        /// </summary>
        public string SYSName { get; set; }
        /// <summary>
        ///  功能序号
        /// </summary>
        public string FUNID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string OrganID { get; set; }
        /// <summary>
        ///  父类序号
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string SYSID { get; set; }
        /// <summary>
        ///  功能名称
        /// </summary>
        public string FUNName { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? IsLast { get; set; }
        /// <summary>
        ///  功能页面
        /// </summary>
        public string FUNPage { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? IsShow { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string FunNtoe { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string FUNIcon { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string CheckIcon { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string SpellCode { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string CustomCode { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public string ModifyUserCode { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? FUNLevel { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? DisplaySort { get; set; }
        /// <summary>
        ///  
        /// </summary>
        public int? IsCance { get; set; }
        /// <summary>
        ///  父类名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 标识列名
        /// </summary>
        public string Myidentity { get; set; }

        public string IsLastName { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public string IsShowName { get; set; }
    }
}