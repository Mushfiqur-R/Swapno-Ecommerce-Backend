using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
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
        public async Task<Role> CreateRole(CreateRoleDto dto)
        {
            var allroles = await factory.RoleData().GetAllAsync();
            if (allroles.Any(r => r.Name == dto.Name))
            {
                throw new Exception($"{dto.Name} already exists");
            }
            var data = _mapper.Map<Role>(dto);
            var create=await factory.RoleData().CreateAsync(data);
            return create;
        }
        public async Task<List<RoleDto>> GetAllRoles()
        {
            var list=await factory.RoleData().GetAllAsync();
            return _mapper.Map<List<RoleDto>>(list);
        }

        public async Task<Role> GetRolebyID(int id) { 
         var exist=await factory.RoleData().GetAsync(id);
            if (exist == null)
            {
                throw new Exception($"{id} not found.");
            }
            return exist;
        }

        public async Task<Role> UpdateRole(int id, UpdateRoleDto dto) { 
          var role= await factory.RoleData().GetAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if (dto.Name != null)
            {
                role.Name = dto.Name;
            }

            return await factory.RoleData().UpdateAsync(role);

        }

        public async Task<bool> DeleteRole(int id)
        {
            var deleted = await factory.RoleData().DeleteAsync(id);

            if (!deleted)
            {
                throw new Exception("Role not found");
            }

            return true;
        }




    }
}
