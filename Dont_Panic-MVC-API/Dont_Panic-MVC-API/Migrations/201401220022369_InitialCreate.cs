namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        jobid = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        city = c.String(),
                        description = c.String(nullable: false, maxLength: 2048),
                        jobtype = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.jobid)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Jobs");
        }
    }
}
