namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class servicejob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobServices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jobid = c.Int(nullable: false),
                        serviceProviderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobServices");
        }
    }
}
