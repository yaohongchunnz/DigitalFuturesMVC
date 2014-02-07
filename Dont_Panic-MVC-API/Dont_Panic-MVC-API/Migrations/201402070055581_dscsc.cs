namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dscsc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceProviderDetails",
                c => new
                    {
                        userId = c.String(nullable: false, maxLength: 128),
                        business_name = c.String(nullable: false),
                        address = c.String(nullable: false),
                        about = c.String(nullable: false),
                        services = c.String(nullable: false),
                        areas_serviced = c.String(nullable: false),
                        availability = c.String(nullable: false),
                        description = c.String(nullable: false),
                        contact_name = c.String(nullable: false),
                        contact_number_1 = c.String(nullable: false),
                        contact_number_2 = c.String(),
                        website_address = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        userId = c.String(nullable: false, maxLength: 128),
                        first_name = c.String(nullable: false),
                        last_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
            DropTable("dbo.ServiceProviders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        provider_id = c.Int(nullable: false, identity: true),
                        business_name = c.String(nullable: false),
                        address = c.String(nullable: false),
                        about = c.String(nullable: false),
                        services = c.String(nullable: false),
                        areas_serviced = c.String(nullable: false),
                        availability = c.String(nullable: false),
                        description = c.String(nullable: false),
                        contact_name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        contact_number_1 = c.String(nullable: false),
                        contact_number_2 = c.String(),
                        website_address = c.String(),
                    })
                .PrimaryKey(t => t.provider_id);
            
            DropTable("dbo.UserDetails");
            DropTable("dbo.ServiceProviderDetails");
        }
    }
}
