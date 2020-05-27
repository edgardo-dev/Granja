namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUsuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }

        public int IdEmpleado { get; set; }

        public int IdRol { get; set; }

        public virtual tblEmpleados tblEmpleados { get; set; }

        public virtual tblRoles tblRoles { get; set; }
    }
}
