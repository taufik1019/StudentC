using Microsoft.EntityFrameworkCore;
using SC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Context
{
    public class myContext : DbContext
    {
        internal static object keluhans;

        public myContext(DbContextOptions<myContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<ProfilMahasiswa> ProfilMahasiswas { get; set; }
        
        public DbSet<Keluhan> Keluhans { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<ResponKeluhan> ResponKeluhans { get; set; }

    }
}
