using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class SwapnoDbContext:DbContext
    {
        public SwapnoDbContext(DbContextOptions<SwapnoDbContext>options):base(options) { }

        public DbSet<Role>Roles { get; set; }
    }
}
