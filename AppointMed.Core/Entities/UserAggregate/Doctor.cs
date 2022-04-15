namespace AppointMed.Core.Entities.UserAggregate;

public record Doctor : User
{
    public string ClinicId { get; set; }
    public string DepartmentId { get; set; }

}
