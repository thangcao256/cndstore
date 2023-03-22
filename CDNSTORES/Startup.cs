using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDNSTORES.Startup))]
namespace CDNSTORES
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
