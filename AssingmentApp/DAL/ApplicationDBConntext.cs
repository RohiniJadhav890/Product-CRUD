using AssingmentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AssingmentApp.DAL
{
    public class ApplicationDBConntext:DbContext
    {
        public ApplicationDBConntext(DbContextOptions<ApplicationDBConntext> op) : base(op)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
