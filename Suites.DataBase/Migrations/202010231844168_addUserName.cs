namespace Suites.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UserName");
        }
    }
}
