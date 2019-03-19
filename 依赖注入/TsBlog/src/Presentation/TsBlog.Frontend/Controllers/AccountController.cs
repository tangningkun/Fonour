using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Core.Encryption;
using TsBlog.Domain.Entities;
using TsBlog.Services.UserAppServices;
using TsBlog.Services.UserAppServices.Dto;
using TsBlog.ViewModel.User;

namespace TsBlog.Frontend.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 用户服务接口
        /// </summary>
        private readonly IUserAppService _userAppService;

        public AccountController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 提交登录请求
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CheckLogin(LoginViewModel model)
        {
            var result=await _userAppService.CheckLoginUserInfo(model.MapTo<LoginViewModel, LoginUserDto>());
            if (result.result == "Success")
            {
                Session["user_account"] = result.data;
            }
            return Json(result);
        }

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 提交注册请求
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> RegisteredUser(RegisterViewModel model)
        {
            //return RedirectToAction("login");
            var result = await _userAppService.RegisterUserInfo(model.MapTo<RegisterViewModel, RegisterUserDto>());
            return Json(result);
            
        }
    }
}