namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblLechones
    {
        [Key]
        public int IdLechones { get; set; }

        public int NumLote { get; set; }

        public int Edad { get; set; }

        public int NCerdos { get; set; }

        public int NCerdas { get; set; }

        public int NVarracos { get; set; }

        public string Fases { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; }

        public decimal qqDiarios { get; set; }

        public decimal qqSemanal { get; set; }
    }
}
