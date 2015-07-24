using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConfigDemo.Startup))]
namespace ConfigDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
