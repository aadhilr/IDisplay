using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IDisplay.Startup))]
namespace IDisplay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
