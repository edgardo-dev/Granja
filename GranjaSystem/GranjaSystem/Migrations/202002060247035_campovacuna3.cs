namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campovacuna3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDetalleLotes", "Fvacuna15", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblDetalleLotes", "Fvacuna15");
        }
    }
}
