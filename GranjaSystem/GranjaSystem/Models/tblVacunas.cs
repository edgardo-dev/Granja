using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblVacunas
    {
        [Key]
        public int IdVacuna { get; set; }

        //relacion
        public int IdCerda { get; set; }
        public virtual tblCerdas Cerdas { get; set; }

        public DateTime FechaRegistro { get; set; }
        public DateTime FechaInyeccion { get; set; }
        public string Vacuna { get; set; }
        public string Descripcion { get; set; }

    }
}