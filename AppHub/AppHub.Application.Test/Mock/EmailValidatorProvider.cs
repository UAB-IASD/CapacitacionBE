using AppHub.Application.Providers;

namespace AppHub.Application.Test.Mock;

internal class EmailValidatorProvider: IEmailValidatorProvider
{
    public Task<bool> IsEmailValid(string email)
    {
        return Task.FromResult(true);
    }
}
