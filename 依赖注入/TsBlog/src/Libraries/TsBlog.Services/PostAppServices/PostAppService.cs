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
    //public class PostAppService : IPostAppService
    //{
    //    private readonly IRepository<Post> _postRepository;
    //    public PostAppService(IRepository<Post> postRepository)
    //    {
    //        _postRepository = postRepository;
    //    }
    //    public bool Delete(Post entity)
    //    {
    //        return _postRepository.Delete(entity);
    //    }

    //    public bool DeleteById(object id)
    //    {
    //        return _postRepository.DeleteById(id);
    //    }

    //    public bool DeleteByIds(object[] ids)
    //    {
    //        return _postRepository.DeleteByIds(ids);
    //    }

    //    public IEnumerable<Post> FindAll()
    //    {
    //        return _postRepository.FindAll();
    //    }

    //    public Post FindById(int id)
    //    {
    //        return _postRepository.FindById(id);
    //    }

    //    public long Insert(Post entity)
    //    {
    //        return _postRepository.Insert(entity);
    //    }

    //    public bool Update(Post entity)
    //    {
    //        return _postRepository.Update(entity);
    //    }
    //}
}
