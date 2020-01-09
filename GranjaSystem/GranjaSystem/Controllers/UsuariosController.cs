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
    public class UsuariosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(t => t.Empleados);
            return View(usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleados = new SelectList(db.Empleados, "IdEmpleados", "NombreEmpleado");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleados,IdRoles")] tblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(tblUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleados = new SelectList(db.Empleados, "IdEmpleados", "NombreEmpleado", tblUsuarios.IdEmpleados);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleados = new SelectList(db.Empleados, "IdEmpleados", "NombreEmpleado", tblUsuarios.IdEmpleados);
            return View(tblUsuarios);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleados,IdRoles")] tblUsuarios tblUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleados = new SelectList(db.Empleados, "IdEmpleados", "NombreEmpleado", tblUsuarios.IdEmpleados);
            return View(tblUsuarios);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            if (tblUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tblUsuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUsuarios tblUsuarios = db.Usuarios.Find(id);
            db.Usuarios.Remove(tblUsuarios);
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
