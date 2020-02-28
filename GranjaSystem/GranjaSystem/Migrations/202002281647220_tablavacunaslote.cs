namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablavacunaslote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblVacunasLotes",
                c => new
                    {
                        IdVacunaLote = c.Int(nullable: false, identity: true),
                        IdLote = c.Int(nullable: false),
                        FechaVacuna = c.DateTime(nullable: false),
                        Vacuna = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdVacunaLote)
                .ForeignKey("dbo.tblLotes", t => t.IdLote, cascadeDelete: true)
                .Index(t => t.IdLote);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblVacunasLotes", "IdLote", "dbo.tblLotes");
            DropIndex("dbo.tblVacunasLotes", new[] { "IdLote" });
            DropTable("dbo.tblVacunasLotes");
        }
    }
}
