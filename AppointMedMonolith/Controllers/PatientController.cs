using AppointMed.API.Contracts.V1;
using AppointMed.API.Contracts.V1.Requests;
using AppointMed.API.Contracts.V1.Responses;
using AppointMed.Core.Entities.UserAggregate;
using AppointMed.Core.Interfaces;
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
    public async Task<IActionResult> Create([FromBody] CreatePatientRequest request)
    {
        var patient = new Patient()
        {
            Id = Guid.NewGuid(),
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
            CreatedDate = DateTimeOffset.UtcNow
        };
        // var patient = await _patientService.CreatePatientAsync(request.FirstName, request.LastName, request.Email, request.PhoneNumber);

        await _patientService.CreatePatientAsync(patient);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Patients.Get.Replace("{patientId}", patient.Id.ToString());
        
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

        return Created(locationUri, patient);
    }
    
}