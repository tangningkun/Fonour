using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Frontend.Extensions;
using TsBlog.Repositories.Repository;
using TsBlog.Services.PostAppServices;
using TsBlog.ViewModel.Post;

namespace TsBlog.Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostAppService _postAppService;
        private readonly ITsBlogPostAppService _tsBlogPostAppService;
        public HomeController(IPostAppService postAppService, ITsBlogPostAppService tsBlogPostAppService)
        {
            _postAppService = postAppService;
            _tsBlogPostAppService = tsBlogPostAppService;
        }
        public ActionResult Index(int? page)
        {
            //var list = _postAppService.FindHomePagePosts();
            //var model = list.Select(x => x.ToModel().FormatPostViewModel());
            var query = _tsBlogPostAppService.GetAll();
            page = page ?? 1;
            var list = _postAppService.FindPagedList(x => !x.IsDeleted && x.AllowShow, pageIndex: (int)page, pageSize: 10);
            var model = list.Select(x => x.ToModel().FormatPostViewModel());
            ViewBag.Pagination = new StaticPagedList<PostViewModel>(model, list.PageIndex, list.PageSize, list.TotalCount);
            return View(model);
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