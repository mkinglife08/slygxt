/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictController.cs
// 文件功能描述： 系统用户人员控制器，提供页面所需要调用的方法
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Core.Caching;
using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Filter;
using EMR.Services.Interface;
using EMR.Services.SystemSupport;
using EMR.Web.Extension.Common;
using EMR.Web.Extension.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using FastData;
using FastData.Context;
using FastUntility.Base;
using DataModel.GI;
using Oracle.ManagedDataAccess.Client;
using FastUntility.Page;

namespace EMR.Web.Controllers.SystemSupport
{

    public class UserController : BaseController
    {
        private UserService userService = new UserService();

        #region 增删改查
        public string SaveUserInfo()
        {
            return base.ExecuteActionJsonResult("保存用户信息", () =>
            {
                GI_UserInfo _user = base.GetPageData<GI_UserInfo>(0);
                if (!string.IsNullOrWhiteSpace(_user.PassWord))
                    _user.PassWord = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(_user.PassWord, "md5");
                if (Request["myaction"] != "UserEdit")
                    _user.UserCode = null;
                userService.SaveUserInfo(_user);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetAllUser(int page,int limit,string MyOrganId,string keyword)
        {
            var param = new List<OracleParameter>();
            param.Add(new OracleParameter { ParameterName = "OrganId", Value = MyOrganId });
            param.Add(new OracleParameter { ParameterName = "UserName", Value = keyword });

            var pageModel = new PageModel();
            pageModel.PageId = page == 0 ? 1 : page;
            pageModel.PageSize = limit == 0 ? 10 : limit;

            var pageInfo = FastMap.QueryPage(pageModel, "User.List", param.ToArray(), null, AppEmr.DbConst.EmrDb);

            return Json(new { code = 0, data = pageInfo.list, count = pageInfo.pModel.TotalRecord });
        }
        

        public string GetUserById(string userid)
        {
            var aa = Request.QueryString.Keys;
            return base.ExecuteActionJsonResult("获取用户信息", () =>
            {
                GI_UserInfo list = userService.GetInfoById(Request["userid"]);
                return new WebApi_Result() { data = list };
            });
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteUser(string userid)
        {
            var isSuccess = FastWrite.Delete<GI_USERINFO>(a => a.USERID == userid, null, AppEmr.DbConst.EmrDb).IsSuccess;

            if (isSuccess)
                return Json(new { code = 0 });
            else
                return Json(new { code = 1 });
        }
        #endregion

        #region 用户关联用户组
        public string GetUserGroup()
        {
            return base.ExecuteActionJsonResult("获取用户分组信息", () =>
            {
                List<GI_Role> list_role = new RoleService().GetAll(new CommonFilter()).Where(f => f.IsCance != 1).ToList();
                if (!string.IsNullOrWhiteSpace(Request["userid"]))
                {
                    List<GI_RoleMember> list_ROLEMEMBER = userService.GetUserGroup(Request["userid"]);
                    list_role.ForEach((f) =>
                    {
                        if (list_ROLEMEMBER.FindAll(e => e.RoleID == f.RoleID).Count > 0)
                            f.LAY_CHECKED = true;
                    });
                }
                return new WebApi_Result() { data = list_role };
            });
        }

        public string SaveUserGroup()
        {
            return base.ExecuteActionJsonResult("用户分组信息保存", () =>
            {
                userService.SaveUserGroup(Request["userid"], Request["user_group_check"]);
                return new WebApi_Result();
            });
        }
        #endregion

        #region 用户关联系统模块
        public string GetUserSys()
        {
            return base.ExecuteActionJsonResult("获取用户系统模块", () =>
            {
                List<Data.Models.GI_SYSAPPINFO> list_ret = new SysAppInfoService().GetAll(new CommonFilter());
                if (!string.IsNullOrWhiteSpace(Request["userid"]))
                {
                    List<V_USERSYS> list_USERSYS = userService.GetUserSysAppList(Request["userid"]);
                    list_ret.ForEach((f) =>
                    {
                        if (list_USERSYS.FindAll(e => e.SYSID == f.SYSID).Count > 0)
                            f.LAY_CHECKED = true;
                    });
                }
                return new WebApi_Result() { data = list_ret };
            });
        }

        public string UpdateDefaultUserSysApp()
        {
            return base.ExecuteActionJsonResult("更改用户默认显示的系统模块", () =>
            {
                GI_UserSYS entity = base.GetPageData<GI_UserSYS>(0);
                userService.UpdateDefaultUserSysApp(entity);
                return new WebApi_Result();
            });
        }

        public string SaveUserSys()
        {
            return base.ExecuteActionJsonResult("用户系统模块保存", () =>
            {
                userService.SaveUserSys(Request["userid"], Request["user_sysapp_check"], Request["isdefault"]);
                return new WebApi_Result();
            });
        }

        /// <summary>
        /// 更改用户默认显示的系统模块
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ActionResult GetUserSysAppList(string userid)
        {
            var param = new List<OracleParameter>();
            param.Add(new OracleParameter { ParameterName = "UserId", Value = userid });

            var list = FastMap.Query("User.Sys.List", param.ToArray(), null, AppEmr.DbConst.EmrDb);

            return Json(new { code = 0, data = list });
        }

        /// <summary>
        /// 更改用户默认显示的系统模块
        /// </summary>
        /// <param name="InpatientID"></param>
        /// <param name="UserId"></param>
        /// <param name="IsDefault"></param>
        /// <param name="MyOrganId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public ActionResult UpdateDefaultBQ(string InpatientID,string UserId,string IsDefault,string MyOrganId,string token)
        {
            var info = new GI_USERINFO();
            info.USERID = UserId;
            info.ORGANID = MyOrganId;
            info.INPATIENTID = InpatientID;
            info.MODIFYTIME = DateTime.Now;

            var isSuccess = FastWrite.Update<GI_USERINFO>(info, a => a.USERID == info.USERID, 
                a => new { a.ORGANID, a.INPATIENTID, a.MODIFYTIME }, null, AppEmr.DbConst.EmrDb).IsSuccess;

            return Json(new { code = 0 });
        }
        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        public ActionResult login(string password, string account)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var info = FastRead.Query<GI_USERINFO>(a => a.USERCODE.ToLower() == account.ToLower()).ToItem<GI_USERINFO>(db);

                if (string.IsNullOrEmpty(info.USERCODE))
                    return Json(new { code = 1, msg = "登录失败！该用户信息不存在或已被停用。" });

                if (info.PASSWORD == BaseSymmetric.md5(32, password) || info.PASSWORD == null)
                {
                    var token = Common.Encrypt.MD5Encrypt(string.Format("{0}{1}", Guid.NewGuid().ToString("D"), DateTime.Now.Ticks));
                    var cache = RedisCacheManager.CreateInstance();
                    var tokenlist = new List<UserToken>();

                    if (cache.IsSet("tokenlist"))
                    {
                        tokenlist = cache.Get<List<UserToken>>("tokenlist");
                        var usertoken = tokenlist.Find(f => f.UserId == info.USERID);
                        if (usertoken != null)
                        {
                            tokenlist.Remove(usertoken);
                            cache.Remove("tokenlist");
                        }
                    }

                    var _userToken = new UserToken()
                    {
                        UserId = info.USERID,
                        ORGANID = info.ORGANID,
                        USERCODE = info.USERCODE,
                        USERNAME = info.USERNAME,
                        InpatientID = info.INPATIENTID,
                        UserPhoto = info.USERPHOTO,
                        Permission = "",
                        Timeout = DateTime.Now.AddMinutes(600),
                        Token = token
                    };
                    if (_userToken.UserPhoto == null || System.IO.File.Exists(Server.MapPath("../../../" + _userToken.UserPhoto)) == false)
                        _userToken.UserPhoto = "Content/Images/face.png";
                    tokenlist.Add(_userToken);
                    cache.Update("tokenlist", tokenlist, 600);

                    return Json(new { code = 0, data = _userToken });
                }
                else
                    return Json(new { code = 1, msg = "登录失败！用户名或密码错误" });
            }
        }

        /// <summary>
        /// 获取用户相关的系统功能定义
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserFunInfo(string UserId, string SysId, string FunLevel)
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var param = new List<OracleParameter>();
                param.Add(new OracleParameter { ParameterName = "UserId", Value = UserId });
                param.Add(new OracleParameter { ParameterName = "SysId", Value = SysId });
                param.Add(new OracleParameter { ParameterName = "FunLevel", Value = FunLevel });

                var list = FastMap.Query("User.Fun.List", param.ToArray(), db);
                return Json(new { code = 0, data = list });
            }
        }


