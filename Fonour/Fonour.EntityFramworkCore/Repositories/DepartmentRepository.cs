using Fonour.Domin.Entities;
using Fonour.Domin.IRepositories;
using Fonour.EntityFramworkCore;
using Fonour.EntityFramworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fonour.EntityFrameworkCore.Repositories
{
    public class DepartmentRepository : FonourRepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(FonourDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
