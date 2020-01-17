namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasePorcina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCerdas",
                c => new
                    {
                        IdCerda = c.Int(nullable: false, identity: true),
                        NumCerda = c.Int(nullable: false),
                        Procedencia = c.String(),
                        Observaciones = c.String(),
                        NumParto = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(),
                        IdGenetica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCerda)
                .ForeignKey("dbo.tblGeneticas", t => t.IdGenetica, cascadeDelete: true)
                .Index(t => t.IdGenetica);
            
            CreateTable(
                "dbo.tblGeneticas",
                c => new
                    {
                        IdGenetica = c.Int(nullable: false, identity: true),
                        Genetica = c.String(),
                        Observacion = c.String(),
                    })
                .PrimaryKey(t => t.IdGenetica);
            
            CreateTable(
                "dbo.tblVarracos",
                c => new
                    {
                        IdVarraco = c.Int(nullable: false, identity: true),
                        NumVarraco = c.Int(nullable: false),
                        Procedencia = c.String(),
                        Observaciones = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(),
                        IdGenetica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdVarraco)
                .ForeignKey("dbo.tblGeneticas", t => t.IdGenetica, cascadeDelete: true)
                .Index(t => t.IdGenetica);
            
            CreateTable(
                "dbo.tblDetalleLotes",
                c => new
                    {
                        IdDLote = c.Int(nullable: false, identity: true),
                        IdCerda = c.Int(nullable: false),
                        FechaInseminacion = c.String(),
                        FechaParto = c.String(),
                        IdVarraco = c.Int(nullable: false),
                        Fvacuna1 = c.String(),
                        Fvacuna2 = c.String(),
                        Observaciones = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        IdLote = c.Int(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdDLote)
                .ForeignKey("dbo.tblCerdas", t => t.IdCerda, cascadeDelete: true)
                .ForeignKey("dbo.tblLotes", t => t.IdLote, cascadeDelete: true)
                .ForeignKey("dbo.tblVarracos", t => t.IdVarraco, cascadeDelete: false)
                .Index(t => t.IdCerda)
                .Index(t => t.IdVarraco)
                .Index(t => t.IdLote);
            
            CreateTable(
                "dbo.tblLotes",
                c => new
                    {
                        IdLote = c.Int(nullable: false, identity: true),
                        NumLote = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdLote);
            
            CreateTable(
                "dbo.tblFichas",
                c => new
                    {
                        IdFicha = c.Int(nullable: false, identity: true),
                        IdCerda = c.Int(nullable: false),
                        NumParto = c.Int(nullable: false),
                        FechaServio = c.String(),
                        IdVarraco = c.Int(nullable: false),
                        FechaParto = c.String(),
                        NacidosVivos = c.Int(nullable: false),
                        NacidosMuertos = c.Int(nullable: false),
                        NacidosMomias = c.Int(nullable: false),
                        TotalNacidos = c.Int(nullable: false),
                        PesoPromedio1D = c.Double(nullable: false),
                        NumDestetado = c.Int(nullable: false),
                        PesoPromedio28D = c.Double(nullable: false),
                        FechaDestete = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdFicha)
                .ForeignKey("dbo.tblCerdas", t => t.IdCerda, cascadeDelete: true)
                .ForeignKey("dbo.tblEmpleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.tblVarracos", t => t.IdVarraco, cascadeDelete: false)
                .Index(t => t.IdCerda)
                .Index(t => t.IdVarraco)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.tblEmpleados",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(),
                        ApellidoEmpleado = c.String(),
                        Telefono = c.Int(nullable: false),
                        DUI = c.String(),
                        NIT = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaNacimiento = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.tblUsuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Clave = c.String(),
                        IdEmpleado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUsuario)
                .ForeignKey("dbo.tblEmpleados", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.tblRoles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Rol = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdRol);
            
            CreateTable(
                "dbo.tblControlLechones",
                c => new
                    {
                        IdControlL = c.Int(nullable: false, identity: true),
                        IdLotes = c.Int(nullable: false),
                        FechaDestete = c.String(),
                        IdCerda = c.Int(nullable: false),
                        TotalLechones = c.Int(nullable: false),
                        PesoPromedioL = c.Double(nullable: false),
                        Lotes_IdLote = c.Int(),
                    })
                .PrimaryKey(t => t.IdControlL)
                .ForeignKey("dbo.tblCerdas", t => t.IdCerda, cascadeDelete: true)
                .ForeignKey("dbo.tblLotes", t => t.Lotes_IdLote)
                .Index(t => t.IdCerda)
                .Index(t => t.Lotes_IdLote);
            
            CreateTable(
                "dbo.tblVacunas",
                c => new
                    {
                        IdVacuna = c.Int(nullable: false, identity: true),
                        IdCerda = c.Int(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        FechaInyeccion = c.String(),
                        Vacuna = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdVacuna)
                .ForeignKey("dbo.tblCerdas", t => t.IdCerda, cascadeDelete: true)
                .Index(t => t.IdCerda);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblVacunas", "IdCerda", "dbo.tblCerdas");
            DropForeignKey("dbo.tblControlLechones", "Lotes_IdLote", "dbo.tblLotes");
            DropForeignKey("dbo.tblControlLechones", "IdCerda", "dbo.tblCerdas");
            DropForeignKey("dbo.tblCerdas", "IdGenetica", "dbo.tblGeneticas");
            DropForeignKey("dbo.tblVarracos", "IdGenetica", "dbo.tblGeneticas");
            DropForeignKey("dbo.tblFichas", "IdVarraco", "dbo.tblVarracos");
            DropForeignKey("dbo.tblFichas", "IdEmpleado", "dbo.tblEmpleados");
            DropForeignKey("dbo.tblUsuarios", "IdRol", "dbo.tblRoles");
            DropForeignKey("dbo.tblUsuarios", "IdEmpleado", "dbo.tblEmpleados");
            DropForeignKey("dbo.tblFichas", "IdCerda", "dbo.tblCerdas");
            DropForeignKey("dbo.tblDetalleLotes", "IdVarraco", "dbo.tblVarracos");
            DropForeignKey("dbo.tblDetalleLotes", "IdLote", "dbo.tblLotes");
            DropForeignKey("dbo.tblDetalleLotes", "IdCerda", "dbo.tblCerdas");
            DropIndex("dbo.tblVacunas", new[] { "IdCerda" });
            DropIndex("dbo.tblControlLechones", new[] { "Lotes_IdLote" });
            DropIndex("dbo.tblControlLechones", new[] { "IdCerda" });
            DropIndex("dbo.tblUsuarios", new[] { "IdRol" });
            DropIndex("dbo.tblUsuarios", new[] { "IdEmpleado" });
            DropIndex("dbo.tblFichas", new[] { "IdEmpleado" });
            DropIndex("dbo.tblFichas", new[] { "IdVarraco" });
            DropIndex("dbo.tblFichas", new[] { "IdCerda" });
            DropIndex("dbo.tblDetalleLotes", new[] { "IdLote" });
            DropIndex("dbo.tblDetalleLotes", new[] { "IdVarraco" });
            DropIndex("dbo.tblDetalleLotes", new[] { "IdCerda" });
            DropIndex("dbo.tblVarracos", new[] { "IdGenetica" });
            DropIndex("dbo.tblCerdas", new[] { "IdGenetica" });
            DropTable("dbo.tblVacunas");
            DropTable("dbo.tblControlLechones");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblUsuarios");
            DropTable("dbo.tblEmpleados");
            DropTable("dbo.tblFichas");
            DropTable("dbo.tblLotes");
            DropTable("dbo.tblDetalleLotes");
            DropTable("dbo.tblVarracos");
            DropTable("dbo.tblGeneticas");
            DropTable("dbo.tblCerdas");
        }
    }
}
