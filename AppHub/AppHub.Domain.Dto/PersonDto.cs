namespace AppHub.Domain.Dto;

public class PersonDto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Lastname { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime Birthdate { get; private set; }
}
