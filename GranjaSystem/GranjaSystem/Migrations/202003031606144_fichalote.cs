namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fichalote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblFichas", "Lote", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblFichas", "Lote");
        }
    }
}
