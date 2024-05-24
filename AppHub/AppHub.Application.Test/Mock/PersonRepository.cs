using AppHub.Domain.Models;
using AppHub.Domain.Repositories;

namespace AppHub.Application.Test.Mock;

internal class PersonRepository: IPersonRepository
{
    public Task<PersonModel> InsertAsync(PersonModel model)
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

    public Task<bool> IsEmailDuplicated(string email)
    {
        return Task.FromResult(false);
    }
}
