using AppointMed.API.Contracts.V1;
using AppointMed.API.Contracts.V1.Responses;
using AppointMed.Core.Dtos;
using AppointMed.Core.Entities.UserAggregate;
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
    public async Task<IActionResult> Get([FromRoute] Guid patientId)
    {
        var patient = await _patientService.GetPatientByIdAsync(patientId);

        if (patient is null)
            return NotFound();

        return Ok(patient);
    }
    
    [HttpPost(ApiRoutes.Patients.Create)]
    public async Task<IActionResult> Create([FromBody] CreatePatientDto request)
    {
        var patient = new Patient()
        {
            UserId = HttpContext.GetUserId(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Gender = request.Gender,
            Address = new()
            {
                CreatedDate = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid(),
                Region = request.Address.Region,
                City = request.Address.City,
                District = request.Address.District,
                Street = request.Address.Street,
            },
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            DateRegistered = DateTimeOffset.UtcNow
        };

        await _patientService.CreatePatientAsync(patient);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Patients.Get.Replace("{patientId}", patient.UserId.ToString());
        
        var response = new PatientResponse
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth,
            Gender = patient.Gender,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email
        };

        return Created(locationUri, response);
    }

    [HttpPut(ApiRoutes.Patients.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid patientId, [FromBody] UpdatePatientDto request)
    {
        var patient = await _patientService.GetPatientByIdAsync(patientId);

        var userIsPatient = await _patientService.UserIsPatientAsync(HttpContext.GetUserId());

        if (!userIsPatient)
            return BadRequest(new { error = "You are not the owner of this patient profile" });

        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.DateOfBirth = request.DateOfBirth;
        patient.Gender = request.Gender;
        patient.Address.Region = request.Address.Region;
        patient.Address.City = request.Address.City;
        patient.Address.District = request.Address.District;
        patient.Address.Street = request.Address.Street;
        patient.PhoneNumber = request.PhoneNumber;
        patient.Email = request.Email;

        var response = new PatientResponse
        {
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            DateOfBirth = patient.DateOfBirth,
            Gender = patient.Gender,
            Address = patient.Address,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email
        };

        var updated = await _patientService.UpdatePatientAsync(patient);

        if (updated)
            return Ok(response);

        return NotFound();
    }

}