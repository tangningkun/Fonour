using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fonour.Application.Users;
using Microsoft.AspNetCore.Mvc;

namespace Fonour.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserAppService _userAppService;
        public LoginController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Login()
        {
            var user = _userAppService.CheckUser("admin", "123456");
            return View();
        }
    }
}