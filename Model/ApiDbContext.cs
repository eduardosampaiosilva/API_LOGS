using Microsoft.EntityFrameworkCore;

namespace API_LOGS.Model
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<LogEmail> LogEmails { get; set; }
    }
}