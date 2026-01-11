using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BLL.Services
{
    public class RoleService
    {
        private readonly IMapper _mapper;
        private readonly DataAccessFactory factory;
        public RoleService(IMapper mapper,DataAccessFactory factory) { 
          _mapper = mapper;
          this.factory = factory;
          
        }
        public Role CreateRole(CreateRoleDto dto)
        {
            var data = _mapper.Map<Role>(dto);
            var create=factory.RoleData().Create(data);
            return create;
        }
        public List<RoleDto> GetAllRoles()
        {
            var list=factory.RoleData().GetAll();
            return _mapper.Map<List<RoleDto>>(list);
        }



    }
}
