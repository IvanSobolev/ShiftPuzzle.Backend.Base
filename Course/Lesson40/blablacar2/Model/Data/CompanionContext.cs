using Microsoft.EntityFrameworkCore;

public class CompanionContext : DbContext
{
    public CompanionContext(DbContextOptions<CompanionContext> options) : base(options){}

    public DbSet<Companion> Companions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Companion>().HasKey(t => t.Id);
    }
}