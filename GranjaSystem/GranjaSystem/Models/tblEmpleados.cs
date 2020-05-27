namespace GranjaSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblEmpleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmpleados()
        {
            tblFichas = new HashSet<tblFichas>();
            tblUsuarios = new HashSet<tblUsuarios>();
        }

        [Key]
        public int IdEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public string ApellidoEmpleado { get; set; }

        public int? Telefono { get; set; }

        public string DUI { get; set; }

        public string NIT { get; set; }

        public DateTime FechaRegistro { get; set; }

        public string FechaNacimiento { get; set; }

        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFichas> tblFichas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuarios> tblUsuarios { get; set; }
    }
}
