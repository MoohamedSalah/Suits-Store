namespace Suites.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prodects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        prise = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodects", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Prodects", new[] { "Category_ID" });
            DropTable("dbo.Prodects");
            DropTable("dbo.Categories");
        }
    }
}
