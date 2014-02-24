namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class multiplephotos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        jobid = c.Int(nullable: false),
                        photo = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.jobid, t.photo });
            
            DropColumn("dbo.Jobs", "photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "photo", c => c.String());
            DropTable("dbo.Photos");
        }
    }
}
