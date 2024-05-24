using AppHub.Application.Providers;
using AppHub.Application.Services;
using AppHub.Application.Test.Mock;
using AppHub.Domain.Adapters;
using AppHub.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppHub.Application.Test.Common;

public class TestBase
{
    private ServiceProvider _container { get; set; }

    public TestBase()
    {
        var registor = new ServiceCollection();
        registor.AddTransient<IValidationAdapter, ValidationAdapter>();
        registor.AddTransient<IPersonRepository, PersonRepository>();
        registor.AddTransient<IEmailValidatorProvider, EmailValidatorProvider>();
        registor.AddTransient<PersonService>();
        _container = registor.BuildServiceProvider();
    }

    protected TDependency Resolve<TDependency>() where TDependency : notnull
    {
        return _container.GetRequiredService<TDependency>();
    }
}
