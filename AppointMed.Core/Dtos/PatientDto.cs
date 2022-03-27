using AppointMed.Core.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace AppointMed.Core.Dtos;

public record PatientDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public User.UserGender Gender { get; init; }
    public AddressDto Address { get; init; }
    public string PhoneNumber { get; init; }
    [EmailAddress]
    public string Email { get; init; }
}
