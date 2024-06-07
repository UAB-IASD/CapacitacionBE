using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AppHub.Infrastructure.Database.EntityFramework.Migrations;

public class MigrationDbContext : IDesignTimeDbContextFactory<AppHubDbContext>
{
    AppHubDbContext IDesignTimeDbContextFactory<AppHubDbContext>.CreateDbContext(string[] args)
    {
        // IConfigurationRoot configuration = new ConfigurationBuilder()
        //     .SetBasePath(Directory.GetCurrentDirectory())
        //     .AddJsonFile("appsettings.json")
        //     .Build();

        var builder = new DbContextOptionsBuilder<AppHubDbContext>();

        builder.UseSqlServer(
            "Data Source=.\\SQLEXPRESS;Database=HubUab_Migration;Integrated Security=True;Trust Server Certificate=True",
            b => b.MigrationsAssembly(
                "AppHub.Infrastructure.Database.EntityFramework.Migrations"
            )
        );

        return new AppHubDbContext(builder.Options);
    }
}
