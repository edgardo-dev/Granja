using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using GranjaSystem.Models;

namespace GranjaSystem.Controllers
{
    public class UsuariosController : Controller
    {
             private BDGranja db = new BDGranja();

        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["IdUsuario"] != null)
            {
                var usuarios = db.tblUsuarios.Include(t => t.tblEmpleados).Include(t => t.tblRoles).Where(x=>x.IdEmpleado!=1);
                return View(usuarios.ToList());

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUsuarios tblUsuarios = db.tblUsuarios.Find(id);
                if (tblUsuarios == null)
                {
                    return HttpNotFound();
                }
                return View(tblUsuarios);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (Session["IdUsuario"] != null)
            {
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados.Where(x=>x.NombreEmpleado !="Pendiente"), "IdEmpleado", "NombreEmpleado");
                ViewBag.IdRol = new SelectList(db.tblRoles, "IdRol", "Rol");
                return View();

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleado,IdRol")] tblUsuarios tblUsuarios)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                    tblUsuarios.Clave = Encriptar(tblUsuarios.Clave);
                    db.tblUsuarios.Add(tblUsuarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados.Where(x => x.NombreEmpleado != "Pendiente"), "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
                ViewBag.IdRol = new SelectList(db.tblRoles, "IdRol", "Rol", tblUsuarios.IdRol);
                return View(tblUsuarios);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUsuarios tblUsuarios = db.tblUsuarios.Find(id);
                if (tblUsuarios == null)
                {
                    return HttpNotFound();
                }
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados.Where(x => x.NombreEmpleado != "Pendiente"), "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
                ViewBag.IdRol = new SelectList(db.tblRoles, "IdRol", "Rol", tblUsuarios.IdRol);
                return View(tblUsuarios);

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Usuario,Clave,IdEmpleado,IdRol")] tblUsuarios tblUsuarios)
        {
            if (Session["IdUsuario"] != null)
            {
                if (ModelState.IsValid)
                {
                    tblUsuarios.Clave = Encriptar(tblUsuarios.Clave);
                    db.Entry(tblUsuarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdEmpleado = new SelectList(db.tblEmpleados.Where(x => x.NombreEmpleado != "Pendiente"), "IdEmpleado", "NombreEmpleado", tblUsuarios.IdEmpleado);
                ViewBag.IdRol = new SelectList(db.tblRoles, "IdRol", "Rol", tblUsuarios.IdRol);
                return View(tblUsuarios);

            }
            else return RedirectToAction("Index", "Login");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["IdUsuario"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tblUsuarios tblUsuarios = db.tblUsuarios.Find(id);
                if (tblUsuarios == null)
                {
                    return HttpNotFound();
                }
                return View(tblUsuarios);

            }
            else return RedirectToAction("Index", "Login");
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["IdUsuario"] != null)
            {
                tblUsuarios tblUsuarios = db.tblUsuarios.Find(id);
                db.tblUsuarios.Remove(tblUsuarios);
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
        public string Encriptar(string Pass)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            Byte[] Hash, InsertarByte;
            InsertarByte = (new UnicodeEncoding()).GetBytes(Pass);
            Hash = sha1.ComputeHash(InsertarByte);
            return Convert.ToBase64String(Hash);
        }
    }

}
