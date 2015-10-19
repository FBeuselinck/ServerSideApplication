using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSALabo2Oef2.Startup))]
namespace SSALabo2Oef2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
