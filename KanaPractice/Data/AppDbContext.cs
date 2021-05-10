using Microsoft.EntityFrameworkCore;

namespace KanaPractice.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
    }
}
