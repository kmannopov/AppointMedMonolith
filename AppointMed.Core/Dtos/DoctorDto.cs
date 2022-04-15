using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Dtos;

public record DoctorDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string Gender { get; init; }
    public string PhoneNumber { get; init; }
    [EmailAddress]
    public string Email { get; init; }
    public string? ClinicId { get; init; }
    public string? DepartmentId { get; init; }
}
