using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;

namespace GranjaSystem.Content
{
    public class LotesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lotes
        public ActionResult Index()
        {
            return View(db.Lotes.ToList());
        }

        // GET: Lotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLotes tblLotes = db.Lotes.Find(id);
            if (tblLotes == null)
            {
                return HttpNotFound();
            }
            return View(tblLotes);
        }

        // GET: Lotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLotes,NumLote,FechaRegistro,Estado")] tblLotes tblLotes)
        {
            if (ModelState.IsValid)
            {
                db.Lotes.Add(tblLotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLotes);
        }

        // GET: Lotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLotes tblLotes = db.Lotes.Find(id);
            if (tblLotes == null)
            {
                return HttpNotFound();
            }
            return View(tblLotes);
        }

        // POST: Lotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLotes,NumLote,FechaRegistro,Estado")] tblLotes tblLotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLotes);
        }

        // GET: Lotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLotes tblLotes = db.Lotes.Find(id);
            if (tblLotes == null)
            {
                return HttpNotFound();
            }
            return View(tblLotes);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLotes tblLotes = db.Lotes.Find(id);
            db.Lotes.Remove(tblLotes);
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
