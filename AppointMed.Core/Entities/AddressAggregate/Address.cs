using System.Data.Entity.Spatial;

namespace AppointMed.Core.Entities.AddressAggregate;

public record Address : BaseEntity
{
    public string Region { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public DbGeography Location { get; set; }
}
