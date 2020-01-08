using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblUsuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
     
        public int IdEmpleados { get; set; }
        public virtual tblEmpleados Empleados { get; set; }

        public int IdRoles { get; set; }
        public virtual tblRoles Roles { get; set; }
       
    }
}