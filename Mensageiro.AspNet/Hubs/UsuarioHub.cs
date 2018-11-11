using Microsoft.AspNet.SignalR;

namespace Mensageiro.AspNet.Hubs
{
    public class UsuarioHub : Hub
    {
        IHubContext contextoHub = GlobalHost.ConnectionManager.GetHubContext<UsuarioHub>();

        public void Registrar()
        {
            contextoHub.Clients.All.atualizarContatos();
        }
    }
}