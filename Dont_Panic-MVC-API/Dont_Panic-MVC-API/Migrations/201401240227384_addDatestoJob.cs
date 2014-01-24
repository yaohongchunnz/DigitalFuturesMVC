namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDatestoJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "submitDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "expireDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "expireDate");
            DropColumn("dbo.Jobs", "submitDate");
        }
    }
}
