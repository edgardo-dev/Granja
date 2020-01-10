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
    public class GeneticasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Geneticas
        public ActionResult Index()
        {
            return View(db.Geneticas.ToList());
        }

        // GET: Geneticas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGeneticas tblGeneticas = db.Geneticas.Find(id);
            if (tblGeneticas == null)
            {
                return HttpNotFound();
            }
            return View(tblGeneticas);
        }

        // GET: Geneticas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Geneticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGenetica,Genetica,Observacion")] tblGeneticas tblGeneticas)
        {
            if (ModelState.IsValid)
            {
                db.Geneticas.Add(tblGeneticas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblGeneticas);
        }

        // GET: Geneticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGeneticas tblGeneticas = db.Geneticas.Find(id);
            if (tblGeneticas == null)
            {
                return HttpNotFound();
            }
            return View(tblGeneticas);
        }

        // POST: Geneticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGenetica,Genetica,Observacion")] tblGeneticas tblGeneticas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGeneticas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGeneticas);
        }

        // GET: Geneticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGeneticas tblGeneticas = db.Geneticas.Find(id);
            if (tblGeneticas == null)
            {
                return HttpNotFound();
            }
            return View(tblGeneticas);
        }

        // POST: Geneticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGeneticas tblGeneticas = db.Geneticas.Find(id);
            db.Geneticas.Remove(tblGeneticas);
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
