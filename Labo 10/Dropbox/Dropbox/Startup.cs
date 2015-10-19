using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dropbox.Startup))]
namespace Dropbox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
