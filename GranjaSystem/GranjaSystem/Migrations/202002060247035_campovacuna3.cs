namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campovacuna3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna15", c => c.String());
            AlterColumn("dbo.tblFichas", "NacidosVivos", c => c.Int(nullable: true));
            AlterColumn("dbo.tblFichas", "NacidosMuertos", c => c.Int(nullable: true));
            AlterColumn("dbo.tblFichas", "NacidosMomias", c => c.Int(nullable: true));
            AlterColumn("dbo.tblFichas", "TotalNacidos", c => c.Int(nullable: true));
            AlterColumn("dbo.tblFichas", "PesoPromedio1D", c => c.Int(nullable: true));
            AlterColumn("dbo.tblFichas", "NumDestetado", c => c.Int(nullable: true));
            AlterColumn("dbo.tblFichas", "PesoPromedio28D", c => c.Int(nullable: true));

        }
        
        public override void Down()
        {
            DropColumn("dbo.tblDetalleLotes", "Fvacuna15");
        }
    }
}
