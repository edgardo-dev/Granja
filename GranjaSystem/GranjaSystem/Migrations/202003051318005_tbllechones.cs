namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbllechones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblLechones",
                c => new
                    {
                        IdLechones = c.Int(nullable: false, identity: true),
                        NumLote = c.Int(nullable: false),
                        Edad = c.Int(nullable: false),
                        NCerdos = c.Int(nullable: false),
                        NCerdas = c.Int(nullable: false),
                        NVarracos = c.Int(nullable: false),
                        Fases = c.String(),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdLechones);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblLechones");
        }
    }
}
