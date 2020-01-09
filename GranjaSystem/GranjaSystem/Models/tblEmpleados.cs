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
        [Display(Name = "Nombres del Empleado")]
        public string NombreEmpleado { get; set; }
        [Display(Name = "Apellidos del Empleado")]
        public string ApellidoEmpleado { get; set; }
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }

        [Editable(allowEdit:false)]
        public DateTime FehaRegistro { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual List<tblUsuarios> Usuarios { get; set; }
    }
}