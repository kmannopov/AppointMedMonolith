using AppointMed.Core.Entities;

namespace AppointMed.API.Repositories;

public interface IDepartmentRepository
{
    Task<Department> GetDepartmentAsync(Guid id);
    Task<IEnumerable<Department>> GetDepartmentsAsync();
    Task CreateDepartmentAsync(Department department);
    Task UpdateDepartmentAsync(Department department);
    Task DeleteDepartmentAsync(Guid id);
}
