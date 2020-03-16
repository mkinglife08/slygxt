/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：TreeEntityForLayui.cs
// 文件功能描述： 树结构实体，为前端UI提供特定参数的树结构实体。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;

namespace EMR.Data.Models
{
    public class TreeEntityForLayui
    {
        public string name { get; set; }
        public string id { get; set; }
        public string pid { get; set; }
        public string t { get; set; }
        public bool open { get; set; }

        public bool @checked { get; set; }

        public string remark { get; set; }

        public List<TreeEntityForLayui> children { get; set; }
    }

    public class ProgressNoteRecordContent
    {
        public string ProgressType { get; set; }
        public string ProgressTypeName { get; set; }

        public List<ProgressNoteRecordContentItem> ItemList { get; set; }
    }

    public class ProgressNoteRecordContentItem
    {
        public string RecordName { get; set; }

        public string RecordContent { get; set; }
    }
}
