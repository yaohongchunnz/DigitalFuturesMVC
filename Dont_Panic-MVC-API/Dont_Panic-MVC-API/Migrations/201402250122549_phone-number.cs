namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDetails", "phone_number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDetails", "phone_number");
        }
    }
}
