using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Services.PostAppServices;

namespace TsBlog.Frontend.Controllers
{
    public class PostController : Controller
    {
        /// <summary>
        /// 文章服务接口
        /// </summary>
        private readonly IPostAppService _postAppService;

        public PostController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        /// <summary>
        /// 文章详情
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var post = _postAppService.FindById(id);
            var model = post.ToModel();
            return View(model);
        }
    }
}