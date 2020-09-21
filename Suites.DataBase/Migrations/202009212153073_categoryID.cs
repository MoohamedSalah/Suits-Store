namespace Suites.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prodects", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Prodects", new[] { "Category_ID" });
            RenameColumn(table: "dbo.Prodects", name: "Category_ID", newName: "categoryID");
            AlterColumn("dbo.Prodects", "categoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Prodects", "categoryID");
            AddForeignKey("dbo.Prodects", "categoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodects", "categoryID", "dbo.Categories");
            DropIndex("dbo.Prodects", new[] { "categoryID" });
            AlterColumn("dbo.Prodects", "categoryID", c => c.Int());
            RenameColumn(table: "dbo.Prodects", name: "categoryID", newName: "Category_ID");
            CreateIndex("dbo.Prodects", "Category_ID");
            AddForeignKey("dbo.Prodects", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
