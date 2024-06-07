namespace AppHub.Domain.Dto;

public class AuthenticablePersonDto : PersonDto
{
    public string Username { get; private set; }
    public string Password { get; private set; }
}
