using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using AppHub.Domain.Exceptions;

namespace AppHub.Domain.Models;

public class AuthenticablePersonModel : PersonModel
{
    public string Username { get; private set; }
    public string Password { get; private set; }

    [JsonConstructor]
    public AuthenticablePersonModel(
        Guid id,
        string name,
        string lastname,
        string email,
        string phoneNumber,
        DateTime birthdate,
        string username,
        string password
    ) : base(id, name, lastname, email, phoneNumber, birthdate)
    {
        Username = username;
        Password = GetValidatedPassword(password);
    }

    public AuthenticablePersonModel(
        PersonModel person,
        string username,
        string password
    ) : base(person.Id, person.Name, person.Lastname, person.Email, person.PhoneNumber, person.Birthdate)
    {
        Username = username;
        Password = GetValidatedPassword(password);
    }

    private static string GetValidatedPassword(string password)
    {
        if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

        Regex regexp = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[-+_!@#$%^&*., ?]).+$");
        Match matcher = regexp.Match(password);
        if (!matcher.Success) throw new InvalidPasswordFormatException();

        return password;
    }
}
