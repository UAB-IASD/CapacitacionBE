using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AppHub.Infrastructure.Database.EntityFramework.Entities;

[Keyless]
public class AuthPersonEntity
{
    [MaxLength(50)] public string Username { get; set; } = string.Empty;
    [MaxLength(255)] public string Password { get; set; } = string.Empty;
    public Guid PersonId { get; set; }
}
