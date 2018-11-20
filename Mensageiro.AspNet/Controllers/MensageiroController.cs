using Mensageiro.Aplicacao;
using Mensageiro.AspNet.Helpers;
using Mensageiro.AspNet.Hubs;
using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    [Authorize]
    public class MensageiroController : Controller
    {
        private readonly UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();        
        private readonly ConversaAplicacao conversaAplicacao = new ConversaAplicacao();
        private readonly MensageiroHub mensageiroHub = new MensageiroHub();

        public ActionResult Index()
        {
            return View();
        }

        [ActionName("Contatos")]
        public ActionResult ObterContatos()
        {
            return this.JsonCamelCase(usuarioAplicacao.ObterContatos(User.Identity.ObterId()));
        }

        [ActionName("Mensagens")]
        public ActionResult ObterMensagens(string destinatarioId)
        {
            return this.JsonCamelCase(conversaAplicacao.ObterMensagens(User.Identity.ObterId(), destinatarioId));
        }

        [HttpPost]
        [ActionName("Mensagens")]
        public void GravarMensagem(string mensagem, int? conversaId, string destinatarioId)
        {
            conversaAplicacao.AdicionarMensagem(mensagem, conversaId, User.Identity.ObterId(), destinatarioId);

            var destinatario = usuarioAplicacao.Obter(destinatarioId);

            mensageiroHub.EnviarMensagem(destinatario.UserName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                usuarioAplicacao.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}