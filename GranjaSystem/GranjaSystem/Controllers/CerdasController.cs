using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;

namespace GranjaSystem.Controllers
{
    public class CerdasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Cerdas
        public ActionResult Index()
        {
            var cerdas = db.Cerdas.Include(t => t.Genetica);
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
            ViewBag.FichasC = db.Fichas.Where(h => h.IdCerda == id).Include(t => t.Empleados).Include(t => t.Varracos).ToList();
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
                tblCerdas.FechaRegistro = DateTime.Now;
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
    }
}
