using AppointMed.API.Dtos;
using AppointMed.Core.Entities;

namespace AppointMed.API;

public static class Extensions
{
    public static DepartmentResponse AsDto(this Department department)
    {
        return new DepartmentResponse
        {
            Id = department.Id,
            Name = department.Name,
            CreatedDate = department.CreatedDate
        };
    }
}
