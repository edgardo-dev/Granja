namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullcerdos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblFichas", "NacidosVivos", c => c.Int());
            AlterColumn("dbo.tblFichas", "NacidosMuertos", c => c.Int());
            AlterColumn("dbo.tblFichas", "NacidosMomias", c => c.Int());
            AlterColumn("dbo.tblFichas", "TotalNacidos", c => c.Int());
            AlterColumn("dbo.tblFichas", "PesoPromedio1D", c => c.Double());
            AlterColumn("dbo.tblFichas", "NumDestetado", c => c.Int());
            AlterColumn("dbo.tblFichas", "PesoPromedio28D", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblFichas", "PesoPromedio28D", c => c.Double(nullable: false));
            AlterColumn("dbo.tblFichas", "NumDestetado", c => c.Int(nullable: false));
            AlterColumn("dbo.tblFichas", "PesoPromedio1D", c => c.Double(nullable: false));
            AlterColumn("dbo.tblFichas", "TotalNacidos", c => c.Int(nullable: false));
            AlterColumn("dbo.tblFichas", "NacidosMomias", c => c.Int(nullable: false));
            AlterColumn("dbo.tblFichas", "NacidosMuertos", c => c.Int(nullable: false));
            AlterColumn("dbo.tblFichas", "NacidosVivos", c => c.Int(nullable: false));
        }
    }
}
