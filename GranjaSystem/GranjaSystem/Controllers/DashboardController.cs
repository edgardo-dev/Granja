using GranjaSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GranjaSystem.Controllers
{
    public class DashboardController : Controller
    {
        private BDGranja db = new BDGranja();
        // GET: Dashboard
        public ActionResult Index()
        {

            if (Session["IdUsuario"] != null)
            {
                ViewBag.CCerdas = db.tblCerdas.Count();
                ViewBag.CVarracos = db.tblVarracos.Count();
                ViewBag.CLotes = db.tblLotes.Count();
                ViewBag.CFichas = db.tblFichas.Count();
                ViewBag.CLechones = db.tblLechones.Count();
                ViewBag.CEmpleados = db.tblEmpleados.Where(e => e.NombreEmpleado != "Pendiente").Count();
                ViewBag.CUsuarios = db.tblUsuarios.Where(x=>x.IdEmpleado!=1).Count();
                DateTime Fecha = DateTime.Now.Date;

                ViewBag.IdL = db.tblDetalleLotes.Where(d => d.Fvacuna1 == Fecha).Include(t => t.tblLotes).ToList();
                ViewBag.IdP = db.tblDetalleLotes.Where(d => d.Fvacuna15 == Fecha).Include(t => t.tblLotes).ToList();
                ViewBag.IdV = db.tblDetalleLotes.Where(d => d.Fvacuna2 == Fecha).Include(t => t.tblLotes).ToList();
                ViewBag.Vit = db.tblDetalleLotes.Where(d => d.Fvacuna2 == Fecha).Count();
                ViewBag.Lit = db.tblDetalleLotes.Where(d => d.Fvacuna1 == Fecha).Count();
                ViewBag.LPr = db.tblDetalleLotes.Where(d => d.Fvacuna15 == Fecha).Count();
                ViewBag.TotalV = ViewBag.Vit + ViewBag.Lit + ViewBag.LPr;
                return View();
            }
            else return RedirectToAction("Index", "Login");
          
        }
    }
}