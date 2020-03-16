/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 科室控制层
// 创建标识：盛贵明 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Server.Public;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using EMR.Web.Extension;

namespace EMR.Web.Controllers.Public
{
    public class UserInfoController : BaseController
    {
        private UserInfoService service = new UserInfoService();
        /// <summary>
        /// 增加和保存数据
        /// </summary>
        /// <returns></returns>
        public string Save()
        {
          
            return base.ExecuteActionJsonResult("保存信息", () =>
            {
                GI_UserInfo entity = base.GetPageData<GI_UserInfo>(0);
                entity.UserID = string.IsNullOrWhiteSpace(entity.UserID) ? null : entity.UserID;
                entity.ModifyTime = DateTime.Now;
                entity.ModifyUserID = Request["token"].GetUserToken().UserId;
                if (!string.IsNullOrWhiteSpace(entity.PassWord))
                {
                    entity.PassWord = EMR.Common.Encrypt.MD5Encrypt(entity.PassWord);
                }
                service.SaveInfo(entity);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return base.ExecuteActionJsonResult("删除信息", () =>
            {
                EntityOperate<GI_UserInfo>.DeleteById(Request["UserID"], "UserID");
                return new WebApi_Result() { };
            });
        }

        /// <summary>
        /// 获取查询列表
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {

            return base.ExecuteActionJsonResult("获取列表", () =>
            {
                TreeNodeFilter treeNodeFilter = GetPageData<TreeNodeFilter>(0);
                List<GI_UserInfo> list = service.GetAll(treeNodeFilter).Where(f => f.IsCance != 1).ToList();
                if (list.Count <= 0)
                {
                    return new WebApi_Result() { code = 1, msg = "未查询到任何数据" };
                }
                int curpage = 0, limit = 30;
                int.TryParse(Request["page"], out curpage);
                limit = int.TryParse(Request["limit"], out limit)? limit : 30;
                var myskip = curpage > 0 ? limit * (curpage - 1) : 0;
                return new WebApi_Result() { data = list.Skip(myskip).Take(limit), count = list.Count };
            });
        }
        
        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            return base.ExecuteActionJsonResult("获取科室信息", () =>
            {
                GI_UserInfo info = service.GetInfoById(Request["userid"]);
                return new WebApi_Result() { data = info };
            });
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public string SavePassWord()
        {
            return base.ExecuteActionJsonResult("修改密码", () =>
            {
                GI_UserInfo entity = EntityOperate<GI_UserInfo>.GetEntityById(Request["UserID"], "UserID");//获得用户实体
                string oldPassWord = EMR.Common.Encrypt.MD5Encrypt(Request["oldPassWord"]);//老密码
                string newPassWord = EMR.Common.Encrypt.MD5Encrypt(Request["newPassWord"]);//新密码
                if (entity.PassWord != oldPassWord)
                {
                    return new WebApi_Result() { code = 1, msg = "输入的原密码与系统中不一致" };
                }
                entity.PassWord = newPassWord;
                entity.UpdateM("UserID");
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public string ResetPassWord() {
            return base.ExecuteActionJsonResult("修改密码", () =>
            {
                GI_UserInfo entity = EntityOperate<GI_UserInfo>.GetEntityById(Request["UserID"], "UserID");//获得用户实体
                string newPassWord = EMR.Common.Encrypt.MD5Encrypt("123456");//新密码
                entity.PassWord = newPassWord;
                entity.UpdateM("UserID");
                return new WebApi_Result();
            });
        }

    }
}