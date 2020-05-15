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
             private BDGranja db = new BDGranja();

        // GET: DetalleLotes
        public ActionResult Index(int? id)
        {

            if (Session["IdUsuario"] != null)
            {
                ViewBag.id = id;
                int? Lechones = 0;

                foreach (var item in db.tblFichas.Where(L => L.Lote == id))
                {
                    Lechones += item.NumDestetado;
                }
                ViewBag.TLechones = Lechones;
                ViewBag.VacunasLote = db.tblVacunasLotes.Where(h => h.IdLote == id).ToList();
                var detalleLotes = db.tblDetalleLotes.Where(L => L.IdLote == id).Include(t => t.tblLotes).Include(t => t.tblVarracos).Include(t => t.tblCerdas).ToList();
                ViewBag.Lote = db.tblLotes.Where(L => L.IdLote == id).FirstOrDefault();
                var detalleLotesF = db.tblDetalleLotes.Where(L => L.IdLote == id).Where(L => L.Estado == "Finalizado" || L.Estado == "Eliminada").Count();
                if (detalleLotes.Count() == detalleLotesF)
                {
                    tblLotes tblLotes = db.tblLotes.Find(id);
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
                 tblDetalleLotes tblDetalleLote = db.tblDetalleLotes.Find(id);
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
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote");
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda");
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco");
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
                    tblDetalleLote.FechaRegistro = DateTime.Now;
                    db.tblDetalleLotes.Add(tblDetalleLote);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
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
                tblDetalleLotes tblDetalleLote = db.tblDetalleLotes.Find(id);
                if (tblDetalleLote == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
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
                ViewBag.IdLote = new SelectList(db.tblLotes, "IdLote", "NumLote", tblDetalleLote.IdLote);
                ViewBag.IdCerda = new SelectList(db.tblCerdas, "IdCerda", "NumCerda", tblDetalleLote.IdCerda);
                ViewBag.IdVarraco = new SelectList(db.tblVarracos, "IdVarraco", "NumVarraco", tblDetalleLote.IdVarraco);
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
                tblDetalleLotes tblDetalleLote = db.tblDetalleLotes.Find(id);
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
                
                tblDetalleLotes tblDetalleLote = db.tblDetalleLotes.Find(id);

                var Cerda = (from C in db.tblCerdas
                             where C.IdCerda == idC
                              select C).FirstOrDefault();
                Cerda.Estado = "Vacía";
                db.Entry(Cerda).State = EntityState.Modified;
                db.tblDetalleLotes.Remove(tblDetalleLote);
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
               
                tblDetalleLotes tblDetalleLote = db.tblDetalleLotes.Find(id);
                tblCerdas tblCerda = db.tblCerdas.Find(idC);

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
