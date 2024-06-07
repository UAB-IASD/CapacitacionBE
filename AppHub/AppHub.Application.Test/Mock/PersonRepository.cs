using AppHub.Domain.Models;
using AppHub.Domain.Repositories;

namespace AppHub.Application.Test.Mock;

internal class PersonRepository : IPersonRepository
{
    public Task<PersonModel> CreatePersonAsync(PersonModel model)
    {
        return Task.FromResult(model);
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
        return Task.FromResult(false);
    }

    public Task<bool> IsNoUniqueUsername(string username)
    {
        return Task.FromResult(false);
    }

    public Task<AuthenticablePersonModel> CreateAuthenticablePersonAsync(AuthenticablePersonModel model)
    {
        return Task.FromResult(model);
    }

    public Task<AuthenticablePersonModel> GetAuthPersonByIdAsync(Guid identity)
    {
        throw new NotImplementedException();
    }
}
