using AppHub.Domain.Models;
using AppHub.Domain.Repositories;
using AppHub.Infrastructure.Database.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AppHub.Infrastructure.Database.EntityFramework.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _dbContext;

    public PersonRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PersonModel> CreatePersonAsync(PersonModel model)
    {
        var result =_dbContext.Person.Add(model.ToEntity());
        _dbContext.SaveChangesAsync();

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
        var result =_dbContext.Person.FirstOrDefault(entity => entity.Email == email);
        return Task.FromResult(result != null);
    }

    public Task<bool> IsNoUniqueUsername(string username)
    {
        var result =_dbContext.Person.FromSqlRaw("SELECT 1 FROM User FROM username = {0}", username).Any();
        return Task.FromResult(!result);
    }

    public Task<AuthenticablePersonModel> CreateAuthenticablePersonAsync(AuthenticablePersonModel model)
    {
        // TODO: Complete it!!
        return Task.FromResult(model);
    }
}
