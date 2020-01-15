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

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        [Display(Name = "Nombre del Empleado")]
        public int IdEmpleado { get; set; }
        public virtual tblEmpleados Empleados { get; set; }
        [Display(Name = "Rol del Empleado")]
        public int IdRol { get; set; }
        public virtual tblRoles Roles { get; set; }
       
    }
}