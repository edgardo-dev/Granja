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

        // GET: Lotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lotes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLote,NumLote,FechaRegistro,Estado")] tblLotes tblLotes)
        {
            if (ModelState.IsValid)
            {
                tblLotes.FechaRegistro = DateTime.Now;
                db.Lotes.Add(tblLotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
        public ActionResult Edit([Bind(Include = "IdLote,NumLote,FechaRegistro,Estado")] tblLotes tblLotes)
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

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLotes tblLotes = db.Lotes.Find(id);
            db.Lotes.Remove(tblLotes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CargarLote()
        {
            ViewBag.Cerda = db.Cerdas.Where(h => h.Estado == "Disponible");
            ViewBag.Varraco = db.Varracos;
            ViewBag.Detalle = db.DetalleLotes.Where(h => h.IdLote == 12).Include(t => t.Varracos).Include(t => t.Cerdas).ToList();

            return View();
        }
        public JsonResult CrearLote(int NumLote)
        {
            try
            {
                var Lotes = new tblLotes();
                Lotes.NumLote = NumLote;
                Lotes.Estado = "Iniciado";
                Lotes.FechaRegistro = DateTime.Now;
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
        public JsonResult CargarLote(int NumLote,int IdCerda,int IdVarraco,string FechaInceminacion,
            string FechaParto, string Vacuna1, string Vacuna2,string Observacion)
        {
            try
            {
                var idlote = (from id in db.Lotes select id.IdLote).Max();
                var DLotes = new tblDetalleLote();
                DLotes.IdCerda = IdCerda;
                DLotes.IdVarraco = IdVarraco;
                DLotes.IdLote = idlote;
                DLotes.FechaInseminacion = FechaInceminacion;
                DLotes.FechaParto = FechaParto;
                DLotes.Fvacuna1 = Vacuna1;
                DLotes.Fvacuna2 = Vacuna2;
                DLotes.Observaciones = Observacion;
                DLotes.Estado = "Iniciado";
                DLotes.FechaRegistro = DateTime.Now;
                
                var Cerda = (from C in db.Cerdas
                                where C.IdCerda == IdCerda
                                select C).FirstOrDefault();
                Cerda.Estado = "Proceso";
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
