namespace Suites.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISFeatcherINCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ISFeatcher", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ISFeatcher");
        }
    }
}
