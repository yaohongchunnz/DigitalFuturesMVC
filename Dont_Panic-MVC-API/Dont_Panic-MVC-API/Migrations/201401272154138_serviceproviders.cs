namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceproviders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        provider_id = c.Int(nullable: false, identity: true),
                        business_name = c.String(),
                        address = c.String(),
                        about = c.String(),
                        services = c.String(),
                        areas_serviced = c.String(),
                        availability = c.String(),
                        description = c.String(),
                        contact_name = c.String(),
                        email = c.String(),
                        contact_number_1 = c.String(),
                        contact_number_2 = c.String(),
                        website_address = c.String(),
                    })
                .PrimaryKey(t => t.provider_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceProviders");
        }
    }
}
