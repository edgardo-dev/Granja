namespace GranjaSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BDGranja : DbContext
    {
        public BDGranja()
            : base("name=Contextos")
        {
        }

        public virtual DbSet<tblCerdas> tblCerdas { get; set; }
        public virtual DbSet<tblControlLechones> tblControlLechones { get; set; }
        public virtual DbSet<tblDetalleLotes> tblDetalleLotes { get; set; }
        public virtual DbSet<tblEmpleados> tblEmpleados { get; set; }
        public virtual DbSet<tblFichas> tblFichas { get; set; }
        public virtual DbSet<tblGeneticas> tblGeneticas { get; set; }
        public virtual DbSet<tblLechones> tblLechones { get; set; }
        public virtual DbSet<tblLotes> tblLotes { get; set; }
        public virtual DbSet<tblRoles> tblRoles { get; set; }
        public virtual DbSet<tblUsuarios> tblUsuarios { get; set; }
        public virtual DbSet<tblVacunas> tblVacunas { get; set; }
        public virtual DbSet<tblVacunasLotes> tblVacunasLotes { get; set; }
        public virtual DbSet<tblVarracos> tblVarracos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCerdas>()
                .Property(e => e.NumCerda)
                .IsUnicode(false);

            modelBuilder.Entity<tblLotes>()
                .HasMany(e => e.tblControlLechones)
                .WithOptional(e => e.tblLotes)
                .HasForeignKey(e => e.Lotes_IdLote);

            modelBuilder.Entity<tblVarracos>()
                .HasMany(e => e.tblDetalleLotes)
                .WithRequired(e => e.tblVarracos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblVarracos>()
                .HasMany(e => e.tblFichas)
                .WithRequired(e => e.tblVarracos)
                .WillCascadeOnDelete(false);
        }
    }
}
