namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblVarracos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblVarracos()
        {
            tblDetalleLotes = new HashSet<tblDetalleLotes>();
            tblFichas = new HashSet<tblFichas>();
        }

        [Key]
        public int IdVarraco { get; set; }

        public int NumVarraco { get; set; }

        public string Procedencia { get; set; }

        public string Observaciones { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; }

        public int IdGenetica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDetalleLotes> tblDetalleLotes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFichas> tblFichas { get; set; }

        public virtual tblGeneticas tblGeneticas { get; set; }
    }
}
