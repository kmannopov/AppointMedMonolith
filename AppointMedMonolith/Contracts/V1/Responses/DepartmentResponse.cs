namespace AppointMed.API.Dtos;

public record DepartmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
