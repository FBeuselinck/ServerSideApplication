using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DropBox.WebApp.Startup))]
namespace DropBox.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
