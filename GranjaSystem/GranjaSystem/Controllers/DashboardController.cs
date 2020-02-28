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
            ViewBag.CEmpleados = db.Empleados.Where(e => e.NombreEmpleado != "Pendiente").Count();
            ViewBag.CUsuarios = db.Usuarios.Count();
            DateTime Fecha = DateTime.Now.Date;
            
            ViewBag.IdL = db.DetalleLotes.Where(d => d.Fvacuna1 == Fecha).ToList();
            ViewBag.IdV = db.DetalleLotes.Where(d => d.Fvacuna2 == Fecha).ToList();
            ViewBag.Vit = db.DetalleLotes.Where(d => d.Fvacuna1 == Fecha).Count();
            ViewBag.Lit = db.DetalleLotes.Where(d => d.Fvacuna2 == Fecha).Count();
            ViewBag.TotalV = ViewBag.Vit + ViewBag.Lit;
            return View();
        }
    }
}