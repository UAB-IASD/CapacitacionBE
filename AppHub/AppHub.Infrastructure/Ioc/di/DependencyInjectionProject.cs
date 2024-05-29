using AppHub.Application.Providers;
using AppHub.Application.Services;
using AppHub.Domain.Adapters;
using AppHub.Domain.Repositories;
using AppHub.Infrastructure.Database.EntityFramework;
using AppHub.Infrastructure.Database.EntityFramework.Repositories;
using AppHub.Infrastructure.Providers.Validators;
using Microsoft.EntityFrameworkCore;
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
        collection.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("Server=WIN-G65J2K7O2OG\\SQLEXPRESS;Database=HubUab;User Id=soporte;Password=soporte;");
        });
        collection.AddTransient<IPersonRepository, PersonRepository>();
        return collection;
    }
}
