namespace AppointMed.Core.Dtos;

public record UpdateAddressDto
{
    public string Region { get; init; }
    public string City { get; init; }
    public string District { get; init; }
    public string Street { get; init; }
}
