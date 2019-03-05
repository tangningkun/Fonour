namespace TsBlog.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        AuthorId = c.String(unicode: false),
                        AuthorName = c.String(unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        PublishedAt = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        AllowShow = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        RealName = c.String(unicode: false),
                        EmailAddress = c.String(unicode: false),
                        Avatar = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Telephone = c.String(unicode: false),
                        Qq = c.String(unicode: false),
                        WebsiteUrl = c.String(unicode: false),
                        CreatedOn = c.DateTime(nullable: false, precision: 0),
                        CreatedIp = c.String(unicode: false),
                        LoginCount = c.Int(nullable: false),
                        LatestLoginDate = c.DateTime(precision: 0),
                        LatestLoginIp = c.String(unicode: false),
                        ModifiedOn = c.DateTime(precision: 0),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
        }
    }
}
