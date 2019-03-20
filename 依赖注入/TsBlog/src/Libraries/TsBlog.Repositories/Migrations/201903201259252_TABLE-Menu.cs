namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TABLEMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ParentId = c.Guid(nullable: false),
                        SerialNumber = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        Url = c.String(unicode: false),
                        Type = c.Int(nullable: false),
                        Icon = c.String(unicode: false),
                        Remarks = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
