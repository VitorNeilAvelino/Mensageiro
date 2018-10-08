using Mensageiro.Dominio.Interfaces;
using Mensageiro.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mensageiro.AspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly MensageiroDbContext db = new MensageiroDbContext();

        //private readonly IMensageiroUnitOfWork db;

        //public HomeController(IMensageiroUnitOfWork db)
        //{
        //    this.
        //}

        public ActionResult Index()
        {
            var usuarios = db.Usuarios.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}