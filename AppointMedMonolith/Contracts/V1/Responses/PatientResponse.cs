using AppointMed.Core.Entities;
using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.API.Contracts.V1.Responses;

public class PatientResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public User.UserGender Gender { get; set; }
    public Address Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}