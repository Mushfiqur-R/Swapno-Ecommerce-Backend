using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface  ICrud<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}
