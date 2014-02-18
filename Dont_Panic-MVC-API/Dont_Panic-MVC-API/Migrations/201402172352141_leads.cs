namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class leads : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "leadsAccquired", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "leadsAccquired");
        }
    }
}
