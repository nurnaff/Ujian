using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WVC.Startup))]
namespace WVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
