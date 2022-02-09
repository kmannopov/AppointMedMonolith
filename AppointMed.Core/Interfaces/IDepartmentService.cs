using AppointMed.Core.Entities.ClinicAggregate;

namespace AppointMed.Core.Interfaces;

public interface IDepartmentService
{
    Task<Department> GetDepartmentByIdAsync(Guid id);
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task<bool> CreateDepartmentAsync(Department department);
    Task<bool> UpdateDepartmentAsync(Department department);
    Task<bool> DeleteDepartmentAsync(Guid id);
}
