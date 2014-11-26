using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mugs.Startup))]
namespace Mugs
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
