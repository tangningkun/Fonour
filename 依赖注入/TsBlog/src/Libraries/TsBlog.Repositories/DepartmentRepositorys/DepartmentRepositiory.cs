using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Repository;

namespace TsBlog.Repositories.DepartmentRepositorys
{
    public class DepartmentRepositiory : TsBlogGenericRepository<Department>, IDepartmentRepositiory
    {
        public DepartmentRepositiory(TsBlogDbContext dbContext) : base(dbContext)
        {

        }
    }
}
