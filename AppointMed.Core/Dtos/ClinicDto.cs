namespace AppointMed.Core.Dtos;

public record ClinicDto
{
    public string Name { get; init; }
    public List<DepartmentDto> Departments { get; init; }
    public AddressDto Address { get; init; }
}
