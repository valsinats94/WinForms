namespace PCConfigurationTool.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCConfigurationInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PCConfigurations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PCConfigurationComponent",
                c => new
                    {
                        PCConfigurationRefID = c.Int(nullable: false),
                        PCComponentRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PCConfigurationRefID, t.PCComponentRefID })
                .ForeignKey("dbo.PCConfigurations", t => t.PCConfigurationRefID, cascadeDelete: true)
                .ForeignKey("dbo.PCComponents", t => t.PCComponentRefID, cascadeDelete: true)
                .Index(t => t.PCConfigurationRefID)
                .Index(t => t.PCComponentRefID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PCConfigurationComponent", "PCComponentRefID", "dbo.PCComponents");
            DropForeignKey("dbo.PCConfigurationComponent", "PCConfigurationRefID", "dbo.PCConfigurations");
            DropIndex("dbo.PCConfigurationComponent", new[] { "PCComponentRefID" });
            DropIndex("dbo.PCConfigurationComponent", new[] { "PCConfigurationRefID" });
            DropTable("dbo.PCConfigurationComponent");
            DropTable("dbo.PCConfigurations");
        }
    }
}
