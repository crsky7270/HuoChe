using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HuoChe.Web.Startup))]
namespace HuoChe.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
