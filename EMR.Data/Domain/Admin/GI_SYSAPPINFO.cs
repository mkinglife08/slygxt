// File:    GI_USERINFO.cs
// Author:  Administrator
// Created: 2018年10月24日 15:28:29
// Purpose: Definition of Class GI_USERINFO

using System;

namespace EMR.Data.Models
{
    /// GI_USERINFO  系统用户人员
    public partial class GI_SYSAPPINFO
    {
        /// 是否作废判别0正常1作废
        public string IsCanceName { get; set; }

        /// <summary>
        /// layui的选中标记，千万不要改大小写！！！不要做任何修改！
        /// </summary>
        public bool? LAY_CHECKED { get; set; }

    }
}