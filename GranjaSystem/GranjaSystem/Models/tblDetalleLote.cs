using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblDetalleLote
    {
        [Key]
        public int IdDLotes { get; set; }

        //relacion
        public int IdCerda { get; set; }
        public virtual tblCerdas Cerdas { get; set; }

        public DateTime FechaInseminacion { get; set; }
        public DateTime FechaParto { get; set; }

        //relacion
        public int IdVarroco { get; set; }
        public virtual tblVarracos Varracos { get; set; }

        public DateTime Fvacuna1 { get; set; }
        public DateTime Fvacuna2 { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }

        //relacion
        public int IdLotes { get; set; }
        public virtual tblLotes Lotes { get; set; }

        public string Estado { get; set; }
    }
}