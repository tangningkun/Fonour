﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Dependency;
using TsBlog.Services.AppServices;
using TsBlog.Services.AppServices.dto;

namespace TsBlog.Services.MenuAppServices
{
     public interface IMenuAppService : IDependency, ITsBlogAppService<Menu>
     {
        Task<MessageDto> CreateMenu();
     }
}
