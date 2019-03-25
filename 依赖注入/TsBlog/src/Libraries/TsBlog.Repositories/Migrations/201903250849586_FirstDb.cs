namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDb : DbMigration
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
                        CreateTime = c.DateTime(precision: 0),
                        IsDeleted = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateUserId, cascadeDelete: true)
                .Index(t => t.CreateUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        LoginName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        RealName = c.String(unicode: false),
                        EmailAddress = c.String(unicode: false),
                        Avatar = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Telephone = c.String(unicode: false),
                        Qq = c.String(unicode: false),
                        WebsiteUrl = c.String(unicode: false),
                        CreatedIp = c.String(unicode: false),
                        LoginCount = c.Int(nullable: false),
                        LatestLoginDate = c.DateTime(precision: 0),
                        LatestLoginIp = c.String(unicode: false),
                        ModifiedOn = c.DateTime(precision: 0),
                        Type = c.Int(nullable: false),
                        DeptmentId = c.Guid(nullable: false),
                        IsDeleted = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        Department_Id = c.Guid(),
                        Department_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id1)
                .Index(t => t.UserId)
                .Index(t => t.Department_Id)
                .Index(t => t.Department_Id1);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        RoleName = c.String(unicode: false),
                        RoleType = c.Int(nullable: false),
                        RoleCode = c.String(unicode: false),
                        CreateUserId = c.Guid(nullable: false),
                        Remarks = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        Role_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
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
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        PublishedAt = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        AllowShow = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Department_Id1", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CreateUserId", "dbo.Users");
            DropForeignKey("dbo.Menus", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Users", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Users", "UserId", "dbo.Users");
            DropIndex("dbo.Menus", new[] { "Role_Id" });
            DropIndex("dbo.Users", new[] { "Department_Id1" });
            DropIndex("dbo.Users", new[] { "Department_Id" });
            DropIndex("dbo.Users", new[] { "UserId" });
            DropIndex("dbo.Departments", new[] { "CreateUserId" });
            DropTable("dbo.Posts");
            DropTable("dbo.Menus");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Departments");
        }
    }
}
