using Fonour.Domin.Entities;
using Fonour.Domin.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fonour.EntityFramworkCore.Repositories
{
    public class MenuRepository : FonourRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(FonourDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
