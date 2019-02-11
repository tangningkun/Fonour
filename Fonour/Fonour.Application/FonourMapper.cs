
using AutoMapper;
using Fonour.Application.Departments.dto;
using Fonour.Application.Menus.dto;
using Fonour.Application.Roles.dto;
using Fonour.Application.Users.dto;
using Fonour.Domin.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fonour.Application
{
    /// <summary>
    /// Enity与Dto映射
    /// </summary>
    public class FonourMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<MenuDto, Menu>();
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<RoleMenuDto, RoleMenu>();
                cfg.CreateMap<RoleMenu, RoleMenuDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserRoleDto, UserRole>();
                cfg.CreateMap<UserRole, UserRoleDto>();
            });
        }
    }
}
