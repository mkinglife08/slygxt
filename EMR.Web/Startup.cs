using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using EMR.Common;

[assembly: OwinStartupAttribute(typeof(EMR.Web.Startup))]
namespace EMR.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var idProvider = new UserIdProvider();

            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
            app.MapSignalR(); 
        }
    }
}
