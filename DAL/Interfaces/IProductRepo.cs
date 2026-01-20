using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IProductRepo:ICrud<Product>
    {
        Task<List<Product>> SearchAsync(string? name, double? minPrice, double? maxPrice);
        Task<List<Product>> GetExpiringProductsAsync();
    }
}
