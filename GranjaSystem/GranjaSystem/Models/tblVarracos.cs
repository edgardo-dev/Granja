using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblVarracos
    {
        [Key]
        public int IdVarraco { get; set; }
        public int NumVarraco { get; set; }
        public string Procedencia { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }

        //relacion
        public int IdGenetica { get; set; }
        public virtual tblGeneticas Genetica { get; set; }
    }
}