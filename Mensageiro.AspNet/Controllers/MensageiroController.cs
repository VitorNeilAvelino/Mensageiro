using Mensageiro.Aplicacao;
using Mensageiro.AspNet.Helpers;
using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    [Authorize]
    public class MensageiroController : Controller
    {
        private readonly UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();        

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
            return this.JsonCamelCase(usuarioAplicacao.ObterMensagens(User.Identity.ObterId(), destinatarioId));
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