using Mensageiro.Aplicacao;
using System.Web.Mvc;
using Mensageiro.AspNet.Helpers;

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
        public JsonResult ObterContatos()
        {
            var contatos = usuarioAplicacao.ObterContatos(User.Identity.ObterId());

            return Json(contatos, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            usuarioAplicacao.Dispose();
            base.Dispose(disposing);
        }
    }
}