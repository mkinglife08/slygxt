using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EMR.Web
{
    /* 路由规则简介：
     * 1、为了方便扩展，本项目的MVC路由规则，将页面路由(Page Routes)与接口方法路由（API Routes）分开
     * 2、页面路由规则请详细参考页面增加方法中的介绍。
     * 3、接口方法路由规则请详细参考接口增加方法中的介绍。
     */
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "index",
               url: "index",
               defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
               name: "login",
               url: "login",
               defaults: new { controller = "Home", action = "Login" }
            );
            /* 页面增加方法：
             * 1、首先，在Controls/Page/下建一个控制器，控制器名称命名（要建的目录名称+Pages），比如要建一个Public的目录，控制器名称就叫：PublicPagesController
             * 2、其次，在页面显示层Views文件夹下增加一个与控制器名称一致的子文件夹，比如Public，则新建一个名为PublicPages的子文件夹：Views/PublicPages
             * 3、然后在Views/PublicPages文件夹下新建cshtml页面文件。
             * 4、每加一个页面，都要在Controls/Page/下面的相应控制器中，增加一个与页面名称一致的 ActionResult 返回值的方法，否则MVC无法正常渲染页面。比如你在Views/PublicPages新建了一个叫DeptInfoList.cshtml的页面，则必须在Controls/Page/PublicPagesController.cs中新建一个public ActionResult DeptInfoList()的方法。
             * 5、该页面路径（page+控制器名称+页面名称）：page/PublicPages/DeptInfoList
             */
            routes.MapRoute(
                name: "page",
                url: "page/{controller}/{action}/",
                defaults: new { controller = "Home", action = "Index" }
            );
            /* 页面增加方法：
             * 1、首先，在Controls文件夹下建一个目录。比如我建了一个SystemSupport目录
             * 2、其次，在新建的目录下，增加相应实体的控制器，控制器名称命名按规范命名，比如要建一个CodeDict实体的控制器，控制器名称就叫：CodeDictController
             * 3、然后，在该控制器中，编写页面所需要的逻辑方法。比如我编写了一个SaveInfo方法。
             * 4、页面调用该方法（api+目录名称+控制器名称+方法名称）：api/SystemSupport/codedict/SaveInfo
             */
            routes.MapRoute(
                name: "SystemSupport",
                url: "api/{path}/{controller}/{action}/",
                defaults: new { path = "SystemSupport", controller = "Home", action = "Index" }
            );

            /*
             * 调用的时候，注意区别是页面还是API，两者路由不同，路径不区分大小写。
             */ 
        }
    }
}
