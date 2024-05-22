using AppHub.Domain.Common;

namespace AppHub.Domain.Exceptions;

public class InvalidBirthdateException : DomainException
{
    public InvalidBirthdateException() : base("Invalid birthdate")
    {
    }
}