using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.AutoMapperConfig.AutoMapper;
using TsBlog.Domain.Entities;
using TsBlog.Repositories.DepartmentRepositorys;
using TsBlog.Services.AppServices;
using TsBlog.Services.AppServices.dto;
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
                query.Select(item =>
                {
                    var dto = item.MapTo<Department, DepartmentDto>();
                    return dto;
                }).ToList());
            return result;
        }

        /// <summary>
        /// 新建部门
        /// </summary>
        /// <returns></returns>
        public async Task<MessageDto> CreateDepartment(CreateDepartmentDto dto)
        {
            try
            {
                dto.Id = Guid.NewGuid();
                dto.ParentId = string.IsNullOrEmpty(dto.ParentId.ToString()) ? Guid.Empty : dto.ParentId;
                var count = await _departmentRepositiory.CountAsync(d => d.Name == dto.Name&&d.IsDeleted==0);
                if (count != 0)
                {
                    return new MessageDto()
                    {
                        code = 201,
                        message = "添加失败,该部门已存在",
                        result = "Fail"
                    };
                }
                await _departmentRepositiory.InsertAsync(dto.MapTo<CreateDepartmentDto, Department>());
                return new MessageDto()
                {
                    code = 200,
                    message = "成功添加部门信息",
                    result = "Success"
                };

            }
            catch (Exception e)
            {
                return new MessageDto()
                {
                    code = 202,
                    message = "添加成功",
                    result = "Fail"
                };
            }
        }
    }
}