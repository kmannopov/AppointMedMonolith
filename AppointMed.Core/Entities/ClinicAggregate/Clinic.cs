namespace AppointMed.Core.Entities.ClinicAggregate;

public record Clinic : BaseEntity
{
    public string Name { get; set; }
    public List<Department> Departments { get; set; }
    public Address Address { get; set; }
}
