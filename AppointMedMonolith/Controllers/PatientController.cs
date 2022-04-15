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
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Patient")]

public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    
    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }
    


    [HttpGet(ApiRoutes.Patients.Get)]
    [Authorize(Roles = "Patient,Doctor")]
    public async Task<IActionResult> Get([FromRoute] string patientId)
    {
        var patient = await _patientService.GetPatientByIdAsync(patientId);

        if (patient is null)
            return NotFound();

        return Ok(patient.MapToPatientDto());
    }

    [HttpPost(ApiRoutes.Patients.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePatientDto request)
    {
        var patientExists = await _patientService.GetPatientByIdAsync(HttpContext.GetUserId());

        if (patientExists is not null)
            return BadRequest(new { error = "You have already created a patient profile." });

        var patient = request.MapToNewPatient(HttpContext);

        var created = await _patientService.CreatePatientAsync(patient);

        if (!created)
            return BadRequest();

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Patients.Get.Replace("{patientId}", patient.UserId.ToString());

        return Created(locationUri, patient.MapToPatientDto());
    }

    [HttpPut(ApiRoutes.Patients.Update)]
    public async Task<IActionResult> Update([FromBody] CreatePatientDto request)
    {
        var id = HttpContext.GetUserId();
        var userIsPatient = await _patientService.UserIsPatientAsync(id);

        if (!userIsPatient)
            return BadRequest(new { error = "You are not the owner of this patient profile." });

        var patient = await _patientService.GetPatientByIdAsync(id);

        var updatedPatient = patient.MapToExistingPatient(request);
        //TODO: Change IdentityUser Email as well

        var updated = await _patientService.UpdatePatientAsync(updatedPatient);

        if (updated)
            return Ok(updatedPatient.MapToPatientDto());

        return NotFound();
    }

}