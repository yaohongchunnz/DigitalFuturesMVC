namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobfixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "region", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "district", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "suburb", c => c.String(nullable: false));
            DropColumn("dbo.Jobs", "city");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "city", c => c.String(nullable: false));
            DropColumn("dbo.Jobs", "suburb");
            DropColumn("dbo.Jobs", "district");
            DropColumn("dbo.Jobs", "region");
        }
    }
}
