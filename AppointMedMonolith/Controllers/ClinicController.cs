using AppointMed.API.Contracts.V1;
using AppointMed.API.Extensions;
using AppointMed.Core.Dtos;
using AppointMed.Core.Entities.ClinicAggregate;
using AppointMed.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointMed.API.Controllers;

[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]
public class ClinicController : ControllerBase
{
    private readonly IClinicService _clinicService;

    public ClinicController(IClinicService repository)
    {
        _clinicService = repository;
    }

    [HttpGet(ApiRoutes.Clinics.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _clinicService.GetClinicsAsync());
    }

    [HttpGet(ApiRoutes.Clinics.GetByDept)]
    public async Task<IActionResult> GetByDepartmentName([FromRoute] string deptName)
    {
        var clinics = await _clinicService.GetClinicsByDepartmentAsync(deptName);
        if (clinics == null)
            return NotFound();

        var result = clinics.ToList().MapToClinicDto();

        return Ok(result);
    }

    [HttpGet(ApiRoutes.Clinics.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid clinicId)
    {
        var clinic = await _clinicService.GetClinicByIdAsync(clinicId);

        if (clinic is null)
            return NotFound();

        return Ok(clinic);
    }

    [HttpPost(ApiRoutes.Clinics.Create)]
    public async Task<IActionResult> Create([FromBody] CreateClinicDto request)
    {
        var clinic = new Clinic
        {
            Id = Guid.NewGuid(),
            CreatedDate = DateTimeOffset.UtcNow,
            Address = request.Address.MapToNewAddress(),
            Name = request.Name,
            Departments = request.Departments.MapToDepartmentList()
        };

        await _clinicService.CreateClinicAsync(clinic);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Clinics.Get.Replace("{patientId}", clinic.Id.ToString());

        return Created(locationUri, clinic);
    }

    [HttpPut(ApiRoutes.Clinics.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid clinicId, [FromBody] CreateClinicDto request)
    {
        //TODO Check if this Method can be used to easily validate requests
        //if (!ModelState.IsValid)
        var clinic = await _clinicService.GetClinicByIdAsync(clinicId);

        clinic.Name = request.Name;
        clinic.Address = request.Address.MapToNewAddress();
        clinic.Departments = request.Departments.MapToDepartmentList();

        var updated = await _clinicService.UpdateClinicAsync(clinic);

        if (updated)
            return Ok(clinic);

        return NotFound();
    }
}
