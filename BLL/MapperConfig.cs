using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.CategoryDto;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig :Profile
    {
        public MapperConfig() {
            CreateMap<CreateRoleDto, Role>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<UpdateRoleDto, Role>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
