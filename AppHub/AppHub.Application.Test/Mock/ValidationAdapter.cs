using AppHub.Domain.Adapters;
using AppHub.Domain.Exceptions;
using EmailValidation;

namespace AppHub.Application.Test.Mock;

public class ValidationAdapter :  IValidationAdapter
{
    public string ValidatedEmail(string email)
    {
        if (!EmailValidator.Validate(email))
            throw new InvalidStructureEmailException();
        return email;
    }
}
