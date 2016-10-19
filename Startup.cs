using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(omarta_v1._1.Startup))]
namespace omarta_v1._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
