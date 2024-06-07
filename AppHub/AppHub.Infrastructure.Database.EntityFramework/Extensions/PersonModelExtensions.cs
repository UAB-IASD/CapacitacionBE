using AppHub.Domain.Models;
using AppHub.Infrastructure.Database.EntityFramework.Entities;

namespace AppHub.Infrastructure.Database.EntityFramework.Extensions;

public static class PersonModelExtensions
{
    public static PersonEntity ToEntity(this PersonModel model)
    {
        return new PersonEntity()
        {
            Id = model.Id,
            Birthdate = model.Birthdate,
            Email = model.Email,
            Lastname = model.Lastname,
            Name = model.Name,
            PhoneNumber = model.PhoneNumber,
        };
    }
}