        /// <summary>
        /// 通用的文件上传方法
        /// </summary>
        /// <returns></returns>
        public string SaveFiles()
        {
            return base.ExecuteActionJsonResult("文件上传", () =>
            {
                WebApi_Result result = new WebApi_Result() { code = 1 };
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    string postFileName = file.FileName;
                    string newFileName = DateTime.Now.ToFileTime() + postFileName.Substring(postFileName.LastIndexOf(".")),
                    savePath = "~/Content/UserFiles/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
                    if (!string.IsNullOrWhiteSpace(Request["type"]))
                    {
                        if (!string.IsNullOrWhiteSpace(Request["curid"]))
                        {
                            newFileName = Request["curid"] + postFileName.Substring(postFileName.LastIndexOf("."));
                        }
                        else
                        {
                            Assembly assembly = Assembly.Load("EMR.Services");
                            var type = assembly.GetType("EMR.Services.SystemSupport." + Request["type"] + "Service");
                            ISerialPrimaryKey iSerPK = (ISerialPrimaryKey)Activator.CreateInstance(type);
                            if (type != null && iSerPK != null)
                            {
                                newFileName = iSerPK.GetPrimaryId() + postFileName.Substring(postFileName.LastIndexOf("."));
                            }
                        }
                        savePath = "~/Content/UserFiles/" + Request["type"] + "/";
                    }
                    if (!Directory.Exists(Request.MapPath(savePath)))
                        Directory.CreateDirectory(Request.MapPath(savePath));
                    file.SaveAs(Request.MapPath(savePath + newFileName));
                    result.code = 0;
                    result.data = savePath.Replace("~/", "") + newFileName;
                }
                return result;
            });
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetUserListByUserFilter()
        {
            using (var db = new DataContext(AppEmr.DbConst.EmrDb))
            {
                var list = FastRead.Query<GI_USERINFO>(a => a.ISCANCE != 1).ToDics(db);

                return Json(new { code = 1, data = list });
            }
        }
    }
}
