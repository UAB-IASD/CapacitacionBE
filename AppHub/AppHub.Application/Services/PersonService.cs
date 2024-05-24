using AppHub.Application.Exceptions;
using AppHub.Application.Providers;
using AppHub.Domain.Adapters;
using AppHub.Domain.Models;
using AppHub.Domain.Repositories;

namespace AppHub.Application.Services;

public class PersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IEmailValidatorProvider _emailValidatorProvider;
    private readonly IValidationAdapter _validationAdapter;

    public PersonService(
        IPersonRepository personRepository,
        IEmailValidatorProvider emailValidatorProvider,
        IValidationAdapter validationAdapter
    )
    {
        _personRepository = personRepository;
        _emailValidatorProvider = emailValidatorProvider;
        _validationAdapter = validationAdapter;
    }

    public async Task<PersonModel> Create(PersonModel personModel)
    {
        personModel.SetEmail(
            _validationAdapter.ValidatedEmail(personModel.Email)
        );

        if (await _personRepository.IsEmailDuplicated(personModel.Email))
            throw new DuplicatedEmailException();

        if (!await _emailValidatorProvider.IsEmailValid(personModel.Email))
            throw new InvalidEmailException();

        return await _personRepository.InsertAsync(personModel);
    }
}
