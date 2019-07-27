namespace PCConfigurationTool.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCConfigurationStatus1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCConfigurations", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PCConfigurations", "Status");
        }
    }
}
