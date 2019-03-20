namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TABLEUPDATE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "RoleId", c => c.Guid(nullable: false));
            AddColumn("dbo.Menus", "CreatedOn", c => c.DateTime(nullable: false, precision: 0));
            AddColumn("dbo.Posts", "CreatedOn", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CreatedOn");
            DropColumn("dbo.Menus", "CreatedOn");
            DropColumn("dbo.Menus", "RoleId");
        }
    }
}
