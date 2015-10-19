using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Oefening_1.Startup))]
namespace Oefening_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
