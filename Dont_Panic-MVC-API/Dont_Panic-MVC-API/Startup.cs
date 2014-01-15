using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dont_Panic_MVC_API.Startup))]
namespace Dont_Panic_MVC_API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
