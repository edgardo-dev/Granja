namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposfichas : DbMigration
    {
        public override void Up()
        {
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
                        NacidosVivos = c.Int(),
                        NacidosMuertos = c.Int(),
                        NacidosMomias = c.Int(),
                        TotalNacidos = c.Int(),
                        PesoPromedio1D = c.Double(),
                        NumDestetado = c.Int(),
                        PesoPromedio28D = c.Double(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFichas", "IdVarraco", "dbo.tblVarracos");
            DropForeignKey("dbo.tblFichas", "IdEmpleado", "dbo.tblEmpleados");
            DropForeignKey("dbo.tblFichas", "IdCerda", "dbo.tblCerdas");
            DropIndex("dbo.tblFichas", new[] { "IdEmpleado" });
            DropIndex("dbo.tblFichas", new[] { "IdVarraco" });
            DropIndex("dbo.tblFichas", new[] { "IdCerda" });
            DropTable("dbo.tblFichas");
        }
    }
}
