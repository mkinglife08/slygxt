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
using System.Web.Script.Serialization;

namespace EMR.Web.Controllers.Doctor
{
    public class ProgressTemplateController : BaseController
    {
        private StructuredTemplateService StructuredTemplateService = new StructuredTemplateService();

        /// <summary>
        /// 保存模板信息
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("保存模板信息", () =>
            {
                AI_StructuredTemplate entity = GetPageData<AI_StructuredTemplate>(0);
                if (!string.IsNullOrWhiteSpace( Request["SecondType"]))
                {
                    AI_StructuredTemplate entity1 = GetPageData<AI_StructuredTemplate>(0);
                    entity1.ParentTempId = "0";
                    entity1.TemplateName = Request["SecondType"];
                    entity1.IsCategory = 1;
                    entity.ParentTempId = StructuredTemplateService.SaveInfo(entity1);
                }
                List<ProgressNote_Content_Item> itemList = new List<ProgressNote_Content_Item>();
                int curIndex = 0;
                foreach (string each in Request["RecordContentTitle"].Split(','))
                {
                    itemList.Add(new ProgressNote_Content_Item() { Title = each, Content = Request["RecordContent" + curIndex] });
                    curIndex++;
                }
                entity.TemplateContent = new JavaScriptSerializer().Serialize(itemList);
                StructuredTemplateService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取模板列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<AI_StructuredTemplate> list = StructuredTemplateService.GetAll(filter);
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取模板信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取模板信息", () =>
            {
                AI_StructuredTemplate entity = EntityOperate<AI_StructuredTemplate>.GetEntityById(Request["TemplateId"], "TemplateId");
                return new WebApi_Result() { data = entity };
            });
        }
    }
}