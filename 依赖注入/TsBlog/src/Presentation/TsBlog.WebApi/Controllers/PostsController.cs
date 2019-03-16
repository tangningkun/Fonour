using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TsBlog.Domain.Entities;
using TsBlog.Services.PostAppServices;

namespace TsBlog.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class PostsController : ApiController
    {
        private readonly ITsBlogPostAppService _tsBlogPostAppService;

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="tsBlogPostAppService"></param>
        public PostsController(ITsBlogPostAppService tsBlogPostAppService)
        {
            _tsBlogPostAppService = tsBlogPostAppService;
        }
        /// <summary>
        /// GetAllPosts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<Post>> GetAllPosts()
        {
            var query = await _tsBlogPostAppService.GetAll();
            return query;
        }

        [HttpPost]
        public Task<string> AAA()
        {
            return Task<string>.Run(() => "aaa");
        }
    }
}
