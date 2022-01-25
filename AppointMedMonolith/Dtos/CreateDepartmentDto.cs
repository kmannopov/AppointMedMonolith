using System.ComponentModel.DataAnnotations;

namespace AppointMed.API.Dtos;

public record CreateDepartmentDto
{
    [Required]
    public string Name { get; set; }
}
