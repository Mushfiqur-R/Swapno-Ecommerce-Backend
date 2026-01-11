using DAL.Data;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        private readonly SwapnoDbContext _db;
        public DataAccessFactory(SwapnoDbContext db) {
            _db = db;

        }
        public ICrud<Role>RoleData()
        {
            return new RoleRepo(_db);   
        }
    }
}
