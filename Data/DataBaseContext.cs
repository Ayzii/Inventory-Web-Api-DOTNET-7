using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

    }

}
