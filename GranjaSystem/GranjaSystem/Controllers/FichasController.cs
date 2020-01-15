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
    public class FichasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Fichas
        public ActionResult Index()
        {
            var fichas = db.Fichas.Include(t => t.Empleados).Include(t => t.Varracos).Include(t => t.Cerdas);
            return View(fichas.ToList());
        }

        // GET: Fichas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFichas tblFichas = db.Fichas.Find(id);
            if (tblFichas == null)
            {
                return HttpNotFound();
            }
            return View(tblFichas);
        }

        // GET: Fichas/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado");
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco");
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda");
            return View();
        }

        // POST: Fichas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFicha,IdCerda,NumParto,FechaServio,IdVarraco,FechaParto,NacidosVivos,NacidosMuertos,NacidosMomias,TotalNacidos,PesoPromedio1D,NumDestetado,PesoPromedio28D,FechaDestete,IdEmpleado")] tblFichas tblFichas)
        {
            if (ModelState.IsValid)
            {
                db.Fichas.Add(tblFichas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda",tblFichas.IdCerda);
            return View(tblFichas);
        }

        // GET: Fichas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFichas tblFichas = db.Fichas.Find(id);
            if (tblFichas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblFichas.IdCerda);
            return View(tblFichas);
        }

        // POST: Fichas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFicha,IdCerda,NumParto,FechaServio,IdVarraco,FechaParto,NacidosVivos,NacidosMuertos,NacidosMomias,TotalNacidos,PesoPromedio1D,NumDestetado,PesoPromedio28D,FechaDestete,IdEmpleado")] tblFichas tblFichas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFichas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblFichas.IdCerda);
            return View(tblFichas);
        }

        // GET: Fichas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFichas tblFichas = db.Fichas.Find(id);
            if (tblFichas == null)
            {
                return HttpNotFound();
            }
            return View(tblFichas);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFichas tblFichas = db.Fichas.Find(id);
            db.Fichas.Remove(tblFichas);
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
