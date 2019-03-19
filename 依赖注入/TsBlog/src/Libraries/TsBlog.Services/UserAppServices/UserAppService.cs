using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Services.AppServices;
using TsBlog.Repositories.UserRepositorys;
using TsBlog.Repositories.Repository;
using TsBlog.Services.PostAppServices;
using TsBlog.Services.AppServices.dto;
using TsBlog.Services.UserAppServices.Dto;
using AutoMapper;
using TsBlog.Core.Encryption;
using TsBlog.AutoMapperConfig.AutoMapper;

namespace TsBlog.Services.UserAppServices
{
    public class UserAppService:TsBlogAppService<User>, IUserAppService
    {
        private readonly IUserRepositiory _userRepositiory;
        public readonly TsBlogPostAppService _tsBlogPostAppService;
        public UserAppService(IUserRepositiory userRepositiory, TsBlogPostAppService tsBlogPostAppService) : base(userRepositiory)
        {
            _tsBlogPostAppService = tsBlogPostAppService;
            _userRepositiory = userRepositiory;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto">登录信息</param>
        /// <returns></returns>
        public async Task<MessageDto<User>> CheckLoginUserInfo(LoginUserDto dto)
        {
            try
            {
                var checkCount = await _userRepositiory.CountAsync(d => d.LoginName == dto.UserName);
                if (checkCount == 0)
                    return new MessageDto<User>
                    {
                        code = 201,
                        message = "该账户名不存在!",
                        result = "Fail"
                    };
                var password = Encryptor.Md5Hash(dto.Password.Trim()).ToString();
                var count = await _userRepositiory.CountAsync(d => d.LoginName == dto.UserName && d.Password == password);
                if (count != 0)
                {
                    var query = await _userRepositiory.FirstOrDefaultAsync(d => d.LoginName == dto.UserName && d.Password == password);
                    return new MessageDto<User>
                    {
                        code = 200,
                        message = "登录成功!",
                        result = "Success",
                        data = query
                    };
                }
                return new MessageDto<User>
                {
                    code = 201,
                    message = "账户名或密码有误!",
                    result = "Fail"
                };
            }
            catch (Exception e)
            {
                return new MessageDto<User>
                {
                    code = 202,
                    message = e.Message.ToString(),
                    result = "Fail"
                };
            }
            
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="dto">注册用户信息</param>
        /// <returns></returns>
        public async Task<MessageDto> RegisterUserInfo(RegisterUserDto dto)
        {
            dto.Password = Encryptor.Md5Hash(dto.Password.Trim());
            var entity = new User
            {
                LoginName = dto.UserName,
                Password = dto.Password
            };
            entity.Id = Guid.NewGuid();
            entity.UserId = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;
            try
            {
                var count = await _userRepositiory.CountAsync(d => d.LoginName == entity.LoginName);
                if (count != 0) return new MessageDto
                {
                    code = 201,
                    message = "该用户名已存在，请从新输入!",
                    result = "Fail"
                };
                await _userRepositiory.InsertAsync(entity);
                var result = new MessageDto
                {
                    code = 200,
                    message = "注册用户成功!",
                    result = "Success"
                };
                return result;
            }
            catch (Exception e)
            {
                var result = new MessageDto
                {
                    code = 202,
                    message = e.Message.ToString(),
                    result = "Fail"
                };
                return result;
            }
        }
    }
}
