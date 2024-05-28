using AppHub.Domain.Common;
using AppHub.Domain.Models;

namespace AppHub.Domain.Repositories;

public interface IPersonRepository : IRepository
{
    Task<PersonModel> CreatePersonAsync(PersonModel model);
    Task<PersonModel> UpdateAsync(PersonModel model);
    Task DeleteAsync(PersonModel model);
    Task<PersonModel> GetByIdAsync(int identity);
    Task<PersonModel> GetByEmailAsync(string email);
    Task<bool> IsDuplicatedEmail(string email);
    Task<bool> IsNoUniqueUsername(string username);
    Task<AuthenticablePersonModel> CreateAuthenticablePersonAsync(AuthenticablePersonModel model);
}
