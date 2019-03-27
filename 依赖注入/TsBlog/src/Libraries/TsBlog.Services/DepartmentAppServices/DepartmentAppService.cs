using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.DepartmentRepositorys;
using TsBlog.Services.AppServices;

namespace TsBlog.Services.DepartmentAppServices
{
    public class DepartmentAppService : TsBlogAppService<Department>, IDepartmentAppService
    {
        private readonly IDepartmentRepositiory _departmentRepositiory;
        public DepartmentAppService(IDepartmentRepositiory departmentRepositiory) : base(departmentRepositiory)
        {
            _departmentRepositiory = departmentRepositiory;
        }
    }

}