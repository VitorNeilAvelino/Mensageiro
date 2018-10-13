using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    [Authorize]
    public class MensageiroController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}