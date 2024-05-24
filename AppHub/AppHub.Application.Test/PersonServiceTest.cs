using AppHub.Application.Services;
using AppHub.Application.Test.Common;
using AppHub.Domain.Models;

namespace AppHub.Application.Test;

[TestClass]
public class PersonServiceTest : TestBase
{
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
        var personService = base.Resolve<PersonService>();

        var result = await personService.Create(personModel);

        Assert.IsNotNull(result);
    }
}
