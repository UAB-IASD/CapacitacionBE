using AppHub.Domain.Models;
using AppHub.Domain.Repositories;
using AppHub.Infrastructure.Database.EntityFramework.Entities;
using AppHub.Infrastructure.Database.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AppHub.Infrastructure.Database.EntityFramework.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppHubDbContext _hubDbContext;

    public PersonRepository(AppHubDbContext hubDbContext)
    {
        _hubDbContext = hubDbContext;
    }

    public Task<PersonModel> CreatePersonAsync(PersonModel model)
    {
        var result = _hubDbContext.Person.Add(model.ToEntity());
        _hubDbContext.SaveChangesAsync();

        return Task.FromResult(result.Entity.ToModel());
    }

    public Task<PersonModel> UpdateAsync(PersonModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(PersonModel model)
    {
        throw new NotImplementedException();
    }

    public Task<PersonModel> GetByIdAsync(int identity)
    {
        throw new NotImplementedException();
    }

    public Task<PersonModel> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsDuplicatedEmail(string email)
    {
        var result = _hubDbContext.Person.FirstOrDefault(entity => entity.Email == email);
        return Task.FromResult(result != null);
    }

    public Task<bool> IsNoUniqueUsername(string username)
    {
        var result = _hubDbContext.AuthPerson.FromSqlRaw("SELECT Username FROM dbo.AuthPerson WHERE Username = {0}", username).Count();
        return Task.FromResult(result > 0);
    }

    public Task<AuthenticablePersonModel> CreateAuthenticablePersonAsync(AuthenticablePersonModel model)
    {
        _hubDbContext.Database.ExecuteSqlRaw(
            "INSERT INTO dbo.Person (Id, Name, Lastname, Email, PhoneNumber, Birthdate) VALUES({0}, {1}, {2}, {3}, {4}, {5})",
            model.Id,
            model.Name,
            model.Lastname,
            model.Email,
            model.PhoneNumber,
            model.Birthdate
        );

        _hubDbContext.Database.ExecuteSqlRaw(
            "INSERT INTO dbo.AuthPerson (Username, Password, PersonId) VALUES({0}, {1}, {2})",
            model.Username,
            model.Password,
            model.Id
        );

        return Task.FromResult(model);
    }

    public Task<AuthenticablePersonModel> GetAuthPersonByIdAsync(Guid identity)
    {
        var person = (from p in _hubDbContext.Person
            join ap in _hubDbContext.AuthPerson
                on p.Id equals ap.PersonId
            where p.Id == identity
            select new AuthenticablePersonModel(
                p.Id,
                p.Name,
                p.Lastname,
                p.Email,
                p.PhoneNumber,
                p.Birthdate,
                ap.Username,
                ap.Password
            )).FirstOrDefault();

        var person1 = _hubDbContext.Person
            .Join(_hubDbContext.AuthPerson,
                p => p.Id,
                ap => ap.PersonId,
                (p, ap) => new AuthenticablePersonModel(
                    p.Id,
                    p.Name,
                    p.Lastname,
                    p.Email,
                    p.PhoneNumber,
                    p.Birthdate,
                    ap.Username,
                    ap.Password
                )
            ).First();

        return Task.FromResult(person1);
    }
}
