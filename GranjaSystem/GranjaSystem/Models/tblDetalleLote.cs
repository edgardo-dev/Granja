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
        public int IdDLote { get; set; }

        //relacion
        public int IdCerda { get; set; }
        public virtual tblCerdas Cerdas { get; set; }

        public string FechaInseminacion { get; set; }
        public string FechaParto { get; set; }

        //relacion
        public int IdVarraco { get; set; }
        public virtual tblVarracos Varracos { get; set; }

        public string Fvacuna1 { get; set; }
        public string Fvacuna15 { get; set; }
        public string Fvacuna20 { get; set; }
        public string Fvacuna2 { get; set; }
        public string Observaciones { get; set; }

        [Editable(allowEdit: false)]
        public DateTime FechaRegistro { get; set; }

        //relacion
        public int IdLote { get; set; }
        public virtual tblLotes Lotes { get; set; }

        public string Estado { get; set; }

        
    }
}