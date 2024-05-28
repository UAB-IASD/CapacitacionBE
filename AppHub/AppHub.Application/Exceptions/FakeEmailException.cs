using AppHub.Application.Common;

namespace AppHub.Application.Exceptions;

public class FakeEmailException : AppLayerException
{
    public FakeEmailException() : base("The e-mail is not a queryable e-mail")
    {
    }
}
