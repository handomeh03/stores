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


    }
}