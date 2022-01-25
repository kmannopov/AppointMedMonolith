using AppointMed.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppointMed.API.Dtos;

public record CreateClinicRequest
{
    [Required]
    public string Name { get; init; }
    public IEnumerable<Department> Departments { get; init; }
    public Address Address { get; init; }
    public Location Location { get; init; }

}
