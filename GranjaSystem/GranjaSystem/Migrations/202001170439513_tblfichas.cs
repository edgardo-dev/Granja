namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblfichas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblFichas", "FechaServio", c => c.String());
            AlterColumn("dbo.tblFichas", "FechaParto", c => c.String());
            AlterColumn("dbo.tblFichas", "FechaDestete", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblFichas", "FechaDestete", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblFichas", "FechaParto", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblFichas", "FechaServio", c => c.DateTime(nullable: false));
        }
    }
}
