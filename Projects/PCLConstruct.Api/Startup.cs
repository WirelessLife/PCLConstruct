using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PCLConstruct.Api.Startup))]

namespace PCLConstruct.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}