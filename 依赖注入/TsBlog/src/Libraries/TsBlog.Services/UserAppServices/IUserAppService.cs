using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Dependency;
using TsBlog.Services.AppServices;

namespace TsBlog.Services.UserAppServices
{
    public interface IUserAppService : IDependency, IAppService<User>
    {
        User FindByLoginName(string loginName);
        Task<User> FindByLoginNames(string loginName);
    }
}
