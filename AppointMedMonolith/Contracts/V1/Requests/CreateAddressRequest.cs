namespace AppointMed.API.Contracts.V1.Requests;

public record CreateAddressRequest
{
    public string Region { get; init; }
    public string City { get; init; }
    public string District { get; init; }
    public string Street { get; init; }
}
