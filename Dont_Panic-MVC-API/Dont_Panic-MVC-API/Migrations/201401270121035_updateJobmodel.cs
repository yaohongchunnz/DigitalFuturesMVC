namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateJobmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "expireDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "expireDate", c => c.DateTime(nullable: false));
        }
    }
}
