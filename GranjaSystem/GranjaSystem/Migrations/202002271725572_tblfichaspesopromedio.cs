namespace GranjaSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tblfichaspesopromedio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblFichas", "PesoPromedio1D", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tblFichas", "PesoPromedio28D", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblFichas", "PesoPromedio28D", c => c.Double());
            AlterColumn("dbo.tblFichas", "PesoPromedio1D", c => c.Double());
        }
    }
}
