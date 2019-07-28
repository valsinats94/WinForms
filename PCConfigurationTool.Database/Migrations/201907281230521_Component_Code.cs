namespace PCConfigurationTool.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Component_Code : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCComponents", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PCComponents", "Code");
        }
    }
}
