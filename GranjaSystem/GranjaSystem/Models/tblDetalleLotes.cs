//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDetalleLotes
    {
        public int IdDLote { get; set; }
        public int IdCerda { get; set; }
        public System.DateTime FechaInseminacion { get; set; }
        public System.DateTime FechaParto { get; set; }
        public int IdVarraco { get; set; }
        public System.DateTime Fvacuna1 { get; set; }
        public System.DateTime Fvacuna2 { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int IdLote { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> Fvacuna15 { get; set; }
    
        public virtual tblCerdas tblCerdas { get; set; }
        public virtual tblLotes tblLotes { get; set; }
        public virtual tblVarracos tblVarracos { get; set; }
    }
}