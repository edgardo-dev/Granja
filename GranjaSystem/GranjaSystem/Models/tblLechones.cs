using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblLechones
    {
        [Key]
        public int IdLechones { get; set; }
        [Display(Name = "Lote")]
        public int NumLote { get; set; }
        
        public int Edad { get; set; }
        [Display(Name = "Cerdos")]
        public int NCerdos { get; set; }
        [Display(Name = "Cerdas")]
        public int NCerdas { get; set; }
        [Display(Name = "Varracos")]
        public int NVarracos { get; set; }
        public string Fases { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaInicio { get; set; }
        [Editable(allowEdit: false)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
    }
}