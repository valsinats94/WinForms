namespace PCConfigurationTool.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCConfiguration_ConfigurationType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCConfigurations", "ConfigurationType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PCConfigurations", "ConfigurationType");
        }
    }
}
