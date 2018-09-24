using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mensageiro.Mvc.Startup))]
namespace Mensageiro.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
