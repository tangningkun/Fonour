using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Dependency;
using TsBlog.Services.AppServices;
using TsBlog.Services.AppServices.dto;
using TsBlog.Services.UserAppServices.Dto;

namespace TsBlog.Services.UserAppServices
{
    public interface IUserAppService: IDependency, ITsBlogAppService<User>
    {
        Task<MessageDto<User>> CheckLoginUserInfo(LoginUserDto dto);

        Task<MessageDto> RegisterUserInfo(RegisterUserDto dto);
    }
}
