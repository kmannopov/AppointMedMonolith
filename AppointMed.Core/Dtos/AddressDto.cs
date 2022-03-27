namespace AppointMed.Core.Dtos;

public record AddressDto
{
    public string Region { get; init; }
    public string City { get; init; }
    public string District { get; init; }
    public string Street { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
}
