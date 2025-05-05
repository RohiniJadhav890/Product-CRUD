using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssingmentApp.Models;

namespace AssingmentApp.Data
{
    public class AssingmentAppContext : DbContext
    {
        public AssingmentAppContext (DbContextOptions<AssingmentAppContext> options)
            : base(options)
        {
        }

        public DbSet<AssingmentApp.Models.Category> Category { get; set; } = default!;
        public DbSet<AssingmentApp.Models.Products> Product { get; set; } = default!;
    }
}
