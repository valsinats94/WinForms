namespace PCConfigurationTool.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChangeLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EntityName = c.String(),
                        PropertyName = c.String(),
                        PrimaryKeyValue = c.String(),
                        OldValue = c.String(),
                        NewValue = c.String(),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChangeLogs");
        }
    }
}
