using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gestor.Startup))]
namespace Gestor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
