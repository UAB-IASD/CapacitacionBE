using System.Text.RegularExpressions;
using AppHub.Domain.Exceptions;

namespace AppHub.Domain.Models;

public class PersonModel
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Lastname { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime Birthdate { get; private set; }

    public PersonModel(
        Guid id,
        string name,
        string lastname,
        string email,
        string phoneNumber,
        DateTime birthdate
    )
    {
        Id = id;
        Name = name;
        Lastname = lastname;
        Email = email;
        PhoneNumber = ValidatedPhone(phoneNumber);
        Birthdate = ValidateBirthDay(birthdate);
    }

    public void UpdatePhone(string phoneNumber) => PhoneNumber = ValidatedPhone(phoneNumber);
    public void SetEmail(string email) => Email = email;

    private static DateTime ValidateBirthDay(DateTime birthdate)
    {
        if ((DateTime.Now.Year - birthdate.Year) <= 15)
            throw new InvalidBirthdateException();
        return birthdate;
    }

    private static string ValidatedPhone(string phoneNumber)
    {
        if (!IsPhoneNumber(phoneNumber))
            throw new InvalidPhoneNumberException();
        return phoneNumber;
    }

    private static bool IsPhoneNumber(string number)
    {
        return Regex.Match(number, @"^(\+?\s?[0-9\s?]+)$").Success;
    }
}
