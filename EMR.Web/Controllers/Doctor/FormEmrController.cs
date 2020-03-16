using EMR.Data;
using EMR.Data.Models;
using EMR.Services;
using EMR.Services.Filter;
using EMR.Services.Server.Doctor;
using EMR.Services.Server.Public;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EMR.Web.Controllers.Doctor
{
    public class FormEmrController : BaseController
    {
        private FormEmrService formEmrService = new FormEmrService();
        private FormEmrTemplateService formEmrTemplateService = new FormEmrTemplateService();

        #region 增删改查
        /// <summary>
        /// 保存表单病历
        /// </summary>
        /// <returns></returns>
        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                CD_FormEmr entity = GetPageData<CD_FormEmr>(0);
                formEmrService.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 获取表单病历列表
        /// </summary>
        /// <returns></returns>
        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取表单病历列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<CD_FormEmr> list = formEmrService.GetAll(filter);
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        /// <summary>
        /// 获取表单病历信息
        /// </summary>
        /// <returns></returns>
        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取表单病历信息", () =>
            {
                V_FormEmr entity = EntityOperate<V_FormEmr>.GetEntityById(Request["FormEmrId"], "FormEmrId");
                return new WebApi_Result() { data = entity };
            });
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除表单病历信息", () =>
            {
                EntityOperate<CD_FormEmr>.DeleteById(Request["FormEmrId"], "FormEmrId");
                return new WebApi_Result() { };
            });
        }
        #endregion

        #region 树结构方法


        /// <summary>
        /// 获取所有树节点，用于一次性加载全部节点
        /// </summary>
        /// <returns></returns>
        public string GetTreeNode()
        {
            return base.ExecuteActionJsonResult("获取结构化模板树结构", () =>
            {
                int TemplateType = 0;
                if (!int.TryParse(Request["TemplateType"], out TemplateType)) { TemplateType = 10; }//如果没有IsCategory参数的话，默认显示全部
                List<V_FormEmrTemplate> list = EntityOperate<V_FormEmrTemplate>.GetEntityList("TemplateType="+ TemplateType).Where(f => f.Del != 1).OrderBy(f => f.TemplateId).ToList();
                List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
                //returnValue.Add(new TreeEntityForLayui() { name = "可用同意书", id = "0", pid = "", open = true, children = service.CreateTreeNode(list, "0") });
                List<TreeEntityForLayui> secChild = new List<TreeEntityForLayui>();
                secChild.Add(new TreeEntityForLayui() { name = "已签同意书", id = "Signed", pid = "all", open = true, children = formEmrService.GetSingleTreeNode("Signed",Request["InpatientId"], TemplateType) });
                secChild.Add(new TreeEntityForLayui() { name = "可用同意书", id = "CanUse", pid = "all", open = true, children = formEmrTemplateService.CreateTreeNode(list, "0") });
                returnValue.Add(new TreeEntityForLayui() { name = "同意书", id = "all", pid = "", open = true, children = secChild });
                return new WebApi_Result() { data = returnValue, count = list.Count };
            });
        }


        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <returns></returns>
        public string GetSingleTreeNode()
        {
            List<TreeEntityForLayui> returnValue = new List<TreeEntityForLayui>();
            int TemplateType = 0;
            if (!int.TryParse(Request["TemplateType"], out TemplateType)) { TemplateType = 10; }
            if (!string.IsNullOrEmpty(Request["ParentId"]))
            {
                returnValue = formEmrService.GetSingleTreeNode(Request["ParentId"], Request["InpatientId"], TemplateType);
            }
            return new JavaScriptSerializer().Serialize(returnValue);
        }

        #endregion
    }
}