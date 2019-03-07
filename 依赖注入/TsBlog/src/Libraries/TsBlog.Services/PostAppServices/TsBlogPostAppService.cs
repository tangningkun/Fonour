using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.PostRepositorys;
using TsBlog.Services.AppServices;

namespace TsBlog.Services.PostAppServices
{
    public class TsBlogPostAppService : TsBlogAppService<Post>, ITsBlogPostAppService
    {
        private readonly IPostRepositiory _repository;
        public TsBlogPostAppService(IPostRepositiory repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
