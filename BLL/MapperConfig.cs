using AutoMapper;
using BLL.DTOs;
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
        }
    }
}
