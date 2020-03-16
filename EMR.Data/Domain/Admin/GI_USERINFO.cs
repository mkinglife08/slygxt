// File:    GI_USERINFO.cs
// Author:  Administrator
// Created: 2018年10月24日 15:28:29
// Purpose: Definition of Class GI_USERINFO

using System;
using System.Collections.Generic;

namespace EMR.Data.Models
{
    /// GI_USERINFO  系统用户人员
    public partial class GI_UserInfo
    {
        public string IsSuperName { get; set; }

        public string IsOnlineName { get; set; }
        /// <summary>
        /// 作废判别名称0正常1作废
        /// </summary>
        public string IsCanceName { get; set; }
        /// <summary>
        /// 用户科室
        /// </summary>
        public string DpetName { get; set; }
        /// <summary>
        /// 用户病区
        /// </summary>
        public string InpatientName { get; set; }
        /// <summary>
        /// 用户医疗组
        /// </summary>
        public string MedicalName { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 职务级别名称
        /// </summary>
        public string JobLevelName { get; set; }
        /// <summary>
        /// 用户职称
        /// </summary>
        public string UserPositionName { get; set; }
        /// <summary>
        /// 所属科室组
        /// </summary>
        public List<AI_DeptInfo> DpetList { get; set; }
        /// <summary>
        /// 所属病区组
        /// </summary>
        public List<AI_DeptInfo> InpatientList { get; set; }
        /// <summary>
        /// 医疗用户组
        /// </summary>
        public List<AI_DoctorGroup> MedicalList { get; set; }

    }
}