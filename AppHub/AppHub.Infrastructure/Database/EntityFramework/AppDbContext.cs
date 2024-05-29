using AppHub.Infrastructure.Database.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppHub.Infrastructure.Database.EntityFramework;

public class AppDbContext : DbContext
{
    public DbSet<PersonEntity> Person { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}
