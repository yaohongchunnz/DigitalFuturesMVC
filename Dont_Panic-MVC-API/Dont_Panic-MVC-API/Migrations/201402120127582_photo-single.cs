namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photosingle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "photo");
        }
    }
}
