using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
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
        public Role Create(Role entity)
        {
            _db.Roles.Add(entity);
            _db.SaveChanges();
            return entity;

        }

        public List<Role> GetAll()
        {
            var roles= _db.Roles.ToList();
            return roles;
        }

public Role Update(Role entity)
{
    throw new NotImplementedException();
}
    }
}
