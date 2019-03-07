using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Repository;

namespace TsBlog.Repositories.PostRepositorys
{
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        IEnumerable<Post> FindHomePagePosts(int limit = 20);
    }
}
