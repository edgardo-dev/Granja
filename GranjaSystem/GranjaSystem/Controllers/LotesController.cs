using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;

namespace GranjaSystem.Content
{
    public class LotesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lotes
        public ActionResult Index()
        {
            ViewBag.TLechones = db.Fichas.ToList();
            return View(db.Lotes.ToList());
        }

        // GET: Lotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLotes tblLotes = db.Lotes.Find(id);
            if (tblLotes == null)
            {
                return HttpNotFound();
            }
            
                ViewBag.DLotes = db.DetalleLotes.Where(h => h.IdLote == id).Include(t => t.Varracos).Include(t => t.Cerdas).ToList();
            return View(tblLotes);
        }
        // GET: Lotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLotes tblLotes = db.Lotes.Find(id);
            if (tblLotes == null)
            {
                return HttpNotFound();
            }
            return View(tblLotes);
        }

        // POST: Lotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLote,NumLote,FechaRegistro,Estado")] tblLotes tblLotes, DateTime Fecha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLotes);
        }

        // GET: Lotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLotes tblLotes = db.Lotes.Find(id);
            if (tblLotes == null)
            {
                return HttpNotFound();
            }
            return View(tblLotes);
        }
        //[HttpPost]
        //public Ac
        // POST: Lotes/Delete/5
        [HttpPost]

        public ActionResult Delete(int id)
        {
            tblLotes tblLotes = db.Lotes.Find(id);
            var CDL = (from C in db.DetalleLotes
                          where C.IdLote == id
                          select C).Count();
            for (int i = 0; i < CDL; i++)
            {
                var DCerda = (from C in db.DetalleLotes
                                  where C.IdLote == id
                                  select C.IdCerda).First();
                    var ECerda = (from C in db.Cerdas
                                  where C.IdCerda == DCerda
                                  select C).FirstOrDefault();
                    ECerda.Estado = "Vacía";
                    db.Entry(ECerda).State = EntityState.Modified;
                var tblDetalleLote = db.DetalleLotes.Where(l=> l.IdCerda ==DCerda).FirstOrDefault();
                db.DetalleLotes.Remove(tblDetalleLote);
                db.SaveChanges();
            }
            
            db.Lotes.Remove(tblLotes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CargarLote()
        {
            ViewBag.Cerda = db.Cerdas.Where(h => h.Estado == "Vacía");
            ViewBag.Varraco = db.Varracos;
            ViewBag.Detalle = db.DetalleLotes.Where(h => h.IdLote == 12).Include(t => t.Varracos).Include(t => t.Cerdas).ToList();

            return View();
        }
        public JsonResult CrearLote(int NumLote,DateTime Fecha)
        {
            try
            {
                var Lotes = new tblLotes
                {
                    NumLote = NumLote,
                    Estado = "En Proceso",
                    FechaRegistro = Fecha
                };
                db.Lotes.Add(Lotes);
                db.SaveChanges();
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public JsonResult CargarLote(int IdCerda,int IdVarraco, DateTime FechaInceminacion,
            DateTime FechaParto, DateTime Vacuna1, DateTime Vacunap, DateTime Vacuna2,string Observacion)
        {
            try
            {
                var idlote = (from id in db.Lotes select id.IdLote).Max();
                var DLotes = new tblDetalleLote
                {
                    IdCerda = IdCerda,
                    IdVarraco = IdVarraco,
                    IdLote = idlote,
                    FechaInseminacion = FechaInceminacion,
                    FechaParto = FechaParto,
                    Fvacuna1 = Vacuna1
                };
                var Cerda = db.Cerdas.Where(C => C.IdCerda == IdCerda).FirstOrDefault();
                if(Cerda.NumParto == 0)
                {
                    DLotes.Fvacuna15 = Vacunap;
                }else
                {
                    DLotes.Fvacuna15 = null;
                }
                DLotes.Fvacuna2 = Vacuna2;
                DLotes.Observaciones = Observacion;
                DLotes.Estado = "En Proceso";
                DLotes.FechaRegistro = DateTime.Now;
                Cerda.Estado = "Inseminación";
                db.Entry(Cerda).State = EntityState.Modified;
                db.DetalleLotes.Add(DLotes);
                db.SaveChanges();
                return Json(true);
                //var Cerdas = new tblCerdas();
                //Cerdas.Estado = "Proceso".Where()

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Json(false);
            }
            
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
