/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：StructuredTemplateController.cs
// 文件功能描述： 体格检查控制层
// 创建标识：朱天伟 2019-02-19
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Doctor
{
    public class HospitalPhysicalRxamController : BaseController
    {
        private HospitalPhysicalRxamService service = new HospitalPhysicalRxamService();

        #region 增删改查
        /// <summary>
        /// 根据住院病人id获得体格检查
        /// </summary>
        /// <returns></returns>
        public string GetInfoByInpatientId()
        {
            return base.ExecuteActionJsonResult("获取入院记录信息", () =>
            {
                CD_HospitalPhysicalRxam info = service.GetInfoByInpatientId(Request["InpatientId"]);
                return new WebApi_Result() { data = info };
            });
        }


        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                CD_HospitalPhysicalRxam info = base.GetPageData<CD_HospitalPhysicalRxam>(0);
                info.PhysicalExamId = string.IsNullOrWhiteSpace(info.PhysicalExamId) ? null : info.PhysicalExamId;
                service.SaveInfo(info);
                return new WebApi_Result();
            });
        }

        #endregion
    }
}