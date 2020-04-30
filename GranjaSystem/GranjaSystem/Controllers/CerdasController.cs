using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;
using Rotativa;

namespace GranjaSystem.Controllers
{
    public class CerdasController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: Cerdas
        public ActionResult Index()
        {
            var cerdas = db.Cerdas.Include(t => t.tblGeneticas);
            return View(cerdas.ToList());
        }

        // GET: Cerdas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCerdas tblCerdas = db.Cerdas.Find(id);
            if (tblCerdas == null)
            {
                return HttpNotFound();
            }
            ViewBag.FichasC = db.Fichas.Where(h => h.IdCerda == id).Include(t => t.tblEmpleados).Include(t => t.tblVarracos).ToList();
            ViewBag.Vacunas = db.Vacunas.Where(h => h.IdCerda == id).ToList();
            return View(tblCerdas);
        }

        // GET: Cerdas/Create
        public ActionResult Create()
        {
            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica");
            return View();
        }

        // POST: Cerdas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCerda,NumCerda,Procedencia,Observaciones,NumParto,FechaRegistro,Estado,IdGenetica")] tblCerdas tblCerdas)
        {
            if (ModelState.IsValid)
            {
                tblCerdas.Estado = "Vacía";
                tblCerdas.NumParto = 0;
                tblCerdas.FechaRegistro = DateTime.UtcNow;
                db.Cerdas.Add(tblCerdas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblCerdas.IdGenetica);
            return View(tblCerdas);
        }

        // GET: Cerdas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCerdas tblCerdas = db.Cerdas.Find(id);
            if (tblCerdas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblCerdas.IdGenetica);
            return View(tblCerdas);
        }

        // POST: Cerdas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCerda,NumCerda,Procedencia,Observaciones,NumParto,FechaRegistro,Estado,IdGenetica")] tblCerdas tblCerdas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCerdas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblCerdas.IdGenetica);
            return View(tblCerdas);
        }

        // GET: Cerdas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCerdas tblCerdas = db.Cerdas.Find(id);
            if (tblCerdas == null)
            {
                return HttpNotFound();
            }
            return View(tblCerdas);
        }

        // POST: Cerdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblCerdas tblCerdas = db.Cerdas.Find(id);
            db.Cerdas.Remove(tblCerdas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult ReporteCerda(int? id)
        {
            
            ViewBag.Fichas = db.Fichas.Where(h => h.IdCerda == id).Include(t => t.tblEmpleados).Include(t => t.tblVarracos).ToList();
            ViewBag.Vacunas = db.Vacunas.Where(h => h.IdCerda == id).ToList();
            ViewBag.Cerdas = db.Cerdas.Where(c=>c.IdCerda ==id).Include(g=>g.tblGeneticas).FirstOrDefault();

            return View();
        }
        public ActionResult Print(int id)
        {
            return new ActionAsPdf("ReporteCerda", new { id = id })
            {
                FileName = "Reporte_Fichas.pdf",
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                PageSize = Rotativa.Options.Size.Letter
            };
        }
    }
}
