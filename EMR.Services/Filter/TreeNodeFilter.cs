/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：TreeNodeFilter.cs
// 文件功能描述： 树节点数据检索器。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data.CustomAttribute;
using System;

namespace EMR.Services.Filter
{
    public class TreeNodeFilter : CommonFilter
    {
        private string _ParentID;

        [Filter(Filter_Type.equal)]
        public string ParentID
        {
            //get { return _ParentID == "0" ? "" : _ParentID; }
            get { return _ParentID; }
            set { _ParentID = value; }
        }
    }
}
