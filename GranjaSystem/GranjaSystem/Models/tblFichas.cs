namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblFichas
    {
        [Key]
        public int IdFicha { get; set; }

        public int IdCerda { get; set; }

        public int NumParto { get; set; }

        public string FechaServio { get; set; }

        public int IdVarraco { get; set; }

        public string FechaParto { get; set; }

        public int? NacidosVivos { get; set; }

        public int? NacidosMuertos { get; set; }

        public int? NacidosMomias { get; set; }

        public int? TotalNacidos { get; set; }

        public decimal? PesoPromedio1D { get; set; }

        public int? NumDestetado { get; set; }

        public decimal? PesoPromedio28D { get; set; }

        public string FechaDestete { get; set; }

        public int IdEmpleado { get; set; }

        public int? Lote { get; set; }

        public virtual tblCerdas tblCerdas { get; set; }

        public virtual tblEmpleados tblEmpleados { get; set; }

        public virtual tblVarracos tblVarracos { get; set; }
    }
}
