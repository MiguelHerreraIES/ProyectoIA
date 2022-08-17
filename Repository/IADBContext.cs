using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoIA.Models.Entity;

namespace ProyectoIA.Repository
{
    public class IADBContext : DbContext
    {
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<CatStatus> CatStatus { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        public IADBContext(DbContextOptions<IADBContext> options)
         : base(options)
        {

        }
    }
}
