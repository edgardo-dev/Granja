namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblVacunas
    {
        [Key]
        public int IdVacuna { get; set; }

        public int IdCerda { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string FechaInyeccion { get; set; }

        public string Vacuna { get; set; }

        public string Descripcion { get; set; }

        public virtual tblCerdas tblCerdas { get; set; }
    }
}
