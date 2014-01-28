namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "city", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "jobtype", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "UserId", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "username", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "business_name", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "address", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "about", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "services", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "areas_serviced", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "availability", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "description", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "contact_name", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "email", c => c.String(nullable: false));
            AlterColumn("dbo.ServiceProviders", "contact_number_1", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceProviders", "contact_number_1", c => c.String());
            AlterColumn("dbo.ServiceProviders", "email", c => c.String());
            AlterColumn("dbo.ServiceProviders", "contact_name", c => c.String());
            AlterColumn("dbo.ServiceProviders", "description", c => c.String());
            AlterColumn("dbo.ServiceProviders", "availability", c => c.String());
            AlterColumn("dbo.ServiceProviders", "areas_serviced", c => c.String());
            AlterColumn("dbo.ServiceProviders", "services", c => c.String());
            AlterColumn("dbo.ServiceProviders", "about", c => c.String());
            AlterColumn("dbo.ServiceProviders", "address", c => c.String());
            AlterColumn("dbo.ServiceProviders", "business_name", c => c.String());
            AlterColumn("dbo.Jobs", "username", c => c.String());
            AlterColumn("dbo.Jobs", "UserId", c => c.String());
            AlterColumn("dbo.Jobs", "jobtype", c => c.String());
            AlterColumn("dbo.Jobs", "city", c => c.String());
        }
    }
}
