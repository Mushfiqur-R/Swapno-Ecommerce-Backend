using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    internal class UserRepo : ICrud<User>
    {
        private readonly SwapnoDbContext db;

        public UserRepo(SwapnoDbContext db)
        {
            this.db = db;
        }
        public async  Task<User> CreateAsync(User entity)
        {
            entity.CreatedAt = DateTime.Now;
            db.Users.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await GetAsync(id);
            if (user == null) return false;

            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await db.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User?> GetAsync(int id)
        {
            return await db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            entity.UpdatedAt = DateTime.Now;
            db.Users.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }
    }
}
