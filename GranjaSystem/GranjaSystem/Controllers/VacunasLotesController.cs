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
    public class VacunasLotesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: VacunasLotes
        public ActionResult Index(int? id)
        {
            
            var vacunasLote = db.VacunasLote.Include(t => t.Lotes);
            return View(vacunasLote.ToList());
        }

        // GET: VacunasLotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVacunasLote tblVacunasLote = db.VacunasLote.Find(id);
            if (tblVacunasLote == null)
            {
                return HttpNotFound();
            }
            return View(tblVacunasLote);
        }

        // GET: VacunasLotes/Create
        public ActionResult Create(int? id)
        {
            ViewBag.idL = id;
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote");
            return View();
        }

        // POST: VacunasLotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVacunaLote,IdLote,FechaVacuna,Vacuna,Descripcion")] tblVacunasLote tblVacunasLote,int IdLotes)
        {
            if (ModelState.IsValid)
            {
                tblVacunasLote.IdLote = IdLotes;
                db.VacunasLote.Add(tblVacunasLote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
            return View(tblVacunasLote);
        }

        // GET: VacunasLotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVacunasLote tblVacunasLote = db.VacunasLote.Find(id);
            if (tblVacunasLote == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
            return View(tblVacunasLote);
        }

        // POST: VacunasLotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVacunaLote,IdLote,FechaVacuna,Vacuna,Descripcion")] tblVacunasLote tblVacunasLote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVacunasLote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
            return View(tblVacunasLote);
        }

        // GET: VacunasLotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVacunasLote tblVacunasLote = db.VacunasLote.Find(id);
            if (tblVacunasLote == null)
            {
                return HttpNotFound();
            }
            return View(tblVacunasLote);
        }

        // POST: VacunasLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVacunasLote tblVacunasLote = db.VacunasLote.Find(id);
            db.VacunasLote.Remove(tblVacunasLote);
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
