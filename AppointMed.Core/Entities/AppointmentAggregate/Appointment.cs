using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Entities;

public record Appointment : BaseEntity
{
    public Clinic Clinic { get; init; }
    public Address Address { get { return Address; } private set { Address = Clinic.Address; } }
    public Doctor Doctor { get; init; }
    public AppointmentStatus Status { get; set; }
    public DateTime DateTime { get; init; }
}
