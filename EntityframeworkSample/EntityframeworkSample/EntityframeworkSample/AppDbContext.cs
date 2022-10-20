using Microsoft.EntityFrameworkCore;

namespace EntityframeworkSample;

public class AppDbContext : DbContext
{
    public DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data source=database.db");
    }
}
