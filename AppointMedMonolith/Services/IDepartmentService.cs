using AppointMed.Core.Entities;

namespace AppointMed.API.Repositories;

public interface IDepartmentService
{
    Task<Department> GetDepartmentByIdAsync(Guid id);
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task<bool> CreateDepartmentAsync(Department department);
    Task<bool> UpdateDepartmentAsync(Department department);
    Task<bool> DeleteDepartmentAsync(Guid id);
}
