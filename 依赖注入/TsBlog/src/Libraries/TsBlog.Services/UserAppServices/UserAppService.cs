﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.UserRepositorys;
using TsBlog.Services.AppServices;

namespace TsBlog.Services.UserAppServices
{
    public class UserAppService : GenericService<User>, IUserAppService
    {
        private readonly IUserRepository _repository;
        public UserAppService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public User FindByLoginName(string loginName)
        {
            return _repository.FindByClause(x => x.LoginName == loginName);
        }

        public async Task<User> FindByLoginNames(string loginName)
        {
            throw new NotImplementedException();
        }
    }
}
