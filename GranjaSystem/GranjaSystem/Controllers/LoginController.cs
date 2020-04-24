using GranjaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace GranjaSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string inputUser, string inputPassword)
        {
            var Db = new DB_A460EB_PruebasNGS2Entities();
            string nPass = Encriptar(inputPassword);
            var Login = (from L in Db.Usuarios
                         where L.Usuario == inputUser && L.Clave == nPass
                         select L).FirstOrDefault();

            if (Login == null)
            {
                
                ViewBag.Mensaje = "Datos incorrectos.";
                ViewBag.Clase = "alert alert-danger";
                return View();
            }
            else
            {
                Session["IdUsuario"] = Login.IdUsuario;
                Session["Nombre"] = Login.tblEmpleados.NombreEmpleado + " " + Login.tblEmpleados.ApellidoEmpleado;
                Session["Rol"] = Login.tblRoles.Rol;
                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpGet]
        public ActionResult Salir()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
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