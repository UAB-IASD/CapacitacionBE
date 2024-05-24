using System.Net.Mail;

namespace AppHub.Application.Providers;

public interface IEmailValidatorProvider: IProvider
{
    Task<bool> IsEmailValid(string email);
}
