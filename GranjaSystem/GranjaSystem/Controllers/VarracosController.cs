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
            if (Session["IdUsuario"] != null)
            {
                var varracos = db.Varracos.Include(t => t.tblGeneticas);
                return View(varracos.ToList());

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Varracos/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
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
            else return RedirectToAction("Index", "Login");
        }

        // GET: Varracos/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica");
                return View();

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Varracos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVarraco,NumVarraco,Procedencia,Observaciones,FechaRegistro,Estado,IdGenetica")] tblVarracos tblVarracos)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                    tblVarracos.Estado = "Activo";
                    tblVarracos.FechaRegistro = DateTime.UtcNow;
                    db.Varracos.Add(tblVarracos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IdGenetica = new SelectList(db.Geneticas, "IdGenetica", "Genetica", tblVarracos.IdGenetica);
                return View(tblVarracos);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Varracos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
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
            else return RedirectToAction("Index", "Login");
        }

        // POST: Varracos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVarraco,NumVarraco,Procedencia,Observaciones,FechaRegistro,Estado,IdGenetica")] tblVarracos tblVarracos)
        {
            if (Session["IdUsuario"] != null)
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
            else return RedirectToAction("Index", "Login");
        }

        // GET: Varracos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
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
            else return RedirectToAction("Index", "Login");
        }

        // POST: Varracos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                tblVarracos tblVarracos = db.Varracos.Find(id);
                db.Varracos.Remove(tblVarracos);
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
