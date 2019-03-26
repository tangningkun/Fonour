namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Code = c.String(unicode: false),
                        Manager = c.String(unicode: false),
                        ContactNumber = c.String(unicode: false),
                        Remarks = c.String(unicode: false),
                        ParentId = c.Guid(nullable: false),
                        CreateUserId = c.Guid(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreateTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        EMail = c.String(unicode: false),
                        MobileNumber = c.String(unicode: false),
                        Remarks = c.String(unicode: false),
                        CreateUserId = c.Guid(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false, precision: 0),
                        LoginTimes = c.Int(nullable: false),
                        DepartmentId = c.Guid(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreateTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
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
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(unicode: false),
                        Name = c.String(unicode: false),
                        CreateUserId = c.Guid(nullable: false),
                        CreateTime = c.DateTime(precision: 0),
                        Remarks = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreateTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        Title = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        AuthorId = c.String(unicode: false),
                        AuthorName = c.String(unicode: false),
                        PublishedTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        AllowShow = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        CreateTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleMenus", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleMenus", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.RoleMenus", new[] { "MenuId" });
            DropIndex("dbo.RoleMenus", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Menus");
            DropTable("dbo.RoleMenus");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
        }
    }
}
