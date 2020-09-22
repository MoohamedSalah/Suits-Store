namespace Suites.DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConfigrationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configs");
        }
    }
}
