using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMR.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public string Upper()
        {
            string strReturn = "";
            foreach(string each in Request["str"].Split(' '))
            {
                strReturn += each.Substring(0, 1).ToUpper() + each.Substring(1).ToLower();
            }
            //return Request["str"].Replace(" ","").ToUpper();
            return strReturn;
        }

        public string md5()
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Request["str"], "md5");
        }
    }
}