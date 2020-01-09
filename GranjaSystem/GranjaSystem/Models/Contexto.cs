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
        public DbSet<tblCerdas> Cerdas { get; set; }
        public DbSet<tblVarracos> Varrocos { get; set; }
        public DbSet<tblGeneticas> Geneticas { get; set; }
        public DbSet<tblLotes> Lotes { get; set; }
        public DbSet<tblDetalleLote> DetalleLotes { get; set; }
        public DbSet<tblVacunas> Vacunas { get; set; }
        public DbSet<tblFichas> Fichas { get; set; }
        public DbSet<tblControlLechones> ControlLechones { get; set; }
    }
}