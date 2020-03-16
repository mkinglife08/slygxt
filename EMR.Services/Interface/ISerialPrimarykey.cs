/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：ISerialPrimaryKey.cs
// 文件功能描述： 自增主键接口，用于定义需要获取自增主键的服务接口。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Services.Interface
{
    /// <summary>
    /// 自增主键接口
    /// </summary>
    public interface ISerialPrimaryKey
    {
        /// <summary>
        /// 获取自增主键
        /// </summary>
        /// <param name="OrganId">组织机构ID</param>
        /// <returns>主键ID</returns>
        string GetPrimaryId(string OrganId = "0");
    }
}
