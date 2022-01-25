using AppointMed.API.Data;
using AppointMed.Core.Entities;

namespace AppointMed.API.Repositories;

public class DepartmentService : IDepartmentService
{
    private readonly DataContext _dataContext;

    public DepartmentService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Task<bool> CreateDepartmentAsync(Department department)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteDepartmentAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Department> GetDepartmentByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Department>> GetDepartmentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateDepartmentAsync(Department department)
    {
        throw new NotImplementedException();
    }
}
