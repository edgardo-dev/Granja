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
        public ActionResult CargarFicha(int? id)
        {
            tblDetalleLote tblDetalle = db.DetalleLotes.Find(id);
            ViewBag.IdEmpleado = db.Empleados.ToList();
            ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalle.IdVarraco);
            ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalle.IdCerda);
            return View(tblDetalle);
        }
        [HttpPost]
        public ActionResult CargarFicha(int IdCerda,string FechaInseminacion,int IdVarraco,string FechaParto,int? NacidosVivos,int? NacidosMuertos,int? NacidosMomias,double? PesoPromedio1D,int? NumDestete,double? PesoPromedio28D,string FechaDestete,int IdEmpleado)
        {
            var Fichas = new tblFichas();
            Fichas.NacidosVivos = NacidosVivos;
            Fichas.NacidosMuertos = NacidosMuertos;
            Fichas.NacidosMomias = NacidosMomias;
            Fichas.TotalNacidos = NacidosVivos + NacidosMuertos +NacidosMomias;
            var Cerda = (from C in db.Cerdas
                         where C.IdCerda == IdCerda
                         select C).FirstOrDefault();
            Cerda.NumParto += 1;
            Fichas.NumParto = Cerda.NumParto;
            Fichas.FechaServio = FechaInseminacion;
            Fichas.FechaParto = FechaParto;
            Fichas.FechaDestete = FechaDestete;
            Fichas.IdCerda = IdCerda;
            Fichas.IdVarraco = IdVarraco;
            Fichas.IdEmpleado = IdEmpleado;
            Fichas.PesoPromedio1D = PesoPromedio1D;
            Fichas.PesoPromedio28D = PesoPromedio28D;
            Fichas.NumDestetado = NumDestete;
            
            db.Entry(Cerda).State = EntityState.Modified;
            db.Fichas.Add(Fichas);
            db.SaveChanges();
            return RedirectToAction("Index");
            
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
                tblFichas.TotalNacidos = tblFichas.NacidosVivos + tblFichas.NacidosMuertos + tblFichas.NacidosMomias;
                var Cerda = (from C in db.Cerdas
                             where C.IdCerda == tblFichas.IdCerda
                             select C).FirstOrDefault();
                Cerda.NumParto = Cerda.NumParto+1;
                tblFichas.NumParto = Cerda.NumParto;
                db.Entry(Cerda).State = EntityState.Modified;
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
                tblFichas.TotalNacidos = tblFichas.NacidosVivos + tblFichas.NacidosMuertos + tblFichas.NacidosMomias;
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
