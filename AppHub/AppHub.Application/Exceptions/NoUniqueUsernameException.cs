using AppHub.Application.Common;

namespace AppHub.Application.Exceptions;

public class NoUniqueUsernameException : AppLayerException
{
    public NoUniqueUsernameException(string username) : base($"The {username} already exists.")
    {
    }
}
