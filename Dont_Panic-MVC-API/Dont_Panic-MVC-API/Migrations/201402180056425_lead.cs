namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lead : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobServices", "serviceProviderId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JobServices", "serviceProviderId", c => c.Int(nullable: false));
        }
    }
}
