using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
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
           await  db.SaveChangesAsync();
           return entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            //db.Categories.ToList<C>
            throw new NotImplementedException();
        }

        public Task<Category?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
