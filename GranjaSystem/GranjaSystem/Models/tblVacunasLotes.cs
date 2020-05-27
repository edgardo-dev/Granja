namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblVacunasLotes
    {
        [Key]
        public int IdVacunaLote { get; set; }

        public int IdLote { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaVacuna { get; set; }

        public string Vacuna { get; set; }

        public string Descripcion { get; set; }

        public virtual tblLotes tblLotes { get; set; }
    }
}
