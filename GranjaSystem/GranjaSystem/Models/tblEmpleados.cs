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
        public int IdEmpleados { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int Telefono { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public DateTime FehaRegistro { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }

        public virtual List<tblUsuarios> Usuarios { get; set; }
    }
}