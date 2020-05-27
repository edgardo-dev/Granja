namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblDetalleLotes
    {
        [Key]
        public int IdDLote { get; set; }
        public int IdCerda { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInseminacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaParto { get; set; }
        public int IdVarraco { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fvacuna1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fvacuna2 { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdLote { get; set; }
        public string Estado { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fvacuna15 { get; set; }

        public virtual tblCerdas tblCerdas { get; set; }

        public virtual tblLotes tblLotes { get; set; }

        public virtual tblVarracos tblVarracos { get; set; }
    }
}
