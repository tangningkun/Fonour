using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TsBlog.Services.AppServices.dto;
using TsBlog.Services.UserAppServices;
using TsBlog.Services.UserAppServices.Dto;

namespace TsBlog.WebApi.Controllers
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IUserAppService _userAppService;
        /// <summary>
        /// 用户依赖注入
        /// </summary>
        /// <param name="userAppService"></param>
        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// RegisterUserInfo|注册用户
        /// </summary>
        /// <param name="dto">注册信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageDto> RegisterUserInfo(RegisterUserDto dto)
        {
            var result = await _userAppService.RegisterUserInfo(dto);
            return result;
        }

        /// <summary>
        /// CheckLoginUserInfo|用户登录
        /// </summary>
        /// <param name="dto">登录信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageDto> CheckLoginUserInfo(LoginUserDto dto)
        {
            var result = await _userAppService.CheckLoginUserInfo(dto);
            return result;
        }
    }
}
