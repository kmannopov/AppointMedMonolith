using AppointMed.Core.Entities.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace AppointMed.Core.Dtos;

public record CreatePatientDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string Gender { get; init; }
    public AddressDto Address { get; init; }
    public string PhoneNumber { get; init; }
}
