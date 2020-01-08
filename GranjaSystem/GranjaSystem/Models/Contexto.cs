using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GranjaSystem.Models
{
    public class Contexto : DbContext
    {
        public DbSet<tblEmpleados> Empleados { get; set; }
        public DbSet<tblRoles> Roles { get; set; }
        public DbSet<tblUsuarios> Usuarios { get; set; }

    }
}