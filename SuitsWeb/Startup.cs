using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuitsWeb.Startup))]
namespace SuitsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
