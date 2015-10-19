using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dropbox2.Startup))]
namespace Dropbox2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
