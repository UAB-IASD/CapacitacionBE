using AppHub.Application.Providers;

namespace AppHub.Application.Test.Mock;

internal class FakeEmailValidatorProvider: IFakeEmailValidatorProvider
{
    public Task<bool> IsNoFakeEmail(string email)
    {
        return Task.FromResult(true);
    }
}
