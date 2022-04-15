using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMed.Core.Dtos;

public record ClinicDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public List<DepartmentDto> Departments { get; init; }
    public AddressDto Address { get; init; }
}
