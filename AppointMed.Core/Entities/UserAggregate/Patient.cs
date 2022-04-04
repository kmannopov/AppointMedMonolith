namespace AppointMed.Core.Entities.UserAggregate;

public record Patient : User
{
    public Address Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}
