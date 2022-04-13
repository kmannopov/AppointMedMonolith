using AppointMed.API.Contracts.V1;
using AppointMed.API.Extensions;
using AppointMed.Core.Dtos;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AppointMed.Infrastructure.Settings.Policies;

namespace AppointMed.API.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
public class DoctorController : Controller
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet(ApiRoutes.Doctors.Get)]
    [Authorize(Roles = "Patient,Doctor")]
    public async Task<IActionResult> Get([FromRoute] string doctorId)
    {
        var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);

        if (doctor is null)
            return NotFound();

        return Ok(doctor.MapToDoctorDto());
    }

    [HttpGet(ApiRoutes.Doctors.GetByDept)]
    [AllowAnonymous]
    public async Task<IActionResult> GetByDepartmentName([FromRoute] Guid deptId)
    {
        var doctors = await _doctorService.GetAllDoctorsByDeptInClinicAsync(deptId.ToString());
        if (doctors == null)
            return NotFound();
        return Ok(doctors);
    }

    [HttpPost(ApiRoutes.Doctors.Create)]
    public async Task<IActionResult> Create([FromBody] CreateDoctorDto request)
    {
        var doctorExists = await _doctorService.GetDoctorByIdAsync(HttpContext.GetUserId());

        if (doctorExists is not null)
            return BadRequest(new { error = "You have already created a doctor profile." });

        var doctor = request.MapToNewDoctor(HttpContext);

        await _doctorService.CreateDoctorAsync(doctor);

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Doctors.Get.Replace("{doctorId}", doctor.UserId.ToString());

        return Created(locationUri, doctor.MapToDoctorDto());
    }

    [HttpPut(ApiRoutes.Doctors.Update)]
    public async Task<IActionResult> Update([FromBody] CreateDoctorDto request)
    {
        var id = HttpContext.GetUserId();
        var userIsDoctor = await _doctorService.UserIsDoctorAsync(id);

        if (!userIsDoctor)
            return BadRequest(new { error = "You are not the owner of this doctor profile." });

        var doctor = await _doctorService.GetDoctorByIdAsync(id);

        doctor.MapToExistingDoctor(request);
        //TODO: Change IdentityUser Email as well

        var updated = await _doctorService.UpdateDoctorAsync(doctor);

        if (updated)
            return Ok(doctor.MapToDoctorDto());

        return NotFound();
    }

    [HttpPut(ApiRoutes.Doctors.UpdateWorkplace)]
    public async Task<IActionResult> UpdateWorkplace([FromRoute] Guid doctorId, [FromBody] UpdateDoctorWorkplaceDto request)
    {

        var doctor = await _doctorService.GetDoctorByIdAsync(doctorId.ToString());

        doctor.ClinicId = request.ClinicId.ToString();
        doctor.DepartmentId = request.DepartmentId.ToString();
        //TODO: Change IdentityUser Email as well

        var updated = await _doctorService.UpdateDoctorAsync(doctor);

        if (updated)
            return Ok(doctor);

        return NotFound();
    }
}
