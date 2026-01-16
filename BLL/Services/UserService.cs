using AutoMapper;
using BLL.DTOs.UserDtos;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService
    {
        private readonly IMapper mapper;
        private readonly DataAccessFactory factory;

        public UserService(IMapper mapper, DataAccessFactory factory)
        {
            this.mapper = mapper;
            this.factory = factory;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            //var users = await factory.UserData().GetAllAsync();

            //if (users.Any(u => u.Email == dto.Email))
            //    throw new Exception("Email already exists");

            var existingUser = await factory.UserData().GetByEmailAsync(dto.Email);

            if (existingUser != null)
                throw new Exception("Email already exists");

            var user = mapper.Map<User>(dto);

            // 🔐 password hash
            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var created = await factory.UserData().CreateAsync(user);
            return mapper.Map<UserDto>(created);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await factory.UserData().GetAllAsync();
            return mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await factory.UserData().GetAsync(id);
            if (user == null)
                throw new Exception("User not found");

            return mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var deleted = await factory.UserData().DeleteAsync(id);
            if (!deleted)
                throw new Exception("User not found");

            return true;
        }

        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto dto)
        {
     
            var user = await factory.UserData().GetAsync(id);
            if (user == null)
                throw new Exception("User not found");

       

            if (!string.IsNullOrEmpty(dto.Name))
            {
                user.Name = dto.Name;
            }

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                user.PhoneNumber = dto.PhoneNumber;
            }

            if (dto.RoleId != null)
            {
                user.RoleId = dto.RoleId.Value;
            }


            await factory.UserData().UpdateAsync(user);

            return mapper.Map<UserDto>(user);
        }

    }
}
