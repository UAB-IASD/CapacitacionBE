using AppHub.Domain.Common;

namespace AppHub.Domain.Exceptions;

public class InvalidStructureEmailException: DomainException
{
    public InvalidStructureEmailException(): base("Invalid structure Email")
    {
    }
}
