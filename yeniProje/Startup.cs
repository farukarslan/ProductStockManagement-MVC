using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(yeniProje.Startup))]
namespace yeniProje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
