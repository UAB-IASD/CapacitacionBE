using AppHub.Domain.Common;

namespace AppHub.Domain.Exceptions;

public class InvalidEmailException: DomainException
{
    public InvalidEmailException(): base("Invalid Email")
    {
    }
}