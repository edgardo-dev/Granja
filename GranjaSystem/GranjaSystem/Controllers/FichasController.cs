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
             private BDGranja db = new BDGranja();

        // GET: Fichas
        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null)
            {
                var fichas = db.tblFichas.Include(t => t.tblEmpleados).Include(t => t.tblVarracos).Include(t => t.tblCerdas);
                return View(fichas.ToList());

            }
            else return RedirectToAction("Index", "Login");
        }
        public ActionResult CargarFicha(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                tblDetalleLotes tblDetalle = db.tblDetalleLotes.Find(id);
                ViewBag.IdEmpleado = db.tblEmpleados.ToList();
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblDetalle.IdVarraco);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblDetalle.IdCerda);
                if (tblDetalle.FechaInseminacion.Month >= 10 && tblDetalle.FechaInseminacion.Day >= 10)
                {
                    ViewBag.FechaI = tblDetalle.FechaInseminacion.Year + "-" + tblDetalle.FechaInseminacion.Month + "-" + tblDetalle.FechaInseminacion.Day;
                }
                else if (tblDetalle.FechaInseminacion.Month <= 9 && tblDetalle.FechaInseminacion.Day <= 9)
                {
                    ViewBag.FechaI = tblDetalle.FechaInseminacion.Year + "-0" + tblDetalle.FechaInseminacion.Month + "-0" + tblDetalle.FechaInseminacion.Day;
                }
                else if (tblDetalle.FechaInseminacion.Month <= 9)
                {
                    ViewBag.FechaI = tblDetalle.FechaInseminacion.Year + "-0" + tblDetalle.FechaInseminacion.Month + "-" + tblDetalle.FechaInseminacion.Day;
                }
                else if ((tblDetalle.FechaInseminacion.Day <= 9))
                {
                    ViewBag.FechaI = tblDetalle.FechaInseminacion.Year + "-" + tblDetalle.FechaInseminacion.Month + "-0" + tblDetalle.FechaInseminacion.Day;
                }
                if (tblDetalle.FechaParto.Month >= 10 && tblDetalle.FechaParto.Day >= 10)
                {
                    ViewBag.FechaP = tblDetalle.FechaParto.Year + "-" + tblDetalle.FechaParto.Month + "-" + tblDetalle.FechaParto.Day;
                }
                else if (tblDetalle.FechaParto.Month <= 9 && tblDetalle.FechaParto.Day <= 9)
                {
                    ViewBag.FechaP = tblDetalle.FechaParto.Year + "-0" + tblDetalle.FechaParto.Month + "-0" + tblDetalle.FechaParto.Day;
                }
                else if (tblDetalle.FechaParto.Month <= 9)
                {
                    ViewBag.FechaP = tblDetalle.FechaParto.Year + "-0" + tblDetalle.FechaParto.Month + "-" + tblDetalle.FechaParto.Day;
                }
                else if ((tblDetalle.FechaParto.Day <= 9))
                {
                    ViewBag.FechaP = tblDetalle.FechaParto.Year + "-" + tblDetalle.FechaParto.Month + "-0" + tblDetalle.FechaParto.Day;
                }
                return View(tblDetalle);
            }
            else return RedirectToAction("Index", "Login");

        }
        [HttpPost]
        public ActionResult CargarFicha(int IdCerda,string FechaInseminacion,int IdVarraco,string FechaParto,int? NacidosVivos,int? NacidosMuertos,int? NacidosMomias,decimal? PesoPromedio1D,int? NumDestete,decimal? PesoPromedio28D,string FechaDestete,int IdEmpleado)
        {
            if (Session["IdUsuario"] != null)
            {

                var Fichas = new tblFichas
                {
                    NacidosVivos = NacidosVivos,
                    NacidosMuertos = NacidosMuertos,
                    NacidosMomias = NacidosMomias,
                    TotalNacidos = NacidosVivos + NacidosMuertos + NacidosMomias
                };
                var Cerda = (from C in db.tblCerdas
                             where C.IdCerda == IdCerda
                             select C).FirstOrDefault();
                Cerda.NumParto += 1;
                Cerda.Estado = "Inseminada";
            
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
                var DetalleL = db.tblDetalleLotes.Where(d => d.IdCerda == Fichas.IdCerda).ToList().LastOrDefault();
                if (Fichas.NumDestetado != null && Fichas.PesoPromedio28D != null)
                {
                    DetalleL.Estado = "Finalizado";
                    Cerda.Estado = "Vacía";
                    db.Entry(DetalleL).State = EntityState.Modified;
                }
                var NLote = (from N in db.tblLotes
                                         where N.IdLote == DetalleL.IdLote
                                         select N.NumLote).FirstOrDefault();
                Fichas.Lote = NLote;
                db.Entry(Cerda).State = EntityState.Modified;
                db.tblFichas.Add(Fichas);
                db.SaveChanges();

                return RedirectToAction("Index", "DetalleLotes", new { id = DetalleL.IdLote });
            }
            else return RedirectToAction("Index", "Login");

        }

        // GET: Fichas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblFichas tblFichas = db.tblFichas.Find(id);
                if (tblFichas == null)
                {
                    return HttpNotFound();
                }
                return View(tblFichas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Fichas/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados, "IdEmpleado", "NombreEmpleado");
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco");
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda");
                return View();

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Fichas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFicha,Lote,IdCerda,NumParto,FechaServio,IdVarraco,FechaParto,NacidosVivos,NacidosMuertos,NacidosMomias,TotalNacidos,PesoPromedio1D,NumDestetado,PesoPromedio28D,FechaDestete,IdEmpleado")] tblFichas tblFichas)
        {
            if (Session["IdUsuario"] != null)
            {

                if (ModelState.IsValid)
                {
                    tblFichas.TotalNacidos = tblFichas.NacidosVivos + tblFichas.NacidosMuertos + tblFichas.NacidosMomias;
                    var Cerda = (from C in db.tblCerdas
                                 where C.IdCerda == tblFichas.IdCerda
                                 select C).FirstOrDefault();
                    Cerda.NumParto += 1;
                    Cerda.Estado = "Inseminada";
                    tblFichas.NumParto = Cerda.NumParto;
                    //var DetalleL = db.DetalleLotes.Where(d => d.IdCerda == tblFichas.IdCerda).ToList().LastOrDefault();
                    if (tblFichas.NumDestetado != null && tblFichas.PesoPromedio28D != null)
                    {
                        Cerda.Estado = "Vacía";
                    }
                
                    db.Entry(Cerda).State = EntityState.Modified;
                    db.tblFichas.Add(tblFichas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda",tblFichas.IdCerda);
                return View(tblFichas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Fichas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                tblFichas tblFichas = db.tblFichas.Find(id);

                if (tblFichas == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblFichas.IdCerda);
                return View(tblFichas);
            }
            else return RedirectToAction("Index", "Login");
        }

        public ActionResult EditarDesdeCerda(int? id,int idL)
        {
            if (Session["IdUsuario"] != null)
            {

                var Cerda = db.tblCerdas.Find(id);
                ViewBag.idL = idL;
                tblFichas tblFichas = db.tblFichas.Where(x => x.IdCerda == Cerda.IdCerda).ToList().LastOrDefault();
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblFichas.IdCerda);
               //return RedirectToAction("Edit",tblFichas);
                return View("Edit", tblFichas);
            }
            else return RedirectToAction("Index", "Login");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDesdeCerda([Bind(Include = "IdFicha,IdCerda,NumParto,FechaServio,IdVarraco,FechaParto,NacidosVivos,NacidosMuertos,NacidosMomias,TotalNacidos,PesoPromedio1D,NumDestetado,PesoPromedio28D,FechaDestete,IdEmpleado")] tblFichas tblFichas)
        {
            if (Session["IdUsuario"] != null)
            {

                var DetalleL = db.tblDetalleLotes.Where(d => d.IdCerda == tblFichas.IdCerda).ToList().LastOrDefault();
                if (ModelState.IsValid)
                {
                    tblFichas.TotalNacidos = tblFichas.NacidosVivos + tblFichas.NacidosMuertos + tblFichas.NacidosMomias;
                    tblFichas.Lote = DetalleL.IdLote;
                    db.Entry(tblFichas).State = EntityState.Modified;
                    if (tblFichas.NumDestetado != null && tblFichas.PesoPromedio28D != null)
                    {
                        var Cerda = (from C in db.tblCerdas
                                     where C.IdCerda == tblFichas.IdCerda
                                     select C).FirstOrDefault();
                        //var DetalleL = db.DetalleLotes.Where(d => d.IdCerda == tblFichas.IdCerda).ToList().LastOrDefault();
                        DetalleL.Estado = "Finalizado";
                        Cerda.Estado = "Vacía";
                        db.Entry(DetalleL).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index", "DetalleLotes", new { id = DetalleL.IdLote });
                }
                //ViewBag.IdEmpleado = new SelectList(db.Empleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
                //ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
                //ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblFichas.IdCerda);
                return RedirectToAction("Index", "DetalleLotes", new { id = DetalleL.IdLote });
            }
            else return RedirectToAction("Index", "Login");
        }
        // POST: Fichas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFicha,IdCerda,NumParto,FechaServio,IdVarraco,FechaParto,NacidosVivos,NacidosMuertos,NacidosMomias,TotalNacidos,PesoPromedio1D,NumDestetado,PesoPromedio28D,FechaDestete,IdEmpleado")] tblFichas tblFichas)
        {
            if (Session["IdUsuario"] != null)
            {

                if (ModelState.IsValid)
                {
                    tblFichas.TotalNacidos = tblFichas.NacidosVivos + tblFichas.NacidosMuertos + tblFichas.NacidosMomias;
                    db.Entry(tblFichas).State = EntityState.Modified;
                    //var DetalleL = db.DetalleLotes.Where(d => d.IdCerda == tblFichas.IdCerda).ToList().LastOrDefault();
                    if (tblFichas.NumDestetado != null && tblFichas.PesoPromedio28D != null)
                    {
                        var Cerda = (from C in db.tblCerdas
                                     where C.IdCerda == tblFichas.IdCerda
                                     select C).FirstOrDefault();
                        //var DetalleL = db.DetalleLotes.Where(d => d.IdCerda == tblFichas.IdCerda).ToList().LastOrDefault();
                        Cerda.Estado = "Vacía";
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados, "IdEmpleado", "NombreEmpleado", tblFichas.IdEmpleado);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblFichas.IdVarraco);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblFichas.IdCerda);
                return View(tblFichas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Fichas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
              
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblFichas tblFichas = db.tblFichas.Find(id);
                if (tblFichas == null)
                {
                    return HttpNotFound();
                }
                return View(tblFichas);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {

                tblFichas tblFichas = db.tblFichas.Find(id);
                db.tblFichas.Remove(tblFichas);
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
