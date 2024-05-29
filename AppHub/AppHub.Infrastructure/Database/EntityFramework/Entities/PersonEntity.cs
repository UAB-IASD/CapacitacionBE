using AppHub.Domain.Models;

namespace AppHub.Infrastructure.Database.EntityFramework.Entities;

public class PersonEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthdate { get; set; }

    public PersonModel ToModel()
    {
        return new PersonModel(
            this.Id,
            this.Name,
            this.Lastname,
            this.Email,
            this.PhoneNumber,
            this.Birthdate
        );
    }
}
