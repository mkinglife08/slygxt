/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FunInfoController.cs
// 文件功能描述： 系统设置模块下所有页面的控制器，每个页面都需要对应一个方法名称与页面名称一致的方法，否则无法正常渲染页面。方法中也可以返回一些简单的参数给前端页面，具体可以参考.net MVC的使用方法。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers.Page
{
    public class SystemSupportPagesController : Controller
    {
        public ActionResult Index()
        {
            //return View("~/Views/SystemSupport/UserList.cshtml");
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult UserEdit()
        {
            return View();
        }
        public ActionResult CodeDictList()
        {
            return View();
        }

        public ActionResult CodeDictEdit()
        {
            return View();
        }
        public ActionResult RoleList()
        {
            return View();
        }

        public ActionResult RoleEdit()
        {
            return View();
        }

        public ActionResult FunInfoList()
        {
            return View();
        }

        public ActionResult FunInfoEdit()
        {
            return View();
        }
        public ActionResult SysAppInfoList()
        {
            return View();
        }

        public ActionResult SysAppInfoEdit()
        {
            return View();
        }

        public ActionResult OrganInfoList()
        {
            return View();
        }

        public ActionResult OrganInfoEdit()
        {
            return View();
        }

        public ActionResult SysAppParamInfoList()
        {
            return View();
        }

        public ActionResult SysAppParamInfoEdit()
        {
            return View();
        }

        public ActionResult UserRole()
        {
            return View();
        }

        public ActionResult UserSysApp()
        {
            return View();
        }

        public ActionResult RoleRight()
        {
            return View();
        }

        public ActionResult welcome()
        {
            return View();
        }
    }
}