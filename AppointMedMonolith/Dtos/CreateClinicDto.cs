using AppointMed.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AppointMed.API.Dtos;

public record CreateClinicDto
{
    [Required]
    public string Name { get; init; }
    public IEnumerable<Department> Departments { get; init; }

}
