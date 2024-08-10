using Microsoft.EntityFrameworkCore;

namespace ConferencePlanner.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Speaker> Speakers { get; set; }
}