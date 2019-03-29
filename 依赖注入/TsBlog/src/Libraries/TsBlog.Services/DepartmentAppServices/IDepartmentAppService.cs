using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.Dependency;
using TsBlog.Services.AppServices;
using TsBlog.Services.AppServices.dto;
using TsBlog.Services.DepartmentAppServices.Dto;

namespace TsBlog.Services.DepartmentAppServices
{
    public interface IDepartmentAppService: IDependency, ITsBlogAppService<Department>
    {
        Task<List<DepartmentDto>> GetDepartment();
        Task<MessageDto> CreateDepartment(CreateDepartmentDto dto);
    }
}
