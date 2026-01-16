using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserRepo : ICrud<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
