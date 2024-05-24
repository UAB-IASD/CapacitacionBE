using AppHub.Domain.Exceptions;
using AppHub.Domain.Models;

namespace AppHub.Domain.Test;

[TestClass]
public class PersonModelTest
{
    [TestMethod]
    public void ValidCreatePersonModel()
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        string phoneNumber = "70593452";
        DateTime birthdate = new DateTime(1989, 01, 23);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);

        Assert.IsNotNull(result);
        Assert.AreEqual(id, result.Id);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidPhoneNumberException))]
    [DataRow("70593452~")]
    [DataRow("+70593452/")]
    [DataRow("+ 59170593.452")]
    [DataRow("+ 591 705-93452")]
    [DataRow("+ 591 705934 = 5278563920")]
    public void ValidatePhoneNumberExceptionTest(string phoneNumber)
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        DateTime birthdate = new DateTime(1989, 01, 23);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidBirthdateException))]
    public void ValidateBirthdateExceptionTest()
    {
        Guid id = Guid.NewGuid();
        string name = "Oscar";
        string lastname = "Quisbert";
        string email = "oscar.quisbert@iatec.com";
        string phoneNumber = "70593452";
        DateTime birthdate = new DateTime(2020, 1, 1);

        PersonModel result = new PersonModel(id, name, lastname, email, phoneNumber, birthdate);
    }
}
