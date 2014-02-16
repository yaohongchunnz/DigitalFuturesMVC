namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        email = c.String(nullable: false, maxLength: 128),
                        userName = c.String(),
                    })
                .PrimaryKey(t => t.email);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        jobid = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        region = c.String(nullable: false),
                        district = c.String(nullable: false),
                        suburb = c.String(nullable: false),
                        description = c.String(nullable: false, maxLength: 2048),
                        jobtype = c.String(nullable: false),
                        UserId = c.String(nullable: false),
                        username = c.String(nullable: false),
                        photo = c.String(),
                        submitDate = c.DateTime(nullable: false),
                        expireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.jobid);
            
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
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        signupDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.UserDetails");
            DropTable("dbo.ServiceProviderDetails");
            DropTable("dbo.Jobs");
            DropTable("dbo.Emails");
            CreateIndex("dbo.AspNetUserClaims", "User_Id");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            AddForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
