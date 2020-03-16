// File:    GI_ROLE.cs
// Author:  Administrator
// Created: 2018年10月24日 15:28:29
// Purpose: Definition of Class GI_ROLE

using System;

namespace EMR.Data.Models
{
    /// GI_ROLE  系统用户分组
    public partial class GI_Role
    {
        public string PowerName { get; set; }

        /// <summary>
        /// layui的选中标记，千万不要改大小写！！！不要做任何修改！
        /// </summary>
        public bool? LAY_CHECKED { get; set; }
        /// <summary>
        /// 是否作废判别0正常1作废 
        /// </summary>
        public int? IsCance { get; set; }

    }
}