using Microsoft.EntityFrameworkCore;
using Stores.Models;


namespace stores.data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> users { get; set; }
        public DbSet<UserRole> UserRoles {  get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }



    }
}