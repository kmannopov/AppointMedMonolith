using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Entities.AppointmentAggregate;

public record Appointment : BaseEntity
{
    public Guid ClinicId { get; init; }
    public Guid DoctorId { get; init; }
    public Guid PatientId { get; init; }
    public AppointmentStatus Status { get; set; }
    public DateTime DateTime { get; init; }
    public string Notes { get; init; }

    public enum AppointmentStatus
    {
        Scheduled,
        CheckedIn,
        Complete,
        Cancelled
    }
}
