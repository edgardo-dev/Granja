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
    public class DetalleLotesController : Controller
    {
        private DB_A460EB_PruebasNGS2Entities db = new DB_A460EB_PruebasNGS2Entities();

        // GET: DetalleLotes
        public ActionResult Index(int? id)
        {

            if (Session["IdUsuario"] != null)
            {
                ViewBag.id = id;
                int? Lechones = 0;

                foreach (var item in db.Fichas.Where(L => L.Lote == id))
                {
                    Lechones += item.NumDestetado;
                }
                ViewBag.TLechones = Lechones;
                ViewBag.VacunasLote = db.VacunasLotes.Where(h => h.IdLote == id).ToList();
                var detalleLotes = db.DetalleLotes.Where(L => L.IdLote == id).Include(t => t.tblLotes).Include(t => t.tblVarracos).Include(t => t.tblCerdas).ToList();
                ViewBag.Lote = db.Lotes.Where(L => L.IdLote == id).FirstOrDefault();
                var detalleLotesF = db.DetalleLotes.Where(L => L.IdLote == id).Where(L => L.Estado == "Finalizado" || L.Estado == "Eliminada").Count();
                if (detalleLotes.Count() == detalleLotesF)
                {
                    tblLotes tblLotes = db.Lotes.Find(id);
                    tblLotes.Estado = "Finalizado";
                    db.Entry(tblLotes).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return View(detalleLotes);
            }
            else return RedirectToAction("Index", "Login");
           
        }

        // GET: DetalleLotes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                 tblDetalleLotes tblDetalleLote = db.DetalleLotes.Find(id);
                if (tblDetalleLote == null)
                {
                    return HttpNotFound();
                }
                return View(tblDetalleLote);
                
            }
             else return RedirectToAction("Index", "Login");
        }

        // GET: DetalleLotes/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote");
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda");
                ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco");
                return View();
                
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: DetalleLotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDLote,IdCerda,FechaInseminacion,FechaParto,IdVarraco,Fvacuna1,Fvacuna2,Observaciones,FechaRegistro,IdLote,Estado")] tblDetalleLotes tblDetalleLote)
        {
            if (Session["IdUsuario"] != null)
            {
                
                if (ModelState.IsValid)
                {
                    tblDetalleLote.FechaRegistro = DateTime.UtcNow;
                    db.DetalleLotes.Add(tblDetalleLote);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            
                ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
                ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
                return View(tblDetalleLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: DetalleLotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblDetalleLotes tblDetalleLote = db.DetalleLotes.Find(id);
                if (tblDetalleLote == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
                ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
                return View(tblDetalleLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: DetalleLotes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDLote,IdCerda,FechaInseminacion,FechaParto,IdVarraco,Fvacuna1,Fvacuna2,Observaciones,FechaRegistro,IdLote,Estado")] tblDetalleLotes tblDetalleLote)
        {
            if (Session["IdUsuario"] != null)
            {
                
                if (ModelState.IsValid)
                {
                    db.Entry(tblDetalleLote).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index" , "Lotes");
                }
                ViewBag.IdLote = new SelectList(db.Lotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
                ViewBag.IdCerda = new SelectList(db.Cerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
                ViewBag.IdVarraco = new SelectList(db.Varracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
                return View(tblDetalleLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: DetalleLotes/Delete/5
        public ActionResult Delete(int? id, int idC)
        {
            if (Session["IdUsuario"] != null)
            {
                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblDetalleLotes tblDetalleLote = db.DetalleLotes.Find(id);
                if (tblDetalleLote == null)
                {
                    return HttpNotFound();
                }
                return View(tblDetalleLote);
            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: DetalleLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int idC)
        {
            if (Session["IdUsuario"] != null)
            {
                
                tblDetalleLotes tblDetalleLote = db.DetalleLotes.Find(id);

                var Cerda = (from C in db.Cerdas
                              where C.IdCerda == idC
                              select C).FirstOrDefault();
                Cerda.Estado = "Vacía";
                db.Entry(Cerda).State = EntityState.Modified;
                db.DetalleLotes.Remove(tblDetalleLote);
                db.SaveChanges();
                return RedirectToAction("Index/"+tblDetalleLote.IdLote);
            }
            else return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public ActionResult Eliminar()
        {
            if (Session["IdUsuario"] != null)
            {
                return View();
              
            }
            else return RedirectToAction("Index", "Login");

        }
        [HttpPost]
        public ActionResult Eliminar(int? id, int idC,string Observaciones)
        {
            if (Session["IdUsuario"] != null)
            {
               
                tblDetalleLotes tblDetalleLote = db.DetalleLotes.Find(id);
                tblCerdas tblCerda = db.Cerdas.Find(idC);

                tblCerda.Estado = "Vacía";
                db.Entry(tblCerda).State = EntityState.Modified;
                tblDetalleLote.Estado ="Eliminada";
                tblDetalleLote.Observaciones = Observaciones;
                db.Entry(tblDetalleLote).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index/" + tblDetalleLote.IdLote);
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
