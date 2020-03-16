/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CacheTypeAttribute.cs
// 文件功能描述： 缓存属性设置[Redis/MemoryCache]（只能设置一种缓存，且只对实体有效）
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data.CustomeAttribute
{
    /// <summary>
    /// 缓存属性设置（只能设置一种缓存，且只对实体有效）
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited =false)]
    public class CacheTypeAttribute : Attribute
    {
        public CacheTypeAttribute(CacheTypeEnum _cacheType)
        {
            cacheType = _cacheType;
        }

        public CacheTypeEnum cacheType { get; set; }
    }

    public enum CacheTypeEnum
    {
        /// <summary>
        /// Redis缓存
        /// </summary>
        Redis = 0,

        /// <summary>
        /// MemoryCache缓存
        /// </summary>
        MemoryCache = 1,
    }
}
