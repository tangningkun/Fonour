using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Repositories.Repository;
using TsBlog.Services.PostAppServices;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostAppService _postAppService;
        public HomeController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post()
        {
            //var postRepository = new PostRepository();
            //var post = postRepository.FindById(1);
            //return View(post);

            var post = _postAppService.FindById(1).ToModel(); ;
            return View(post);
        }
    }
}