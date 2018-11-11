using Microsoft.AspNet.SignalR;

namespace Mensageiro.AspNet.Hubs
{
    public class UsuarioHub : Hub
    {
        private readonly IHubContext contextoHub = GlobalHost.ConnectionManager.GetHubContext<UsuarioHub>();

        public void Registrar()
        {
            contextoHub.Clients.All.atualizarContatos();
        }
    }
}