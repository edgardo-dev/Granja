namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblCerdas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCerdas()
        {
            tblControlLechones = new HashSet<tblControlLechones>();
            tblDetalleLotes = new HashSet<tblDetalleLotes>();
            tblFichas = new HashSet<tblFichas>();
            tblVacunas = new HashSet<tblVacunas>();
        }

        [Key]
        public int IdCerda { get; set; }

        [Required]
        [StringLength(8)]
        public string NumCerda { get; set; }

        public string Procedencia { get; set; }

        public string Observaciones { get; set; }

        public int NumParto { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string Estado { get; set; }

        public int IdGenetica { get; set; }

        public virtual tblGeneticas tblGeneticas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblControlLechones> tblControlLechones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDetalleLotes> tblDetalleLotes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFichas> tblFichas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVacunas> tblVacunas { get; set; }
    }
}
