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
        public ActionResult Index(string pass, string username)
        {
            var Db = new Contexto();
            string nPass = Encriptar(pass);
            var Login = (from L in Db.Usuarios
                         where L.Usuario == username && L.Clave == nPass
                         select L).FirstOrDefault();

            if (Login == null)
            {
                ViewBag.Bandera = true;
                ViewBag.Mensaje = "Datos incorrectos.";
                return View();
            }
            else
            {
                Session["IdUsuario"] = Login.IdUsuario;
                Session["Nombre"] = Login.Empleados.NombreEmpleado + " " + Login.Empleados.ApellidoEmpleado;
                Session["Rol"] = Login.Roles.Rol;
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