using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.MenuRepositorys;
using TsBlog.Services.AppServices;
using TsBlog.Services.AppServices.dto;

namespace TsBlog.Services.MenuAppServices
{
    public class MenuAppService : TsBlogAppService<Menu>, IMenuAppService
    {
        private readonly IMenuRepositiory  _menuRepositiory;
        public MenuAppService(IMenuRepositiory menuRepositiory) : base(menuRepositiory)
        {
            _menuRepositiory = menuRepositiory;
        }

        public Task<MessageDto> CreateMenu()
        {
            throw new NotImplementedException();
        }
    }
}
