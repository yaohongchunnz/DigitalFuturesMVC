namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class token : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProviderDetails", "tokens", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceProviderDetails", "tokens");
        }
    }
}
