namespace AppointMed.Core.Entities.UserAggregate;

public record Patient : User
{
    public Address Address { get; set; }
}
