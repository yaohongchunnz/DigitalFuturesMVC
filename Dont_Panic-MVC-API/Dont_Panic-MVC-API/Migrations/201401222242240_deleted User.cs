namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropColumn("dbo.Jobs", "User_Id");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 15),
                        good_feedback = c.Int(nullable: false),
                        neutral_feedback = c.Int(nullable: false),
                        bad_feedback = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Jobs", "User_Id", c => c.Int());
            CreateIndex("dbo.Jobs", "User_Id");
            AddForeignKey("dbo.Jobs", "User_Id", "dbo.Users", "Id");
        }
    }
}
