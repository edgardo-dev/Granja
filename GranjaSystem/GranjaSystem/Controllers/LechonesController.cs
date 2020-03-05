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
    public class LechonesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lechones
        public ActionResult Index()
        {
            return View(db.Lechones.ToList());
        }

        // GET: Lechones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLechones tblLechones = db.Lechones.Find(id);
            if (tblLechones == null)
            {
                return HttpNotFound();
            }
            return View(tblLechones);
        }

        // GET: Lechones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lechones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLechones,NumLote,Edad,NCerdos,NCerdas,NVarracos,Fases,FechaInicio,FechaRegistro,Estado")] tblLechones tblLechones)
        {
            if (ModelState.IsValid)
            {
                db.Lechones.Add(tblLechones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLechones);
        }

        // GET: Lechones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLechones tblLechones = db.Lechones.Find(id);
            if (tblLechones == null)
            {
                return HttpNotFound();
            }
            return View(tblLechones);
        }

        // POST: Lechones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLechones,NumLote,Edad,NCerdos,NCerdas,NVarracos,Fases,FechaInicio,FechaRegistro,Estado")] tblLechones tblLechones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLechones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLechones);
        }

        // GET: Lechones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLechones tblLechones = db.Lechones.Find(id);
            if (tblLechones == null)
            {
                return HttpNotFound();
            }
            return View(tblLechones);
        }

        // POST: Lechones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLechones tblLechones = db.Lechones.Find(id);
            db.Lechones.Remove(tblLechones);
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
