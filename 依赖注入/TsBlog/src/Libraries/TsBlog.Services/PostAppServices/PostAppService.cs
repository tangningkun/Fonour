using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories;
using TsBlog.Repositories.PostRepositorys;
using TsBlog.Repositories.Repository;
using TsBlog.Services.AppServices;

namespace TsBlog.Services.PostAppServices
{
    public class PostAppService : GenericService<Post>, IPostAppService
    {
        private readonly IPostRepository _repository;
        public PostAppService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }

        #region Implementation of IPostService

        /// <summary>
        /// 查询首页文章列表
        /// </summary>
        /// <param name="limit">要查询的记录数</param>
        /// <returns></returns>
        public IEnumerable<Post> FindHomePagePosts(int limit = 20)
        {
            return _repository.FindHomePagePosts(limit);
        }

        #endregion
    }
}
