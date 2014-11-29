using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02_DisplayAssemblyLocation.Startup))]
namespace _02_DisplayAssemblyLocation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
