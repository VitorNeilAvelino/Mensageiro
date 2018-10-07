using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mensageiro.AspNet.Startup))]
namespace Mensageiro.AspNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
