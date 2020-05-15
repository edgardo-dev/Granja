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
             private BDGranja db = new BDGranja();

        // GET: Geneticas
        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null)
            {
                return View(db.tblGeneticas.ToList());

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Geneticas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblGeneticas tblGeneticas = db.tblGeneticas.Find(id);
                if (tblGeneticas == null)
                {
                    return HttpNotFound();
                }
                return View(tblGeneticas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Geneticas/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {

                 return View();
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Geneticas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGenetica,Genetica,Observacion")] tblGeneticas tblGeneticas)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.tblGeneticas.Add(tblGeneticas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(tblGeneticas);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Geneticas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblGeneticas tblGeneticas = db.tblGeneticas.Find(id);
                if (tblGeneticas == null)
                {
                    return HttpNotFound();
                }
                return View(tblGeneticas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Geneticas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGenetica,Genetica,Observacion")] tblGeneticas tblGeneticas)
        {
            if (Session["IdUsuario"] != null)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(tblGeneticas).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tblGeneticas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Geneticas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblGeneticas tblGeneticas = db.tblGeneticas.Find(id);
                if (tblGeneticas == null)
                {
                    return HttpNotFound();
                }
                return View(tblGeneticas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Geneticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                tblGeneticas tblGeneticas = db.tblGeneticas.Find(id);
                db.tblGeneticas.Remove(tblGeneticas);
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
