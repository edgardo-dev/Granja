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
    public class VacunasController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: Vacunas
        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null)
            {
                var vacunas = db.Vacunas.Include(t => t.tblCerdas);
                return View(vacunas.ToList());

            }
                else return RedirectToAction("Index", "Login");
        }

        // GET: Vacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblVacunas tblVacunas = db.Vacunas.Find(id);
                if (tblVacunas == null)
                {
                    return HttpNotFound();
                }
                return View(tblVacunas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Vacunas/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda");
                return View();

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Vacunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVacuna,IdCerda,FechaRegistro,FechaInyeccion,Vacuna,Descripcion")] tblVacunas tblVacunas)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                    tblVacunas.FechaRegistro  = DateTime.UtcNow;
                    db.Vacunas.Add(tblVacunas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "Procedencia", tblVacunas.IdCerda);
                return View(tblVacunas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Vacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblVacunas tblVacunas = db.Vacunas.Find(id);
                if (tblVacunas == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblVacunas.IdCerda);
                return View(tblVacunas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Vacunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVacuna,IdCerda,FechaRegistro,FechaInyeccion,Vacuna,Descripcion")] tblVacunas tblVacunas)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                
                    db.Entry(tblVacunas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblVacunas.IdCerda);
                return View(tblVacunas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Vacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblVacunas tblVacunas = db.Vacunas.Find(id);
                if (tblVacunas == null)
                {
                    return HttpNotFound();
                }
                return View(tblVacunas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                tblVacunas tblVacunas = db.Vacunas.Find(id);
                db.Vacunas.Remove(tblVacunas);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else return RedirectToAction("Index", "Login");
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
