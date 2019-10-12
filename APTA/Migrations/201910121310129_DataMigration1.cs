namespace APTA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Conferences", "ConferenceName", c => c.String(nullable: false));
            DropColumn("dbo.Conferences", "ConferencenName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Conferences", "ConferencenName", c => c.String(nullable: false));
            DropColumn("dbo.Conferences", "ConferenceName");
        }
    }
}
