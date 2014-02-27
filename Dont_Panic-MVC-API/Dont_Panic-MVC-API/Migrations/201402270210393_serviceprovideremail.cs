namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceprovideremail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceProviderDetails", "userName", c => c.String());
            AddColumn("dbo.ServiceProviderDetails", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceProviderDetails", "email");
            DropColumn("dbo.ServiceProviderDetails", "userName");
        }
    }
}
