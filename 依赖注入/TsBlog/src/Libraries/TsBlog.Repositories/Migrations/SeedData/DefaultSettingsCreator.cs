using System;
using System.Collections.Generic;
using System.Linq;
using TsBlog.Core.Encryption;
using TsBlog.Domain.Entities;

namespace TsBlog.Repositories.Migrations.SeedData
{
    public class DefaultSettingsCreator
    {
        private TsBlogDbContext _context;

        public DefaultSettingsCreator(TsBlogDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //初始化Post表
            AddPostList();
            AddRoleList();
            AddUserList();
        }
        private void AddPostList()
        {
            var item = new Post()
            {
                Id = Guid.NewGuid(),
                PostId = Guid.NewGuid(),
                Title = "ASP.NET框架技术",
                Content = "框架搭建",
                AuthorId = Guid.NewGuid().ToString(),
                AuthorName = "lonely",
                CreateTime = DateTime.Parse("2019-03-07"),
                PublishedTime = DateTime.Parse("2019-03-07"),
                IsDeleted = false,
                AllowShow = true,
                ViewCount = 100
            };
            var entity = _context.Posts.FirstOrDefault(t => t.Title == item.Title);
            if (entity == null)
            {
                _context.Posts.Add(item);
                _context.SaveChanges();
            }
        }
        private void AddRoleList()
        {
            var items = new List<Role>()
            {
                new Role(){
                    Id= new Guid("56cd067d-7eb9-4d81-8b98-d864905865c0"),
                    RoleId=new Guid("cb9ec6ea-60f7-4434-be08-794c057e652e"),
                    RoleName="系统管理员",
                    RoleType =1,
                    RoleCode ="A00001",
                    Remarks ="最高权限管理角色",
                    CreateTime=DateTime.Now,
                },
                new Role(){
                    Id=new Guid("e5718e1e-9d6c-406d-98e7-ca9f3efe6220"),
                    RoleId=new Guid("45920738-ea58-41b5-9467-7a2be5e52ec2"),
                    RoleName="菜单栏管理员",
                    RoleType =2,
                    RoleCode ="B00001",
                    Remarks ="只负责菜单信息管理与分配",
                    CreateTime=DateTime.Now,
                }
            };
            foreach (var item in items)
            {
                var entity = _context.Roles.FirstOrDefault(t => t.RoleName == item.RoleName);
                if (entity == null)
                {
                    _context.Roles.Add(item);
                    _context.SaveChanges();
                }
            }
        }
        private void AddUserList()
        {
            var items = new List<User>()
            {
                new User(){
                    Id = new Guid("d0b67d8d-4ff0-4740-9bb6-f4eda9c2e29d"),
                    UserId=new Guid("c3ffc1fd-aa8d-4772-afbb-d917c87228c8"),
                    UserName="admin",
                    Password=Encryptor.Md5Hash("123qwe"),
                    CreateTime = DateTime.Now,
                    IsDeleted = 0,
                }
            };
            foreach (var item in items)
            {
                var entity = _context.Users.FirstOrDefault(t => t.UserName == item.UserName);
                if (entity == null)
                {
                    _context.Users.Add(item);
                    _context.SaveChanges();
                }
            }
        }
    }
}