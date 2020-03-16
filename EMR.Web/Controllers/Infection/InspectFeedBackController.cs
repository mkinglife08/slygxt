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
    /// <summary>
    /// 感染督察反馈单
    /// </summary>
    public class InspectFeedBackController : BaseController
    {
        private FeedBackService feedBackService = new FeedBackService();

        public string GetAllFkd()
        {
            return base.ExecuteActionJsonResult("获取感染反馈单列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_YGDCFKD> list = feedBackService.GetAllFkd(filter).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
                    //return new WebApi_Result() { data = list, count = list.Count };
                });
        }


        public string GetAllFkdSource(string FKDID)
        {
            return base.ExecuteActionJsonResult("获取感染反馈数据列表", () =>
            {
                CommonFilter filter = GetPageData<CommonFilter>(0);
                List<BUS_YGDCFKD_SOURCE> list = feedBackService.GetAllFkdSource(filter, FKDID).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0, limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
                //return new WebApi_Result() { data = list, count = list.Count };
            });
        }


        public string GetFkdSourceModel(string fkdSourceId)
        {
            CommonFilter filter = GetPageData<CommonFilter>(0);
            var fkdSource = feedBackService.GetFkdSourceModel(filter, fkdSourceId); 
            return base.ExecuteActionJsonResult("获取单条反馈单数据", () =>
            {
                return new WebApi_Result()
                {
                    data = fkdSource
                };
            });
        }

        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string Save(BUS_YGDCFKD fkdModel, BUS_YGDCFKD_SOURCE fkdSourceModel)
        { 
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                var userToken = Request["token"].GetUserToken();
                //完善反馈单信息
                if (string.IsNullOrWhiteSpace(fkdModel.FKDID))
                {
                    fkdModel.XZRYID = userToken.UserId;
                    fkdModel.XZRYMC = userToken.USERNAME;
                    fkdModel.XZRQ = DateTime.Now;
                    fkdModel.ORGANID = userToken.ORGANID;
                } 
                //完善反馈单数据信息 
                if (string.IsNullOrWhiteSpace(fkdSourceModel.FKDSOURCEID))
                {
                    fkdSourceModel.XZRYID = userToken.UserId;
                    fkdSourceModel.XZRYMC = userToken.USERNAME;
                    //fkdSourceModel.DEPTID = userToken.DpetID;
                    //fkdSourceModel.DEPTNAME = "没给登录人所在部门名";
                    fkdSourceModel.XZRQ = DateTime.Now;
                    fkdSourceModel.ORGANID = userToken.ORGANID;
                }

                feedBackService.Save(fkdModel, fkdSourceModel);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 点击缩略图查看大图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ShowPhotos(string FKDSOURCEID)
        {

           
            //            {
            //                "title": "", //相册标题
            //  "id": 123, //相册id
            //  "start": 0, //初始显示的图片序号，默认0
            //  "data": [   //相册包含的图片，数组格式
            //    {
            //      "alt": "图片名",
            //      "pid": 666, //图片id
            //      "src": "", //原图地址
            //      "thumb": "" //缩略图地址
            //    }
            //  ]
            //}
            return base.ExecuteActionJsonResult("查看单个图片", () =>
            {
                var model = feedBackService.GetFkdSourceByID(FKDSOURCEID);
                List<BUS_YGDCFKD_SOURCE> list = new List<BUS_YGDCFKD_SOURCE>();

                var siteUrl = System.Configuration.ConfigurationManager.AppSettings["SiteUrl"].ToString();  //网站根目录

                if (model != null &&  !string.IsNullOrWhiteSpace(model.XCZP))
                {
                    list.Add(model);
                    var resultPhotos = new
                    {
                        title = "mypage",
                        id = 123,
                        start = 0,
                        data = list.Select(p => new {
                            alt = "alt",
                            pid = 666,
                            src = siteUrl + p.XCZP,
                            tumb = siteUrl + p.XCZP
                        })
                    };
                    return new WebApi_Result() { data = resultPhotos };
                }
                return new WebApi_Result() { data = "" };
            });
             
        }

        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<BUS_YGDCFKD>.DeleteById(Request["FKDID"], "FKDID");
                EntityOperate<BUS_YGDCFKD_SOURCE>.DeleteById(Request["FKDID"], "FKDID");
                return new WebApi_Result() { };
            });
        }


    }
}