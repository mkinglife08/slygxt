/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：MedicalRecordAccessRecordService.cs
// 文件功能描述： 病历查阅记录实体层补充，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病案首页相关数据的服务，一般返回与病案首页相关的实体或实体集合。
// 创建标识：朱天伟 2019年4月16日
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data.CustomAttribute;
using System;
using System.Collections.Generic;

namespace EMR.Data.Models
{
    public partial class CD_MedicalRecordAccessRecord
    {
        /// <summary>
        /// 申请医生姓名
        /// </summary>
        [FieldType(FieldTypeEnum.Ignore)]
        public string ApplyUserName { get; set; }

        /// <summary>
        /// layui的选中标记，千万不要改大小写！！！不要做任何修改！
        /// </summary>
        public bool? LAY_CHECKED { get; set; }
    }
}
