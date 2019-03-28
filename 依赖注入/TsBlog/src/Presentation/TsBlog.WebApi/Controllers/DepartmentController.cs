using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TsBlog.Services.DepartmentAppServices;
using TsBlog.Services.DepartmentAppServices.Dto;

namespace TsBlog.WebApi.Controllers
{
    /// <summary>
    /// Department
    /// </summary>
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentAppService _departmentAppService;
        /// <summary>
        /// Department依赖注入
        /// </summary>
        /// <param name="departmentAppService"></param>
        public DepartmentController(IDepartmentAppService departmentAppService) {
            _departmentAppService = departmentAppService;
        }
        /// <summary>
        /// GetDepartment|获取所有部门信息
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentDto>> GetDepartment()
        {
            return await _departmentAppService.GetDepartment();
        }
    }
}
