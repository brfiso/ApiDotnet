using Microsoft.EntityFrameworkCore;

namespace AulaApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

    }
}
