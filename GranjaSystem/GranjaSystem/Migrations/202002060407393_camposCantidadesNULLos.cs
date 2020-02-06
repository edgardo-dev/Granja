namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposCantidadesNULLos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblFichas", "IdCerda", "dbo.tblCerdas");
            DropForeignKey("dbo.tblFichas", "IdEmpleado", "dbo.tblEmpleados");
            DropForeignKey("dbo.tblFichas", "IdVarraco", "dbo.tblVarracos");
            DropIndex("dbo.tblFichas", new[] { "IdCerda" });
            DropIndex("dbo.tblFichas", new[] { "IdVarraco" });
            DropIndex("dbo.tblFichas", new[] { "IdEmpleado" });
            DropTable("dbo.tblFichas");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.IdFicha);
            
            CreateIndex("dbo.tblFichas", "IdEmpleado");
            CreateIndex("dbo.tblFichas", "IdVarraco");
            CreateIndex("dbo.tblFichas", "IdCerda");
            AddForeignKey("dbo.tblFichas", "IdVarraco", "dbo.tblVarracos", "IdVarraco", cascadeDelete: true);
            AddForeignKey("dbo.tblFichas", "IdEmpleado", "dbo.tblEmpleados", "IdEmpleado", cascadeDelete: true);
            AddForeignKey("dbo.tblFichas", "IdCerda", "dbo.tblCerdas", "IdCerda", cascadeDelete: true);
        }
    }
}
