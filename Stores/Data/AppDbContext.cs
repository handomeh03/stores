using Microsoft.EntityFrameworkCore;


namespace stores.data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


    }
}