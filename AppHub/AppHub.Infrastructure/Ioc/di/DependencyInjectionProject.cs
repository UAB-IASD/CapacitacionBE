using AppHub.Application.Providers;
using AppHub.Application.Services;
using AppHub.Domain.Adapters;
using AppHub.Domain.Repositories;
using AppHub.Infrastructure.Database.EntityFramework;
using AppHub.Infrastructure.Database.EntityFramework.Repositories;
using AppHub.Infrastructure.Providers.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppHub.Infrastructure.Ioc.di;

public static class DependencyInjectionProject
{
    public static IServiceCollection RegisterProviders(this IServiceCollection collection)
    {
        collection.AddTransient<IFakeEmailValidatorProvider, FakeEmailValidatorProvider>();
        collection.AddTransient<IValidationAdapter, ValidationAdapter>();
        return collection;
    }

    public static IServiceCollection RegisterServices(this IServiceCollection collection)
    {
        collection.AddTransient<PersonService>();
        return collection;
    }

    public static IServiceCollection RegisterRepositories(this IServiceCollection collection)
    {
        var config = collection.BuildServiceProvider().GetService<IConfiguration>();
        // var connectionString = config?.GetSection("DataBase:Default").Value ?? "";
        var connectionString = config?.GetSection("DataBase:Express").Value ?? "";

        collection.AddDbContext<AppHubDbContext>(options => options.UseSqlServer(connectionString));
        collection.AddTransient<IPersonRepository, PersonRepository>();
        return collection;
    }
}
