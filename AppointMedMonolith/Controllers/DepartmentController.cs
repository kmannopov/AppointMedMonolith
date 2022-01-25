using AppointMed.API.Dtos;
using AppointMed.API.Repositories;
using AppointMed.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppointMed.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController (IDepartmentRepository repository)
    {
        _departmentRepository = repository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentDto>> GetDepartmentAsync(Guid id)
    {
        var department = await _departmentRepository.GetDepartmentAsync(id);
        if (department is null)
            return NotFound();

        return department.AsDto();
    }

    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
    {
        Department department = new()
        {
            Id = Guid.NewGuid(),
            Name = createDepartmentDto.Name,
            CreatedDate = DateTimeOffset.UtcNow
        };
        await _departmentRepository.CreateDepartmentAsync(department);
        return CreatedAtAction(nameof(GetDepartmentAsync), new { id = department.Id }, department.AsDto());
    }
}
