using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcProjectAli.Startup))]
namespace MvcProjectAli
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
