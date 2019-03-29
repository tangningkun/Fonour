using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TsBlog.Frontend.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult DepartmentIndex()
        {
            return View();
        }
    }
}