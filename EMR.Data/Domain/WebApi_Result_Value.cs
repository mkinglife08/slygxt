/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：WebApi_Result.cs
// 文件功能描述： 返回给前端的数据结构实体类，为前端UI返回特定参数的数据结构实体。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System.ComponentModel.DataAnnotations;

namespace EMR.Data.Models
{
    public class WebApi_Result
    {
        /// <summary>
        /// 返回代码，1获取数据失败，0成功，13token失效
        /// </summary>
        public int? code { get; set; }
        public object msg { get; set; }
        public int count { get; set; }
        public object data { get; set; }
    }   
}
