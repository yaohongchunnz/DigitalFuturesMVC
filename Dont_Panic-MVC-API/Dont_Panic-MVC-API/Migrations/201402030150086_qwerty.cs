namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        userName = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emails");
        }
    }
}
