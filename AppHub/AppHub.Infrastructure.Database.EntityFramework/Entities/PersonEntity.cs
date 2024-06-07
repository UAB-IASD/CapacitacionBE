using System.ComponentModel.DataAnnotations;
using AppHub.Domain.Models;

namespace AppHub.Infrastructure.Database.EntityFramework.Entities;

public sealed class PersonEntity
{
    [Key] public Guid Id { get; set; }
    [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [MaxLength(100)] public string Lastname { get; set; } = string.Empty;
    [MaxLength(255)] public string Email { get; set; } = string.Empty;
    [MaxLength(20)] public string PhoneNumber { get; set; } = string.Empty;
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

    public class FileEntity
    {
        public string Path { get; set; } = "uab://AppHub/Client/9c776de9-fc90-4629-99c9-6abdf5b85bcb";
    }
}
