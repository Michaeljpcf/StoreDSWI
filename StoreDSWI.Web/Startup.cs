using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreDSWI.Web.Startup))]
namespace StoreDSWI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
