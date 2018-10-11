using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    public class MensageiroController : Controller
    {
        // GET: Mensageiro
        public ActionResult Index()
        {
            return View();
        }
    }
}