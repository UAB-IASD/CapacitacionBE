using AppHub.Domain.Common;

namespace AppHub.Domain.Exceptions;

public class InvalidPasswordFormatException : DomainException
{
    public InvalidPasswordFormatException() : base("The password needs an or more uppercase, number and special characters.")
    {
    }
}
