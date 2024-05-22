using System.Net.Mail;
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
        Email = ValidatedEmail(email);
        PhoneNumber = ValidatePhone(phoneNumber);
        Birthdate = ValidateBirthDay(birthdate);
    }

    public void UpdatePhone(string phoneNumber) => PhoneNumber = ValidatePhone(phoneNumber);

    private static string ValidatedEmail(string email)
    {
        if(!new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email).Success)
            throw new InvalidEmailException();
        
        return email;
    }

    private static DateTime ValidateBirthDay(DateTime birthdate)
    {
        if((DateTime.Now.Year - birthdate.Year) <= 15)
            throw new InvalidBirthdateException();
        return birthdate;
    }

    private static string ValidatePhone(string phoneNumber)
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