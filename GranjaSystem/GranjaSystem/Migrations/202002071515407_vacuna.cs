namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vacuna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDetalleLotes", "Fvacuna20", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblDetalleLotes", "Fvacuna20");
        }
    }
}
