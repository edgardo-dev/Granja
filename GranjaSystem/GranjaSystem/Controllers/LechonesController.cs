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
    public class LechonesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Lechones
        public ActionResult Index()
        {
            var Lechones = db.Lechones.ToList();
            foreach (var item in Lechones)
            {
                item.Estado = "Engorde";
                TimeSpan dias = DateTime.Now.Date - item.FechaInicio;
                int diferencia = dias.Days;
                if (diferencia >= 0 && diferencia <= 7)
                {
                    item.Edad = 0;
                }
                else if (diferencia >= 8 && diferencia <= 14)
                {
                    item.Edad = 1;
                }
                else if (diferencia >= 15 && diferencia <= 21)
                {
                    item.Edad = 2;
                }
                else if (diferencia >= 22 && diferencia <= 28)
                {
                    item.Edad = 3;
                }
                else if (diferencia >= 29 && diferencia <= 35)
                {
                    item.Edad = 4;
                    item.Fases = "Binova 1";
                }
                else if (diferencia >= 36 && diferencia <= 42)
                {
                    item.Edad = 5;
                    item.Fases = "Binova 2";
                }
                else if (diferencia >= 43 && diferencia <= 49)
                {
                    item.Edad = 6;
                    item.Fases = "Binova 3";
                }
                else if (diferencia >= 50 && diferencia <= 56)
                {
                    item.Edad = 7;
                    item.Fases = "Inicio Crecimineto";
                }
                else if (diferencia >= 57 && diferencia <= 63)
                {
                    item.Edad = 8;
                    item.Fases = "Inicio Crecimineto";
                }
                else if (diferencia >= 64 && diferencia <= 70)
                {
                    item.Edad = 9;
                    item.Fases = "Inicio Crecimineto";
                }
                else if (diferencia >= 71 && diferencia <= 77)
                {
                    item.Edad = 10;
                    item.Fases = "Crecimineto";
                }
                else if (diferencia >= 78 && diferencia <= 84)
                {
                    item.Edad = 11;
                    item.Fases = "Crecimineto";
                }
                else if (diferencia >= 85 && diferencia <= 91)
                {
                    item.Edad = 12;
                    item.Fases = "Crecimineto";
                }
                else if (diferencia >= 92 && diferencia <= 98)
                {
                    item.Edad = 13;
                    item.Fases = "Desarrollo";
                }
                else if (diferencia >= 99 && diferencia <= 105)
                {
                    item.Edad = 14;
                    item.Fases = "Desarrollo";
                }
                else if (diferencia >= 106 && diferencia <= 112)
                {
                    item.Edad = 15;
                    item.Fases = "Normal";
                }
                else if (diferencia >= 113 && diferencia <= 119)
                {
                    item.Edad = 16;
                    item.Fases  = "Normal";
                }
                else if (diferencia >= 120 && diferencia <= 126)
                {
                    item.Edad = 17;
                    item.Fases = "Normal";
                }
                else if (diferencia >= 127 && diferencia <= 133)
                {
                    item.Edad = 18;
                    item.Fases = "Final";
                    item.Estado = "Disponible";
                }
                else if (diferencia >= 134 && diferencia <= 140)
                {
                    item.Edad = 19;
                    item.Fases = "Final";
                    item.Estado = "Disponible";
                }
                else if (diferencia >= 141 && diferencia <= 147)
                {
                    item.Edad = 20;
                    item.Fases = "Reemprozo";
                    item.Estado = "Disponible";
                }
                else if (diferencia >= 148 && diferencia <= 154)
                {
                    item.Edad = 21;
                    item.Fases = "Reemprozo";
                    item.Estado = "Disponible";
                }
                else if (diferencia >= 155 && diferencia <= 161)
                {
                    item.Edad = 22;
                    item.Fases = "Reemprozo";
                    item.Estado = "Disponible";
                }
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View(db.Lechones.ToList());
        }

        // GET: Lechones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLechones tblLechones = db.Lechones.Find(id);
            if (tblLechones == null)
            {
                return HttpNotFound();
            }
            return View(tblLechones);
        }

        // GET: Lechones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lechones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLechones,NumLote,Edad,NCerdos,NCerdas,NVarracos,Fases,FechaInicio,FechaRegistro,Estado")] tblLechones tblLechones)
        {
            if (ModelState.IsValid)
            {
                tblLechones.FechaRegistro = DateTime.Now;
                TimeSpan dias = DateTime.Now.Date - tblLechones.FechaInicio;
                int diferencia = dias.Days;
                if(diferencia >= 0 && diferencia <=7)
                {
                    tblLechones.Edad = 0;
                }
                else if (diferencia >= 8 && diferencia <= 14)
                {
                    tblLechones.Edad = 1;
                }
                else if (diferencia >= 15 && diferencia <= 21)
                {
                    tblLechones.Edad = 2;
                }
                else if (diferencia >= 22 && diferencia <= 28)
                {
                    tblLechones.Edad = 3;
                }
                else if (diferencia >= 29 && diferencia <= 35)
                {
                    tblLechones.Edad = 4;
                    tblLechones.Fases = "Binova 1";
                }
                else if (diferencia >= 36 && diferencia <= 42)
                {
                    tblLechones.Edad = 5;
                    tblLechones.Fases = "Binova 2";
                }
                else if (diferencia >= 43 && diferencia <= 49)
                {
                    tblLechones.Edad = 6;
                    tblLechones.Fases = "Binova 3";
                }
                else if (diferencia >= 50 && diferencia <= 56)
                {
                    tblLechones.Edad = 7;
                    tblLechones.Fases = "Inicio Crecimineto";
                }
                else if (diferencia >= 57 && diferencia <= 63)
                {
                    tblLechones.Edad = 8;
                    tblLechones.Fases = "Inicio Crecimineto";
                }
                else if (diferencia >= 64 && diferencia <= 70)
                {
                    tblLechones.Edad = 9;
                    tblLechones.Fases = "Inicio Crecimineto";
                }
                else if (diferencia >= 71 && diferencia <= 77)
                {
                    tblLechones.Edad = 10;
                    tblLechones.Fases = "Crecimineto";
                }
                else if (diferencia >= 78 && diferencia <= 84)
                {
                    tblLechones.Edad = 11;
                    tblLechones.Fases = "Crecimineto";
                }
                else if (diferencia >= 85 && diferencia <= 91)
                {
                    tblLechones.Edad = 12;
                    tblLechones.Fases = "Crecimineto";
                }
                else if (diferencia >= 92 && diferencia <= 98)
                {
                    tblLechones.Edad = 13;
                    tblLechones.Fases = "Desarrollo";
                }
                else if (diferencia >= 99 && diferencia <= 105)
                {
                    tblLechones.Edad = 14;
                    tblLechones.Fases = "Desarrollo";
                }
                else if (diferencia >= 106 && diferencia <= 112)
                {
                    tblLechones.Edad = 15;
                    tblLechones.Fases = "Normal";
                }
                else if (diferencia >= 113 && diferencia <= 119)
                {
                    tblLechones.Edad = 16;
                    tblLechones.Fases = "Normal";
                }
                else if (diferencia >= 120 && diferencia <= 126)
                {
                    tblLechones.Edad = 17;
                    tblLechones.Fases = "Normal";
                }
                else if (diferencia >= 127 && diferencia <= 133)
                {
                    tblLechones.Edad = 18;
                    tblLechones.Fases = "Final";
                }
                else if (diferencia >= 134 && diferencia <= 140)
                {
                    tblLechones.Edad = 19;
                    tblLechones.Fases = "Final";
                }
                else if (diferencia >= 141 && diferencia <= 147)
                {
                    tblLechones.Edad = 20;
                    tblLechones.Fases = "Reemprozo";
                }
                else if (diferencia >= 148 && diferencia <= 154)
                {
                    tblLechones.Edad = 21;
                    tblLechones.Fases = "Reemprozo";
                }
                else if (diferencia >= 155 && diferencia <= 161)
                {
                    tblLechones.Edad = 22;
                    tblLechones.Fases = "Reemprozo";
                }

                db.Lechones.Add(tblLechones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLechones);
        }

        // GET: Lechones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLechones tblLechones = db.Lechones.Find(id);
            if (tblLechones == null)
            {
                return HttpNotFound();
            }
            return View(tblLechones);
        }

        // POST: Lechones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLechones,NumLote,Edad,NCerdos,NCerdas,NVarracos,Fases,FechaInicio,FechaRegistro,Estado")] tblLechones tblLechones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLechones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLechones);
        }

        // GET: Lechones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLechones tblLechones = db.Lechones.Find(id);
            if (tblLechones == null)
            {
                return HttpNotFound();
            }
            return View(tblLechones);
        }

        // POST: Lechones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLechones tblLechones = db.Lechones.Find(id);
            db.Lechones.Remove(tblLechones);
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
