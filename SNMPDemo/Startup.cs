using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SNMPDemo.Startup))]
namespace SNMPDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
