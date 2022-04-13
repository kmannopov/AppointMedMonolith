namespace AppointMed.Core.Entities.AppointmentAggregate;

public record Appointment : BaseEntity
{
    public Guid ClinicId { get; init; }
    public string ClinicName { get; init; }
    public Guid DoctorId { get; init; }
    public string DoctorName { get; init; }
    public Guid PatientId { get; init; }
    public string Status { get; set; }
    public DateTime DateTime { get; init; }
    public string Notes { get; set; }
}
