/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：HospitalRecordController.cs
// 文件功能描述： 入院记录控制层
// 创建标识：朱天伟 2019-01-07
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Web.Controllers.Page;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Doctor
{
    public class HospitalRecordController : BaseController
    {
        private HospitalRecordService service = new HospitalRecordService();

        #region 增删改查
        /// <summary>
        /// 根据住院病人id获得入院记录
        /// </summary>
        /// <returns></returns>
        public string GetInfoByInpatientId()
        {
            return base.ExecuteActionJsonResult("获取入院记录信息", () =>
            {
                CD_HospitalRecord info = service.GetInfoByInpatientId(Request["InpatientId"]);
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
                CD_HospitalRecord info = base.GetPageData<CD_HospitalRecord>(0);
                info.HospitalRecordId = string.IsNullOrWhiteSpace(info.HospitalRecordId) ? null : info.HospitalRecordId;
                service.SaveInfo(info);
                string infomsg = info.RecordState == 0 ? "暂存信息成功" : "保存信息成功";
                return new WebApi_Result() { msg = infomsg };
            });
        }

        /// <summary>
        /// 删除病历
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<CD_HospitalRecord>.DeleteById(Request["InpatientId"], "InpatientId");
                return new WebApi_Result();
            });
        }


        /// <summary>
        /// 保存记录类型并跳转
        /// </summary>
        /// <returns></returns>
        public ActionResult AddHospitalRecord()
        {

            CD_HospitalRecord info = base.GetPageData<CD_HospitalRecord>(0);
            info.InpatientId = Request["InpatientId"];
            int rtype = 0;
            int.TryParse(Request["RecordType"], out rtype);
            info.RecordType = rtype;
                service.SaveInfo(info);
            return Redirect("/page/DoctorPages/HospitalRecordEdit");
        }

        #endregion




    }
}