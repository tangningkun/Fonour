using System;
using System.Linq;
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
            AddPost();
        }
        private void AddPost()
        {
            var item = new Post()
            {
                Id = Guid.NewGuid(),
                PostId = Guid.NewGuid(),
                Title = "ASP.NET框架技术",
                Content = "框架搭建",
                AuthorId = Guid.NewGuid().ToString(),
                AuthorName = "lonely",
                CreatedAt = DateTime.Parse("2019-03-07"),
                PublishedAt = DateTime.Parse("2019-03-07"),
                IsDeleted =false,
                AllowShow =true,
                ViewCount =100
            };
            var entity = _context.Posts.FirstOrDefault();
            if (entity == null)
            {
                _context.Posts.Add(item);
                _context.SaveChanges();
            }
        }
    }
}