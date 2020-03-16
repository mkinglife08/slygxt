using EMR.Data;
using EMR.Data.Models;
using EMR.Web.Extension.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace EMR.Web.Controllers.SystemSupport
{
    
    public class SysAppParamController : BaseController
    {
        public List<GI_SYSAPPParam> GetUserList()
        {
            List<GI_SYSAPPParam> _list = new List<GI_SYSAPPParam>();
            return _list;
        }

        public string SaveInfo()
        {
            return base.ExecuteActionJsonResult("系统业务参数信息保存", () =>
            {
                GI_SYSAPPParam entity = base.GetPageData<GI_SYSAPPParam>(0);
                if (!string.IsNullOrWhiteSpace(entity.ParamID) && entity.ParamID != "null")
                {
                    entity.UpdateM("PARAMID");
                }
                else
                {
                    entity.ParamID = DateTime.Now.ToFileTime().ToString();
                    entity.SaveModelM();
                }
                return new WebApi_Result();
            });
        }

        public string GetAll()
        {
            return base.ExecuteActionJsonResult("获取系统业务参数信息列表", () =>
            {
                List<GI_SYSAPPParam> list = EntityOperate<GI_SYSAPPParam>.GetEntityListBySQL("select * from GI_SYSAPPPARAM");
                int curpage = 0,limit = 3;
                int.TryParse(Request["page"], out curpage);
                int.TryParse(Request["limit"], out limit);
                var myskip = curpage>0?limit * (curpage - 1):0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit),count =list.Count };
            });
        }

        public string GetInfoById()
        {
            return base.ExecuteActionJsonResult("获取系统业务参数信息", () =>
            {
                GI_SYSAPPParam list = EntityOperate<GI_SYSAPPParam>.GetEntityBySQL("select * from GI_SYSAPPPARAM where PARAMID = '" + Request["ParamID"] +"'");
                return new WebApi_Result() { data = list };
            });
        }

        public string Delete() {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                //List<GI_SYSAPPPARAM> list = EntityOperate<GI_SYSAPPPARAM>.GetEntityListBySQL("delete from GI_SYSAPPPARAM where PARAMID = '" + Request["PARAMID"] + "'");
                return new WebApi_Result() {  };
            });
        }
    }
}
