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
    public class DetalleLotesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: DetalleLotes
        public ActionResult Index(int? id)
        {
            ViewBag.id = id;
            var detalleLotes = db.DetalleLotes.Where(L => L.IdLote== id).Include(t => t.Lotes).Include(t => t.Varracos).Include(t => t.Cerdas);
            return View(detalleLotes.ToList());
        }

        // GET: DetalleLotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDetalleLote tblDetalleLote = db.DetalleLotes.Find(id);
            if (tblDetalleLote == null)
            {
                return HttpNotFound();
            }
            return View(tblDetalleLote);
        }

        // GET: DetalleLotes/Create
        public ActionResult Create()
        {
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote");
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda");
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco");
            return View();
        }

        // POST: DetalleLotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDLote,IdCerda,FechaInseminacion,FechaParto,IdVarraco,Fvacuna1,Fvacuna2,Observaciones,FechaRegistro,IdLote,Estado")] tblDetalleLote tblDetalleLote)
        {
            if (ModelState.IsValid)
            {
                tblDetalleLote.FechaRegistro = DateTime.Now;
                db.DetalleLotes.Add(tblDetalleLote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
            return View(tblDetalleLote);
        }

        // GET: DetalleLotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDetalleLote tblDetalleLote = db.DetalleLotes.Find(id);
            if (tblDetalleLote == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
            return View(tblDetalleLote);
        }

        // POST: DetalleLotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDLote,IdCerda,FechaInseminacion,FechaParto,IdVarraco,Fvacuna1,Fvacuna2,Observaciones,FechaRegistro,IdLote,Estado")] tblDetalleLote tblDetalleLote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblDetalleLote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
            return View(tblDetalleLote);
        }

        // GET: DetalleLotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDetalleLote tblDetalleLote = db.DetalleLotes.Find(id);
            if (tblDetalleLote == null)
            {
                return HttpNotFound();
            }
            return View(tblDetalleLote);
        }

        // POST: DetalleLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDetalleLote tblDetalleLote = db.DetalleLotes.Find(id);
            db.DetalleLotes.Remove(tblDetalleLote);
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
