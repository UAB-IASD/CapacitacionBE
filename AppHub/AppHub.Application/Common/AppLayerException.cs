namespace AppHub.Application.Common;

public class AppLayerException: Exception
{
    public AppLayerException(string? message) : base(message)
    {
    }

    public AppLayerException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
