using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Infection;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using EMR.Web.Extension;

namespace EMR.Web.Controllers.Infection
{
    public class CommonHelperController : BaseController
    {
        private class SelectModel {
            public string text { get; set; }
            public string value { get; set; }
        }
        /// <summary>
        /// 获取多重耐药页面所需的下拉框
        /// </summary>
        /// <returns></returns>
        public string GetDrugResistQuarSelect()
        {
            var selType = Request["selType"];
            List<SelectModel> list = new List<SelectModel>();
            if (selType =="A")
            {
                list.Add(new SelectModel { text = "有", value = "有" });
                list.Add(new SelectModel { text = "无", value = "无" });
            }
            else if (selType == "B")
            {
                list.Add(new SelectModel { text = "是", value = "是" });
                list.Add(new SelectModel { text = "否", value = "否" });
            } 
            else if (selType == "C")
            {
                list.Add(new SelectModel { text = "是", value = "是" });
                list.Add(new SelectModel { text = "否", value = "否" });
                list.Add(new SelectModel { text = "暂无", value = "暂无" });
            }

            return base.ExecuteActionJsonResult("多重耐药页面获取下拉框", () =>
            {
                return new WebApi_Result() { data = list };
            });
        }

        /// <summary>
        /// 获取卫生检测，申请单分类
        /// </summary>
        /// <returns></returns>
        public string GetEnvSelect()
        { 
            List<SelectModel> list = new List<SelectModel>();
             
                list.Add(new SelectModel { text = "空气培养", value = "空气培养" });
                list.Add(new SelectModel { text = "物表监测", value = "物表监测" });
                list.Add(new SelectModel { text = "医护人员手细菌", value = "医护人员手细菌" }); 

            return base.ExecuteActionJsonResult("环境检测申请单分类", () =>
            {
                return new WebApi_Result() { data = list };
            });
        }

        /// <summary>
        /// 手卫生依从性调查表,获取职业下拉列表
        /// </summary>
        /// <returns></returns>
        public string GetHandHygieneSelect()
        {
            List<SelectModel> list = new List<SelectModel>(); 
            list.Add(new SelectModel { text = "医生", value = "医生" });
            list.Add(new SelectModel { text = "护士", value = "护士" });
            list.Add(new SelectModel { text = "医技", value = "医技" });
            list.Add(new SelectModel { text = "工人", value = "工人" });

            return base.ExecuteActionJsonResult("手卫生依从性调查分类", () =>
            {
                return new WebApi_Result() { data = list };
            });
        }
    }
}