namespace AppointMed.API.Contracts.V1.Responses;

public record DepartmentResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTimeOffset CreatedDate { get; init; }
}
