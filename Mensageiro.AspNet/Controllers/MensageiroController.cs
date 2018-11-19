using Mensageiro.Aplicacao;
using Mensageiro.AspNet.Helpers;
using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    [Authorize]
    public class MensageiroController : Controller
    {
        private readonly UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();        
        private readonly ConversaAplicacao conversaAplicacao = new ConversaAplicacao();

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
        public void GravarMensagem(string mensagem, int? conversaId, string remetenteId, string destinatarioId)
        {
            conversaAplicacao.AdicionarMensagem(mensagem, conversaId, remetenteId, destinatarioId);
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