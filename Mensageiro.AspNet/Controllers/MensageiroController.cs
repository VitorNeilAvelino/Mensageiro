using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    public class MensageiroController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}