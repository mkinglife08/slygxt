//using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
//[assembly: OwinStartup(typeof(EMR.Common.Startup))]
namespace EMR.Common
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
