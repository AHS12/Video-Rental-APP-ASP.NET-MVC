using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoRentalApp.Startup))]
namespace VideoRentalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
