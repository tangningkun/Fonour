namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role_User_Menu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleMenus",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        MenuId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.MenuId })
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleMenus", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleMenus", "MenuId", "dbo.Menus");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.RoleMenus", new[] { "MenuId" });
            DropIndex("dbo.RoleMenus", new[] { "RoleId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.RoleMenus");
        }
    }
}
