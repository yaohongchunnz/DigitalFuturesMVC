namespace Dont_Panic_MVC_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        districtid = c.Int(nullable: false, identity: true),
                        regionid = c.Int(nullable: false),
                        district = c.String(),
                    })
                .PrimaryKey(t => t.districtid);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        regionid = c.Int(nullable: false, identity: true),
                        region = c.String(),
                    })
                .PrimaryKey(t => t.regionid);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        suburbid = c.Int(nullable: false, identity: true),
                        districtid = c.Int(nullable: false),
                        district = c.String(),
                    })
                .PrimaryKey(t => t.suburbid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suburbs");
            DropTable("dbo.Regions");
            DropTable("dbo.Districts");
        }
    }
}
