namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblControlLechones
    {
        [Key]
        public int IdControlL { get; set; }

        public int IdLotes { get; set; }

        public string FechaDestete { get; set; }

        public int IdCerda { get; set; }

        public int TotalLechones { get; set; }

        public double PesoPromedioL { get; set; }

        public int? Lotes_IdLote { get; set; }

        public virtual tblCerdas tblCerdas { get; set; }

        public virtual tblLotes tblLotes { get; set; }
    }
}
