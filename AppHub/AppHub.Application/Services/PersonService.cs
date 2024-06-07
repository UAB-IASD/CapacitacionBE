using AppHub.Application.Exceptions;
using AppHub.Application.Providers;
using AppHub.Domain.Adapters;
using AppHub.Domain.Models;
using AppHub.Domain.Repositories;

namespace AppHub.Application.Services;

public class PersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IFakeEmailValidatorProvider _fakeEmailValidatorProvider;
    private readonly IValidationAdapter _validationAdapter;

    public PersonService(
        IPersonRepository personRepository,
        IFakeEmailValidatorProvider fakeEmailValidatorProvider,
        IValidationAdapter validationAdapter
    )
    {
        _personRepository = personRepository;
        _fakeEmailValidatorProvider = fakeEmailValidatorProvider;
        _validationAdapter = validationAdapter;
    }

    public async Task<PersonModel> Create(PersonModel personModel)
    {
        var validatedEmail = _validationAdapter.ValidatedEmail(personModel.Email);
        personModel.SetEmail(validatedEmail);

        if (await _personRepository.IsDuplicatedEmail(personModel.Email))
            throw new DuplicatedEmailException();

        if (!await _fakeEmailValidatorProvider.IsNoFakeEmail(personModel.Email))
            throw new FakeEmailException();

        return await _personRepository.CreatePersonAsync(personModel);
    }

    public async Task<AuthenticablePersonModel> CreateAuthenticable(AuthenticablePersonModel personModel)
    {
        if (await _personRepository.IsNoUniqueUsername(personModel.Username))
            throw new NoUniqueUsernameException(personModel.Username);

        return await _personRepository.CreateAuthenticablePersonAsync(personModel);
    }

    public Task<AuthenticablePersonModel> GetAuthPersonByIdAsync(Guid identity)
    {
        return _personRepository.GetAuthPersonByIdAsync(identity);
    }
}
