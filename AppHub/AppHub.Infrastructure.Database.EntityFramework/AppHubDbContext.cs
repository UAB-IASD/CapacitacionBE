using AppHub.Infrastructure.Database.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppHub.Infrastructure.Database.EntityFramework;

public class AppHubDbContext : DbContext
{
    public DbSet<PersonEntity> Person { get; set; }
    public DbSet<AuthPersonEntity> AuthPerson { get; set; }
    public DbSet<AllowedCountriesEntity> AllowedCountriesEntity { get; set; }

    public AppHubDbContext(DbContextOptions<AppHubDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthPersonEntity>().HasNoKey();
        base.OnModelCreating(modelBuilder);
    }
}
