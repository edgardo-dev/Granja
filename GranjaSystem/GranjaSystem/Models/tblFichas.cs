using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblFichas
    {
        [Key]
        public int IdFicha { get; set; }

        //relacion
        public int IdCerda { get; set; }
        public virtual tblCerdas Cerdas { get; set; }

        public int NumParto { get; set; }
        public string FechaServio { get; set; }

        // relacion 
        public int IdVarraco { get; set; }
        public virtual tblVarracos Varracos { get; set; }

        public string FechaParto { get; set; }
        [Required(AllowEmptyStrings =true)]
        public int NacidosVivos { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int NacidosMuertos { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int NacidosMomias { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int TotalNacidos { get; set; }
        [Required(AllowEmptyStrings = true)]
        public double PesoPromedio1D { get; set; }
        [Required(AllowEmptyStrings = true)]
        public int NumDestetado { get; set; }
        [Required(AllowEmptyStrings = true)]
        public double PesoPromedio28D { get; set; }
        public string FechaDestete { get; set; }
        
        //Relacion 
        public int IdEmpleado { get; set; }
        public virtual tblEmpleados Empleados { get; set; }


    }
}