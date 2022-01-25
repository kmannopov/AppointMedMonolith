using AppointMed.API.Dtos;
using AppointMed.Core.Entities;

namespace AppointMed.API;

public static class Extensions
{
    public static DepartmentDto AsDto(this Department department)
    {
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            CreatedDate = department.CreatedDate
        };
    }
}
