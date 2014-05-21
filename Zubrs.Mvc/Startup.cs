using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zubrs.Mvc.Startup))]
namespace Zubrs.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
