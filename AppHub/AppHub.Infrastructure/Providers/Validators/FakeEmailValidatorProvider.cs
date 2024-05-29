using AppHub.Application.Providers;

namespace AppHub.Infrastructure.Providers.Validators;

public class FakeEmailValidatorProvider: IFakeEmailValidatorProvider
{
    public Task<bool> IsNoFakeEmail(string email)
    {
        return Task.FromResult<bool>(true);
    }
}
