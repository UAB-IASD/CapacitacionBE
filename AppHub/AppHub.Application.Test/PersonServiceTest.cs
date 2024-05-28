using AppHub.Application.Exceptions;
using AppHub.Application.Providers;
using AppHub.Application.Services;
using AppHub.Application.Test.Common;
using AppHub.Domain.Adapters;
using AppHub.Domain.Exceptions;
using AppHub.Domain.Models;
using AppHub.Domain.Repositories;
using Moq;
using Moq.Protected;

namespace AppHub.Application.Test;

[TestClass]
public class PersonServiceTest : TestBase
{
    [TestMethod]
    [ExpectedException(typeof(InvalidStructureEmailException))]
    [DataRow("oscar.quisbert@iatec")]
    [DataRow("oscar.quisbertiatec.com")]
    [DataRow("oscar_quisbertiateccom")]
    public async Task ValidateEmailExceptionTest(string email)
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string phoneNumber = "70593452";
        DateTime birthdate = new DateTime(1989, 01, 23);
        PersonModel personModel = new PersonModel(
            id,
            name,
            lastname,
            email,
            phoneNumber,
            birthdate
        );
        var personService = Resolve<PersonService>();

        await personService.Create(personModel);
    }

    [TestMethod]
    public async Task CreateTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        string phoneNumber = "70593452";
        DateTime birthdate = new DateTime(1989, 01, 23);
        PersonModel personModel = new PersonModel(
            id,
            name,
            lastname,
            email,
            phoneNumber,
            birthdate
        );
        var personService = Resolve<PersonService>();

        var result = await personService.Create(personModel);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task CreateAuthenticablePersonTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        string phoneNumber = "70593452";
        string username = "oscar.quisbert";
        string password = "Pa$$w0rd";
        DateTime birthdate = new DateTime(1989, 01, 23);
        PersonModel personModel = new PersonModel(
            id,
            name,
            lastname,
            email,
            phoneNumber,
            birthdate
        );
        AuthenticablePersonModel authPerson = new AuthenticablePersonModel(personModel, username, password);
        var personService = Resolve<PersonService>();

        var result = await personService.CreateAuthenticable(authPerson);

        Assert.IsNotNull(result);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidPasswordFormatException))]
    public async Task InvalidPasswordPersonExceptionTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        string phoneNumber = "70593452";
        string username = "oscar.quisbert";
        string password = "123456";
        DateTime birthdate = new DateTime(1989, 01, 23);
        AuthenticablePersonModel personModel = new AuthenticablePersonModel(
            id,
            name,
            lastname,
            email,
            phoneNumber,
            birthdate,
            username,
            password
        );
        var personService = Resolve<PersonService>();

        await personService.Create(personModel);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public async Task NullPasswordPersonExceptionTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        string phoneNumber = "70593452";
        string username = "oscar.quisbert";
        string password = "";
        DateTime birthdate = new DateTime(1989, 01, 23);
        AuthenticablePersonModel personModel = new AuthenticablePersonModel(
            id,
            name,
            lastname,
            email,
            phoneNumber,
            birthdate,
            username,
            password
        );
        var personService = Resolve<PersonService>();

        await personService.Create(personModel);
    }
}

[TestClass]
public class PersonServiceMockTest : TestBase
{
    private Mock<IPersonRepository> _personRepositoryMock;
    private Mock<IFakeEmailValidatorProvider> _fakeEmailValidatorProviderMock;
    private Mock<IValidationAdapter> _validationAdapterMock;
    private PersonService _personService;

    [TestInitialize]
    public void Initialize()
    {
        _personRepositoryMock = new Mock<IPersonRepository>();
        _fakeEmailValidatorProviderMock = new Mock<IFakeEmailValidatorProvider>();
        _validationAdapterMock = new Mock<IValidationAdapter>();
        _personService = new PersonService(
            _personRepositoryMock.Object,
            _fakeEmailValidatorProviderMock.Object,
            _validationAdapterMock.Object
        );
    }

    [TestMethod]
    public async Task Create_ValidPersonModel_ReturnsCreatedPerson()
    {
        // Arrange
        var personModel = PersonBuilder.GetPersonWithEmailOnly("test@example.com");
        var validatedEmail = "test@example.com";
        _validationAdapterMock.Setup(v => v.ValidatedEmail(personModel.Email)).Returns(validatedEmail);
        _personRepositoryMock.Setup(r => r.IsDuplicatedEmail(personModel.Email)).ReturnsAsync(false);
        _fakeEmailValidatorProviderMock.Setup(f => f.IsNoFakeEmail(personModel.Email)).ReturnsAsync(true);
        var expectedPerson = PersonBuilder.GetEmptyPerson();
        _personRepositoryMock.Setup(r => r.CreatePersonAsync(personModel)).ReturnsAsync(expectedPerson);

        // Act
        var result = await _personService.Create(personModel);

        // Assert
        Assert.AreEqual(expectedPerson, result);
    }

    [TestMethod]
    [ExpectedException(typeof(DuplicatedEmailException))]
    public async Task Create_DuplicatedEmail_ThrowsDuplicatedEmailException()
    {
        // Arrange
        var personModel = PersonBuilder.GetPersonWithEmailOnly("test@example.com");
        var validatedEmail = "test@example.com";
        _validationAdapterMock.Setup(v => v.ValidatedEmail(personModel.Email)).Returns(validatedEmail);
        _personRepositoryMock.Setup(r => r.IsDuplicatedEmail(personModel.Email)).ReturnsAsync(true);

        // Act
        await _personService.Create(personModel);
    }

    [TestMethod]
    [ExpectedException(typeof(FakeEmailException))]
    public async Task Create_InvalidEmail_ThrowsInvalidEmailException()
    {
        // Arrange
        var personModel = PersonBuilder.GetPersonWithEmailOnly("invalid-email");
        _personRepositoryMock.Setup(r => r.IsDuplicatedEmail(personModel.Email)).ReturnsAsync(false);
        _fakeEmailValidatorProviderMock.Setup(f => f.IsNoFakeEmail(personModel.Email)).ReturnsAsync(false);

        // Act
        await _personService.Create(personModel);
    }
}

public static class PersonBuilder
{
    public static PersonModel GetEmptyPerson()
    {
        return new PersonModel(Guid.Empty, string.Empty, string.Empty, string.Empty, "123456789", DateTime.MinValue);
    }

    public static PersonModel GetPersonWithEmailOnly(string email)
    {
        return new PersonModel(Guid.Empty, string.Empty, string.Empty, email, "123456789", DateTime.MinValue);
    }
}
