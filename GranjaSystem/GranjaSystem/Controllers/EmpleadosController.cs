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
    public class EmpleadosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Empleados
        public ActionResult Index()
        {
            return View(db.Empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.Empleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmpleado,NombreEmpleado,ApellidoEmpleado,Telefono,DUI,NIT,FechaRegistro,FechaNacimiento,Email")] tblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                tblEmpleados.FechaRegistro = DateTime.Now;
                db.Empleados.Add(tblEmpleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEmpleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.Empleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmpleado,NombreEmpleado,ApellidoEmpleado,Telefono,DUI,NIT,FechaRegistro,FechaNacimiento,Email")] tblEmpleados tblEmpleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEmpleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEmpleados tblEmpleados = db.Empleados.Find(id);
            if (tblEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEmpleados tblEmpleados = db.Empleados.Find(id);
            db.Empleados.Remove(tblEmpleados);
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
