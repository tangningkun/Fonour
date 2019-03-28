using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.DepartmentRepositorys;
using TsBlog.Services.AppServices;
using TsBlog.Services.DepartmentAppServices.Dto;

namespace TsBlog.Services.DepartmentAppServices
{
    public class DepartmentAppService : TsBlogAppService<Department>, IDepartmentAppService
    {
        private readonly IDepartmentRepositiory _departmentRepositiory;
        public DepartmentAppService(IDepartmentRepositiory departmentRepositiory) : base(departmentRepositiory)
        {
            _departmentRepositiory = departmentRepositiory;
        }

        /// <summary>
        /// 获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentDto>> GetDepartment()
        {
            var query = await _departmentRepositiory.GetAllListAsync(d => d.IsDeleted == 0);
            var result = new List<DepartmentDto>(
                query.Select(item=>{
                    var dto = item.MapTo<Department, DepartmentDto>();
                    return dto;
                }).ToList());
            return result;
        }
    }
}