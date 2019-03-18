using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TsBlog.Core.Encryption;
using TsBlog.Domain.Entities;
using TsBlog.Services.UserAppServices;
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
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      //如果视图模型中的属性没有验证通过，则返回到登录页面，要求用户重新填写
      /* if (!ModelState.IsValid)
      {
          return View(model);
      }

      //根据用户登录名查询指定用户实体
      var user = _userAppService.FindByLoginName(model.UserName.Trim());

      //如果用户不存在，则携带错误消息并返回登录页面
      if (user == null)
      {
          ModelState.AddModelError("error_message", "用户不存在");
          return View(model);
      }

      //如果密码不匹配，则携带错误消息并返回登录页面
      if (user.Password != Encryptor.Md5Hash(model.Password.Trim()))
      {
          ModelState.AddModelError("error_message", "密码错误,请重新登录");
          return View(model);
      }

      //并用户实体保存到Session中
      Session["user_account"] = user;
      //跳转到首页*/
      return RedirectToAction("Index", "Home"); 

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
    public ActionResult Register(RegisterViewModel model)
    {
      /*//如果视图模型中的属性没有验证通过，则返回到注册页面，要求用户重新填写
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      //创建一个用户实体
      var user = new User
      {
        LoginName = model.UserName,
        Password = Encryptor.Md5Hash(model.Password.Trim()),
        CreatedOn = DateTime.Now
        //由于是示例教程，所以其他字段不作填充了
      };
      //将用户实体对象写入数据库中
      var ret = _userAppService.Insert(user);

      if (ret <= 0)
      {
        //如果注册失败,则携带错误消息并返回注册页面
        ModelState.AddModelError("error_message", "注册失败");
        return View(model);

      }*/
      //如果注册成功,则跳转到登录页面
      return RedirectToAction("login");
    }
  }
}