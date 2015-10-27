using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS_SKINS_ASP.Startup))]
namespace CS_SKINS_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
