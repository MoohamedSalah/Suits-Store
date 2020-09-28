namespace Suites.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageUrltoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prodects", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prodects", "ImageURL");
        }
    }
}
