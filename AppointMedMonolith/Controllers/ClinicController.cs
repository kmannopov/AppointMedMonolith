using AppointMed.API.Contracts.V1;
using AppointMed.Core.Entities.ClinicAggregate;
using AppointMed.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointMed.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

    [HttpGet(ApiRoutes.Clinics.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid clinicId)
    {
        var clinic = await _clinicService.GetClinicByIdAsync(clinicId);

        if (clinic is null)
            return NotFound();

        return Ok(clinic);
    }

    //[HttpGet(ApiRoutes.Clinics.Create)]
    //public async Task<IActionResult> Create([FromRoute] CreateClinicRequest request)
    //{
    //    var clinic = await _clinicService.CreateClinicAsync(request);

    //    if (clinic is null)
    //        return NotFound();

    //    return Ok(clinic);
    //}
}
