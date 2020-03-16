/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：DataExtend.cs
// 文件功能描述： 数据层扩展方法类，帮助数据层向外提供一些实体相关的操作方法，比如：保存、更新、删除实体等操作。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Data
{
    public static class DataExtend
    {
        /// <summary>
        /// 保存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="AutoId">自增ID字段</param>
        /// <returns></returns>
        public static int SaveModelM<T>(this T t, string AutoId = "id") where T : class
        {
            return EntityOperate<T>.AddEntity(t, AutoId);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="AutoId">主键名称</param>
        /// <returns></returns>
        public static T UpdateM<T>(this T t, string AutoId = "id") where T : class
        {
            return EntityOperate<T>.UpdateEntity(t, AutoId);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="strPrimaryKeyValue">主键值</param>
        /// <param name="strPrimaryKeyName">主键名</param>
        public static void DeleteM<T>(this T t, string strPrimaryKeyValue, string strPrimaryKeyName = "id") where T : class
        {
            EntityOperate<T>.DeleteById(strPrimaryKeyValue, strPrimaryKeyName);
        }
    }
}
