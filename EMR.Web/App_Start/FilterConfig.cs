using System.Web.Mvc;
using EMR.Web.Filter;

namespace EMR.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //全局出错过滤器
            filters.Add(new ErrorAttribute());

            //全局权限过滤器
            filters.Add(new PowerAttribute());
        }
    }
}
