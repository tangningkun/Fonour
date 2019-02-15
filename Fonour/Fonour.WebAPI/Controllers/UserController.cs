using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fonour.Application.Users;
using Fonour.Domin.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fonour.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpGet("{userName},{password}")]
        public async Task<ActionResult<User>> CheckUser(string userName,string password)
        {
            return await _userAppService.CheckUser(userName, password);
        }
        [HttpPost] 
        public Task<string> AAA()
        {
            return Task<string>.Run(()=> "aaa");   
        }
    }
}