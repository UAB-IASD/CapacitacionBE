using AppHub.Domain.Adapters;

namespace AppHub.Infrastructure.Providers.Validators;

public class ValidationAdapter: IValidationAdapter
{
    public string ValidatedEmail(string email)
    {
        return email;
    }
}
