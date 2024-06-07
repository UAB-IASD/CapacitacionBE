using System.ComponentModel.DataAnnotations;

namespace AppHub.Infrastructure.Database.EntityFramework.Entities;

public class AllowedCountriesEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
