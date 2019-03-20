using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Repository;

namespace TsBlog.Repositories.MenuRepositorys
{
    public class MenuRepositiory : TsBlogGenericRepository<Menu>, IMenuRepositiory
    {
        public MenuRepositiory(TsBlogDbContext dbContext) : base(dbContext)
        {

        }
    }
}
