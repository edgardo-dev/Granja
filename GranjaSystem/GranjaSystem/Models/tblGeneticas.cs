using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblGeneticas
    {
        [Key]
        public int IdGenetica { get; set; }
        public string Genetica { get; set; }
        public string Observacion { get; set; }
    }
}