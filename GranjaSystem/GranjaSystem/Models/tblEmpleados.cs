using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblEmpleados
    {
       [Key]
        public int IdEmpleado { get; set; }
        [Display(Name = "Nombres del Empleado")]
        public string NombreEmpleado { get; set; }
        [Display(Name = "Apellidos del Empleado")]
        public string ApellidoEmpleado { get; set; }
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }

        [Editable(allowEdit:false)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Fecha Nacimiento")]

        public string FechaNacimiento { get; set; }
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        public virtual List<tblUsuarios> Usuarios { get; set; }
    }
}