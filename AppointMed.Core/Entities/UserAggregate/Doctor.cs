using AppointMed.Core.Entities.ClinicAggregate;

namespace AppointMed.Core.Entities.UserAggregate;

public record Doctor : User
{
    public Guid ClinicId { get; set; }
    public Department Department { get; set; }

}
