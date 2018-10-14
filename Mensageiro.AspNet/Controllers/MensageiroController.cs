using Mensageiro.Aplicacao;
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