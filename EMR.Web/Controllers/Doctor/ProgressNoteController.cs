using EMR.Data;
using EMR.Data.Models;
using EMR.Services;
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
    public class ProgressNoteController : BaseController
    {
        private ProgressNoteService progressNoteService = new ProgressNoteService();
        private StructuredTemplateService StructuredTemplateService = new StructuredTemplateService();

        #region 增删改查
        /// <summary>
        /// 保存病程记录
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("保存" + Request["ProgressTypeName"] + "信息", () =>
            {
                CD_ProgressNote entity = GetPageData<CD_ProgressNote>(0);
                List<ProgressNote_Content_Item> itemList = new List<ProgressNote_Content_Item>();
                int curIndex = 0;
                foreach (string each in Request["RecordContentTitle"].Split(','))
                {
                    itemList.Add(new ProgressNote_Content_Item() { Title = each, Content = Request["RecordContent" + curIndex] });
                    curIndex++;
                }
                entity.WardRoundUserId = string.IsNullOrWhiteSpace(entity.WardRoundUserId) ? UserTokenManager.GetUId(Request["token"]) : entity.WardRoundUserId;
                entity.RecordContent = new JavaScriptSerializer().Serialize(itemList);
                progressNoteService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 获取病程记录列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取病程记录列表", () =>
            {
                ProgressNoteFilter filter = GetPageData<ProgressNoteFilter>(0);
                List<CD_ProgressNote> list = progressNoteService.GetAll(filter);
                list.ForEach(e =>
                {
                    e.ProgressTypeName = CommonService.GetDictNameByID("824", e.ProgressTypeId + "");
                    GI_UserInfo Creator = EntityOperate<GI_UserInfo>.GetEntityById(e.Creator, "USERID");
                    e.CreatorName = Creator?.UserName;//创建人姓名
                    e.CreatorESign = Creator?.ESign;//创建人电子签名

                });
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取病程记录信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取病程记录信息", () =>
            {
                CD_ProgressNote entity = EntityOperate<CD_ProgressNote>.GetEntityById(Request["ProgressNoteId"], "ProgressNoteId");
                entity.WardRoundUserName = EntityOperate<GI_UserInfo>.GetEntityById(entity.WardRoundUserId, "USERID").UserName;
                entity.ProgressTypeName = CommonService.GetDictNameByID("824", entity.ProgressTypeId + "");
                entity.CreatorName = EntityOperate<GI_UserInfo>.GetEntityById(entity.Creator, "USERID").UserName;
                return new WebApi_Result() { data = entity };
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除病程记录信息", () =>
            {
                EntityOperate<CD_ProgressNote>.DeleteById(Request["ProgressNoteId"], "ProgressNoteId");
                return new WebApi_Result() { };
            });
        }
        #endregion

        /// <summary>
        /// 保存模板信息
        /// </summary>
        /// <returns></returns>
        public string SaveTemplate()
        {
            return base.ExecuteActionJsonResult("保存模板信息", () =>
            {
                AI_StructuredTemplate entity = GetPageData<AI_StructuredTemplate>(0);
                if (!string.IsNullOrWhiteSpace(Request["SecondType"]))
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

        public string CreateRecordContentXML()
        {
            return base.ExecuteActionJsonResult("生成病程记录XML", () =>
            {
                List<ProgressNoteRecordContent> contentList = new List<ProgressNoteRecordContent>();
                List<ProgressNoteRecordContentItem> itemList = new List<ProgressNoteRecordContentItem>();
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "病例特点", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "中医辩病辩证依据", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "中医鉴别诊断", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "西医诊断依据", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "西医鉴别诊断", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "初步诊断中医", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "初步诊断西医", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "诊疗计划", RecordContent = "" });
                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "50",
                    ProgressTypeName = "中医首次病程记录",
                    ItemList = itemList
                });

                itemList.Clear();
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "病例特点", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "判断依据", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "鉴别诊断", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "初步诊断", RecordContent = "" });
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "诊疗计划", RecordContent = "" });
                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "50",
                    ProgressTypeName = "西医首次病程记录",
                    ItemList = itemList
                });

                itemList.Clear();
                itemList.Add(new ProgressNoteRecordContentItem() { RecordName = "病例特点", RecordContent = "" });
                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "1",
                    ProgressTypeName = "主治医师查房",
                    ItemList = itemList
                });

                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "21",
                    ProgressTypeName = "主任医师代主治医师查房",
                    ItemList = itemList
                });

                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "24",
                    ProgressTypeName = "副主任医师代主治医师查房",
                    ItemList = itemList
                });

                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "18",
                    ProgressTypeName = "主任医师查房",
                    ItemList = itemList
                });

                contentList.Add(new ProgressNoteRecordContent()
                {
                    ProgressType = "19",
                    ProgressTypeName = "副主任医师查房",
                    ItemList = itemList
                });
                XmlSerializer.SaveToXml<List<ProgressNoteRecordContent>>(Request.MapPath("~/Content/EMRConfig/ProgressNote.xml"), contentList);
                return new WebApi_Result();
            });
        }
    }
}