namespace AppHub.Application.Providers;

public interface IFakeEmailValidatorProvider: IProvider
{
    Task<bool> IsNoFakeEmail(string email);
}
