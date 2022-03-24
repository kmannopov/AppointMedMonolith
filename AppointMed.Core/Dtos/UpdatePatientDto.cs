using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Dtos;

public record UpdatePatientDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public User.UserGender Gender { get; init; }
    public UpdateAddressDto Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Email { get; init; }
}
