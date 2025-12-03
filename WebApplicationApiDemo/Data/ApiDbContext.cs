using Microsoft.EntityFrameworkCore;
using WebApplicationApiDemo.Models;

namespace WebApplicationApiDemo.Data
{

    public class ApiDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        // Define your tables as DbSets
        public DbSet<Product> Products { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }
    }
}
