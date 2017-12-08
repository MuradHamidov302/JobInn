using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobInn.Startup))]
namespace JobInn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
