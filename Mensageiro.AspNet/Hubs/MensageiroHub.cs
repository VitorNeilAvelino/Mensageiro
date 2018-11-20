using Mensageiro.AspNet.Helpers;
using Microsoft.AspNet.SignalR;
using System.Web;

namespace Mensageiro.AspNet.Hubs
{
    public class MensageiroHub : Hub
    {
        private readonly IHubContext contextoHub = GlobalHost.ConnectionManager.GetHubContext<MensageiroHub>();

        public void RegistrarUsuario()
        {
            contextoHub.Clients.All.atualizarContatos();
        }
    }
}