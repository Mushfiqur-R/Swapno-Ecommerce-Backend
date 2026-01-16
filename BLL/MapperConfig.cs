using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.CategoryDto;
using BLL.DTOs.UserDtos;
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
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<User, UserDto>()
           .ForMember(dest => dest.Role,
               opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
