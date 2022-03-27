using AppointMed.API.Contracts.V1;
using AppointMed.API.Extensions;
using AppointMed.Core.Dtos;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointMed.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    


    [HttpGet(ApiRoutes.Patients.Get)]
    public async Task<IActionResult> Get([FromRoute] string patientId)
    {
        var patient = await _patientService.GetPatientByIdAsync(patientId);

        if (patient is null)
            return NotFound();

        return Ok(patient);
    }

    [HttpPost(ApiRoutes.Patients.Create)]
    public async Task<IActionResult> Create([FromBody] PatientDto request)
    {
        var patientExists = await _patientService.GetPatientByIdAsync(HttpContext.GetUserId());

        if (patientExists is not null)
            return BadRequest(new { error = "You have already created a patient profile." });

        var patient = request.MapToNewPatient(HttpContext);

        await _patientService.CreatePatientAsync(patient);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Patients.Get.Replace("{patientId}", patient.UserId.ToString());

        return Created(locationUri, patient.MapToPatientResponse());
    }

    [HttpPut(ApiRoutes.Patients.Update)]
    public async Task<IActionResult> Update([FromBody] PatientDto request)
    {
        var id = HttpContext.GetUserId();
        var userIsPatient = await _patientService.UserIsPatientAsync(id);

        if (!userIsPatient)
            return BadRequest(new { error = "You are not the owner of this patient profile." });

        var patient = await _patientService.GetPatientByIdAsync(id);

        patient.MapToExistingPatient(request);
        //TODO: Change IdentityUser Email as well

        var updated = await _patientService.UpdatePatientAsync(patient);

        if (updated)
            return Ok(patient.MapToPatientResponse());

        return NotFound();
    }

}