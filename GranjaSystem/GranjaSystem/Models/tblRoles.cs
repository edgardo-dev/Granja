using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class tblRoles
    {
        [Key]
        public int IdRole { get; set; }
        public string Rol { get; set; }
        public string Descripcion { get; set; }
    }
}