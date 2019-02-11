using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fonour.Web.Controllers
{
    public class HomeController : FonourControllerBase
    {
        public IActionResult Index()
        {
            //throw new Exception("异常");
            return View();
        }
    }
}