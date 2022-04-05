namespace AppointMed.Core.Entities.UserAggregate;

public record Doctor : User
{
    public Guid ClinicId { get; set; }
    public Guid DepartmentId { get; set; }

}
