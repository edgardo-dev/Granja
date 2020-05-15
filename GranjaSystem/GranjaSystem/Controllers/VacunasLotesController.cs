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
             private BDGranja db = new BDGranja();

        // GET: VacunasLotes
        public ActionResult Index(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                var vacunasLote = db.tblVacunasLotes.Include(t => t.tblLotes);
                return View(vacunasLote.ToList());

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: VacunasLotes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblVacunasLotes tblVacunasLote = db.tblVacunasLotes.Find(id);
                if (tblVacunasLote == null)
                {
                    return HttpNotFound();
                }
            

                return View(tblVacunasLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: VacunasLotes/Create
        public ActionResult Create(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.idL = id;
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote");
                return View();

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: VacunasLotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVacunaLote,IdLote,FechaVacuna,Vacuna,Descripcion")] tblVacunasLotes tblVacunasLote,int IdLotes)
        {
            if (Session["IdUsuario"] != null)
            {

                if (ModelState.IsValid)
                {
                    tblVacunasLote.IdLote = IdLotes;
                    db.tblVacunasLotes.Add(tblVacunasLote);
                    db.SaveChanges();
                    return RedirectToAction("Index", "DetalleLotes", new { id = tblVacunasLote.IdLote });
                }

                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
                return RedirectToAction("Index", "DetalleLotes", new { id = tblVacunasLote.IdLote });
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: VacunasLotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblVacunasLotes tblVacunasLote = db.tblVacunasLotes.Find(id);
                if (tblVacunasLote == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
                return View(tblVacunasLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: VacunasLotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVacunaLote,IdLote,FechaVacuna,Vacuna,Descripcion")] tblVacunasLotes tblVacunasLote)
        {
            if (Session["IdUsuario"] != null)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(tblVacunasLote).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote", tblVacunasLote.IdLote);
                return View(tblVacunasLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: VacunasLotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblVacunasLotes tblVacunasLote = db.tblVacunasLotes.Find(id);
                if (tblVacunasLote == null)
                {
                    return HttpNotFound();
                }
                return View(tblVacunasLote);

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: VacunasLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                tblVacunasLotes tblVacunasLote = db.tblVacunasLotes.Find(id);
                db.tblVacunasLotes.Remove(tblVacunasLote);
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
