using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.PostRepositorys;

namespace TsBlog.Services.PostAppServices
{
    public class PostAppService : IPostAppService
    {
        private readonly IPostRepository _postRepository;
        public PostAppService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public bool Delete(Post entity)
        {
            return _postRepository.Delete(entity);
        }

        public bool DeleteById(object id)
        {
            return _postRepository.DeleteById(id);
        }

        public bool DeleteByIds(object[] ids)
        {
            return _postRepository.DeleteByIds(ids);
        }

        public IEnumerable<Post> FindAll()
        {
            return _postRepository.FindAll();
        }

        public Post FindById(int id)
        {
            return _postRepository.FindById(id);
        }

        public int Insert(Post entity)
        {
            return _postRepository.Insert(entity);
        }

        public bool Update(Post entity)
        {
            return _postRepository.Update(entity);
        }
    }
}
