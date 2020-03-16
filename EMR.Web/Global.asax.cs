using FastData;
using System.Web.Optimization;
using System.Web.Routing;

namespace EMR.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FastMap.InstanceProperties("DataModel.AI", "EMR.Web.dll");
            FastMap.InstanceProperties("DataModel.CD", "EMR.Web.dll");
            FastMap.InstanceProperties("DataModel.CN", "EMR.Web.dll");
            FastMap.InstanceProperties("DataModel.GI", "EMR.Web.dll");

            FastMap.InstanceMap(AppEmr.DbConst.EmrDb);
        }
    }
}
