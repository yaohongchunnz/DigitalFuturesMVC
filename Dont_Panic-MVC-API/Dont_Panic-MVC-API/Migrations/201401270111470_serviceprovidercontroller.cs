namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceprovidercontroller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "username");
        }
    }
}
