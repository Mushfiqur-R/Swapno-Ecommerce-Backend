using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    internal class CategoryRepo : ICrud<Category>
    {
        public readonly SwapnoDbContext db;
        public CategoryRepo(SwapnoDbContext db) {
          this.db = db;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            db.Categories.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

    
        public async Task<List<Category>> GetAllAsync()
        {
            return await db.Categories.ToListAsync();
        }

      
        public async Task<Category?> GetAsync(int id)
        {
            return await db.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            db.Categories.Update(entity);
            await db.SaveChangesAsync();
            return entity;
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category == null)
                return false;

            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return true;
        }
    
}
}
