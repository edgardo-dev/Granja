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
    public class RolesController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: Roles
        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null)
            {
                return View(db.Roles.ToList());

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblRoles tblRoles = db.Roles.Find(id);
                if (tblRoles == null)
                {
                    return HttpNotFound();
                }
                return View(tblRoles);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {
                 return View();

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRol,Rol,Descripcion")] tblRoles tblRoles)
        {
            if (Session["IdUsuario"] != null)
            {

                if (ModelState.IsValid)
                {
                    db.Roles.Add(tblRoles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(tblRoles);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblRoles tblRoles = db.Roles.Find(id);
                if (tblRoles == null)
                {
                    return HttpNotFound();
                }
                return View(tblRoles);

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRol,Rol,Descripcion")] tblRoles tblRoles)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tblRoles).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tblRoles);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblRoles tblRoles = db.Roles.Find(id);
                if (tblRoles == null)
                {
                    return HttpNotFound();
                }
                return View(tblRoles);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                tblRoles tblRoles = db.Roles.Find(id);
                db.Roles.Remove(tblRoles);
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
