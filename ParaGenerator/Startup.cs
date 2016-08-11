using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParaGenerator.Startup))]
namespace ParaGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
