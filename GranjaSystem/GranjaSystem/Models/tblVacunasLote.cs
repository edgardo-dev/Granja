using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblVacunasLote
    {
        [Key]
        public int IdVacunaLote { get; set; }

        //relacion
        public int IdLote { get; set; }
        public virtual tblLotes Lotes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaVacuna { get; set; }
        public string Vacuna { get; set; }
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
    }
}