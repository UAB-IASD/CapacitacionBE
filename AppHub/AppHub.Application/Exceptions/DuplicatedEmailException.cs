using AppHub.Application.Common;

namespace AppHub.Application.Exceptions;

public class DuplicatedEmailException: AppLayerException
{
    public DuplicatedEmailException(): base("The e-email is duplicated.")
    {
    }
}
