using GranjaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GranjaSystem.Controllers
{
    public class DashboardController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.CCerdas = db.Cerdas.Count();
            ViewBag.CVarracos = db.Varracos.Count();
            ViewBag.CLotes = db.Lotes.Count();
            ViewBag.CFichas = db.Fichas.Count();
            ViewBag.CEmpleados = db.Empleados.Count();
            ViewBag.CUsuarios = db.Usuarios.Count();
            return View();
        }
    }
}