using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblLotes
    {
        [Key]
        public int IdLote { get; set; }
        public int NumLote  { get; set; }
        [Editable(allowEdit: false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }

    }
}