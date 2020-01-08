using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblCerdas
    {
        public int IdCerda { get; set; }
        public int NumCerda { get; set; }
        public string Procedencia { get; set; }
        public string Observaciones { get; set; }
        public int NumParto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }


        //Relaciones Empleados
        public int IdGenetica { get; set; }
        public virtual tblGeneticas Genetica { get; set; }


    }
}