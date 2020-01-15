using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblControlLechones
    {
        [Key]
        public int IdControlL { get; set; }

        //relacion
        public int IdLotes { get; set; }
        public virtual tblLotes Lotes { get; set; }

        public string FechaDestete { get; set; }

        // Relacion 
        public int IdCerda { get; set; }
        public virtual tblCerdas Cerdas { get; set; }

        public int TotalLechones { get; set; }
        public double PesoPromedioL { get; set; }

    }
}