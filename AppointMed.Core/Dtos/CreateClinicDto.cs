namespace AppointMed.Core.Dtos;

public record CreateClinicDto
{
    public string Name { get; init; }
    public List<CreateDepartmentDto> Departments { get; init; }
    public AddressDto Address { get; init; }
}
