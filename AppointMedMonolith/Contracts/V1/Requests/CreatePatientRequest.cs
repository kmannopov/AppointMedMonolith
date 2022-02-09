using AppointMed.Core.Entities.AddressAggregate;
using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.API.Contracts.V1.Requests;

public record CreatePatientRequest
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public User.UserGender Gender { get; init; }
    public CreateAddressRequest Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
}
