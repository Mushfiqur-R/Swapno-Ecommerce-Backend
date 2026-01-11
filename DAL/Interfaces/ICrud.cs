using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface  ICrud<T> where T : class
    {
        T Create(T entity);
        List<T> GetAll();
        T Update(T entity);

    }
}
