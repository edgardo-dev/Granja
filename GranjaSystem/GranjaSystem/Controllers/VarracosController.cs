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
    public class VarracosController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: Varracos
        public ActionResult Index()
        {
            var varracos = db.Varracos.Include(t => t.tblGeneticas);
            return View(varracos.ToList());
        }

        // GET: Varracos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVarracos tblVarracos = db.Varracos.Find(id);
            if (tblVarracos == null)
            {
                return HttpNotFound();
            }
            return View(tblVarracos);
        }

        // GET: Varracos/Create
        public ActionResult Create()
        {
            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica");
            return View();
        }

        // POST: Varracos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVarraco,NumVarraco,Procedencia,Observaciones,FechaRegistro,Estado,IdGenetica")] tblVarracos tblVarracos)
        {
            if (ModelState.IsValid)
            {
                tblVarracos.Estado = "Activo";
                tblVarracos.FechaRegistro = DateTime.Now;
                db.Varracos.Add(tblVarracos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblVarracos.IdGenetica);
            return View(tblVarracos);
        }

        // GET: Varracos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVarracos tblVarracos = db.Varracos.Find(id);
            if (tblVarracos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblVarracos.IdGenetica);
            return View(tblVarracos);
        }

        // POST: Varracos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVarraco,NumVarraco,Procedencia,Observaciones,FechaRegistro,Estado,IdGenetica")] tblVarracos tblVarracos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVarracos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblVarracos.IdGenetica);
            return View(tblVarracos);
        }

        // GET: Varracos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVarracos tblVarracos = db.Varracos.Find(id);
            if (tblVarracos == null)
            {
                return HttpNotFound();
            }
            return View(tblVarracos);
        }

        // POST: Varracos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVarracos tblVarracos = db.Varracos.Find(id);
            db.Varracos.Remove(tblVarracos);
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
