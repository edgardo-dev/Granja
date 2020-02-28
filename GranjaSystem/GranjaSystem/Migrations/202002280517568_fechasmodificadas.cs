namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechasmodificadas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblDetalleLotes", "FechaInseminacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblDetalleLotes", "FechaParto", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna15", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna15", c => c.String());
            AlterColumn("dbo.tblDetalleLotes", "FechaParto", c => c.String());
            AlterColumn("dbo.tblDetalleLotes", "FechaInseminacion", c => c.String());
        }
    }
}
