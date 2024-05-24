using AppHub.Application.Common;

namespace AppHub.Application.Exceptions;

public class InvalidEmailException: AppLayerException
{
    public InvalidEmailException() : base("The e-email is not valid.")
    {
    }
}
