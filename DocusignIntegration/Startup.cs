using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocusignIntegration.Startup))]
namespace DocusignIntegration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
