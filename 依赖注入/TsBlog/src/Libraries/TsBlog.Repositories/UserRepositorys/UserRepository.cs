﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Repository;

namespace TsBlog.Repositories.UserRepositorys
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

    }
}
