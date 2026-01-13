using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    internal class RoleRepo : ICrud<Role>
    {
        private readonly SwapnoDbContext _db;
        public RoleRepo(SwapnoDbContext db)
        {
            _db = db;

        }
        public async Task<Role> CreateAsync(Role entity)
        {
            _db.Roles.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Roles.FindAsync(id);

            if (entity == null)
            {
                return false;
            }

            _db.Roles.Remove(entity);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<List<Role>> GetAllAsync()
        {
            var roles= await _db.Roles.ToListAsync();
            return roles;

        }

        public async Task<Role?> GetAsync(int id)
        {
            var exist= await _db.Roles.FindAsync(id);
            return exist;
        }

        public async Task<Role> UpdateAsync(Role entity)
        {
            var update= _db.Roles.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        
    }
}
