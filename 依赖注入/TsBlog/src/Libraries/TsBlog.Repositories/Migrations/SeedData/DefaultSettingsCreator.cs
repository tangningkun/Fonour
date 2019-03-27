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
            //AddRoleList();
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
        //private void AddRoleList()
        //{
        //    var items = new List<Role>()
        //    {
        //        new Role{
        //            Id= new Guid("56cd067d-7eb9-4d81-8b98-d864905865c0"),
        //            RoleId=new Guid("cb9ec6ea-60f7-4434-be08-794c057e652e"),
        //            RoleName="系统管理员",
        //            RoleType =1,
        //            RoleCode ="A00001",
        //            Remarks ="最高权限管理角色",
        //            CreateTime=DateTime.Now,
        //        },
        //        new Role(){
        //            Id=new Guid("e5718e1e-9d6c-406d-98e7-ca9f3efe6220"),
        //            RoleId=new Guid("45920738-ea58-41b5-9467-7a2be5e52ec2"),
        //            RoleName="菜单栏管理员",
        //            RoleType =2,
        //            RoleCode ="B00001",
        //            Remarks ="只负责菜单信息管理与分配",
        //            CreateTime=DateTime.Now,
        //        }
        //    };
        //    foreach (var item in items)
        //    {
        //        var entity = _context.Roles.FirstOrDefault(t => t. == item.RoleName);
        //        if (entity == null)
        //        {
        //            _context.Roles.Add(item);
        //            _context.SaveChanges();
        //        }
        //    }
        //}
        private void AddUserList()
        {
            if (_context.Users.Any())
            {
                return;   // 已经初始化过数据，直接返回
            }
            Guid departmentId = Guid.NewGuid();
            //增加一个部门
            _context.Departments.Add(
               new Department
               {
                   Id = departmentId,
                   Name = "TsBlog总部",
                   ParentId = Guid.Empty
               }
            );
            //增加一个超级管理员用户
            _context.Users.Add(
                 new User
                 {
                     Id = Guid.NewGuid(),
                     UserName = "admin",
                     Password = Encryptor.Md5Hash("123456"), //暂不进行加密
                     Name = "超级管理员",
                     DepartmentId = departmentId
                 }
            );
            //增加一个普通用户
            _context.Users.Add(
                 new User
                 {
                     Id = Guid.NewGuid(),
                     UserName = "Lonely",
                     Password = Encryptor.Md5Hash("123456"), //暂不进行加密
                     Name = "用户",
                     DepartmentId = departmentId
                 }
            );
            //增加四个基本功能菜单
            var items = new List<Menu>(){
                new Menu
                {
                    Id=Guid.NewGuid(),
                    Name = "组织机构管理",
                    Code = "Department",
                    SerialNumber = 0,
                    ParentId = Guid.Empty,
                    Icon = "fa fa-link"
                },
               new Menu
               {
                   Id=Guid.NewGuid(),
                   Name = "角色管理",
                   Code = "Role",
                   SerialNumber = 1,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link"
               },
               new Menu
               {
                   Id=Guid.NewGuid(),
                   Name = "用户管理",
                   Code = "User",
                   SerialNumber = 2,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link"
               },
               new Menu
               {
                   Id=Guid.NewGuid(),
                   Name = "功能管理",
                   Code = "Department",
                   SerialNumber = 3,
                   ParentId = Guid.Empty,
                   Icon = "fa fa-link"
               }
            };
            foreach (var item in items)
            {
                var entity = _context.Menus.FirstOrDefault(t => t.Name == item.Name);
                if (entity == null)
                {
                    _context.Menus.Add(item);
                }
            }
            _context.SaveChanges();
        }
    }
}