namespace AppointMed.Core.Entities;

public record Address : BaseEntity
{
    public string Region { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
