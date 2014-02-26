namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suburb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suburbs", "suburb", c => c.String());
            DropColumn("dbo.Suburbs", "district");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suburbs", "district", c => c.String());
            DropColumn("dbo.Suburbs", "suburb");
        }
    }
}
