namespace AppointMed.API.Dtos;

public record DepartmentDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
