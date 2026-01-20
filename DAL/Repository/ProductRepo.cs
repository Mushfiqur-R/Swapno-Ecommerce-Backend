using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    internal class ProductRepo : IProductRepo
    {
        public readonly SwapnoDbContext db;
        public ProductRepo(SwapnoDbContext db)
        {
            this.db = db;
        }
        public async Task<Product> CreateAsync(Product entity)
        {
            await db.Products.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        // ২. ICrud থেকে আসা মেথড: GetAll (সাথে Vendor ও Category লোড করা হলো)
        public async Task<List<Product>> GetAllAsync()
        {
            return await db.Products
                .Include(p => p.Vendor)   // ইমেইল পাঠানোর জন্য লাগবে
                .Include(p => p.Category) // ক্যাটাগরি নাম দেখানোর জন্য
                .ToListAsync();
        }

        // ৩. ICrud থেকে আসা মেথড: Get By Id
        public async Task<Product?> GetAsync(int id)
        {
            return await db.Products
                .Include(p => p.Vendor)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // ৪. ICrud থেকে আসা মেথড: Update
        public async Task<Product> UpdateAsync(Product entity)
        {
            var exProduct = await db.Products.FindAsync(entity.Id);
            if (exProduct != null)
            {
                // আগের ভ্যালুর উপর নতুন ভ্যালু বসিয়ে দেওয়া
                db.Entry(exProduct).CurrentValues.SetValues(entity);
                await db.SaveChangesAsync();
                return exProduct;
            }
            return null; // অথবা throw exception
        }

        // ৫. ICrud থেকে আসা মেথড: Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var exProduct = await db.Products.FindAsync(id);
            if (exProduct != null)
            {
                db.Products.Remove(exProduct);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // ----------------------------------------------------
        // 🔥 নিচে IProductRepo এর স্পেশাল মেথডগুলো
        // ----------------------------------------------------

        // ৬. সার্চ লজিক
        public async Task<List<Product>> SearchAsync(string? name, double? minPrice, double? maxPrice)
        {
            var query = db.Products.Include(p => p.Vendor).AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return await query.ToListAsync();
        }

        // ৭. মেয়াদ শেষের রিপোর্ট (আগামী ৭ দিন)
        public async Task<List<Product>> GetExpiringProductsAsync()
        {
            var today = DateTime.Now;
            var nextWeek = today.AddDays(7);

            return await db.Products
                .Include(p => p.Vendor)
                .Where(p => p.ExpiryDate >= today && p.ExpiryDate <= nextWeek)
                .ToListAsync();
        }
    }
}
