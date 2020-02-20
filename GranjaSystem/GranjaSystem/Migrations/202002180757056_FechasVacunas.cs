namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechasVacunas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna1", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna2", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna2", c => c.String());
            AlterColumn("dbo.tblDetalleLotes", "Fvacuna1", c => c.String());
        }
    }
}
