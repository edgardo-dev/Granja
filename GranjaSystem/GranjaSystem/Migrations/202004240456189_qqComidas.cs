namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qqComidas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblLechones", "qqDiarios", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.tblLechones", "qqSemanal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblLechones", "qqSemanal");
            DropColumn("dbo.tblLechones", "qqDiarios");
        }
    }
}
