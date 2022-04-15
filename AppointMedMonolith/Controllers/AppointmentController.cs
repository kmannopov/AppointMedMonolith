
using AppointMed.API.Contracts.V1;
using AppointMed.Core.Dtos;
using AppointMed.Core.Entities.AppointmentAggregate;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointMed.API.Controllers;


[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IDoctorService _doctorService;
    private readonly IClinicService _clinicService;
    private readonly IPatientService _patientService;

    public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, IClinicService clinicService, IPatientService patientService)
    {
        _appointmentService = appointmentService;
        _doctorService = doctorService;
        _clinicService = clinicService;
        _patientService = patientService;
    }

    [HttpGet(ApiRoutes.Appointments.GetAllForPatient)]
    public async Task<IActionResult> GetAllForPatient([FromRoute] Guid userId)
    {
        var realId = HttpContext.GetUserId();
        var userIsPatient = userId.ToString() == realId;

        if (!userIsPatient)
            return BadRequest(new { error = "You do not have access to this user's appointments." });

        return Ok(await _appointmentService.GetPatientAppointmentList(userId));
    }

    [HttpGet(ApiRoutes.Appointments.GetAllForDoctor)]
    public async Task<IActionResult> GetAllForDoctor([FromRoute] Guid userId)
    {
        var realId = HttpContext.GetUserId();
        var userIsDoctor = userId.ToString() == realId;

        if (!userIsDoctor)
            return BadRequest(new { error = "You do not have access to this user's appointments." });

        return Ok(await _appointmentService.GetDoctorAppointmentList(userId));
    }

    [HttpGet(ApiRoutes.Appointments.GetSlots)]
    public async Task<IActionResult> GetAvailableSlots([FromRoute] Guid doctorId)
    {
        return Ok(await _appointmentService.GetFreeSlots(doctorId));
    }

    [HttpPost(ApiRoutes.Appointments.Create)]
    public async Task<IActionResult> Create([FromBody] AppointmentDto request)
    {
        var realId = HttpContext.GetUserId();
        var userIsPatient = request.PatientId.ToString() == realId;

        if (!userIsPatient)
            return BadRequest(new { error = "You can only book appointments for yourself." });

        var doctor = await _doctorService.GetDoctorByIdAsync(request.DoctorId.ToString());
        var clinic = await _clinicService.GetClinicByIdAsync(Guid.Parse(doctor.ClinicId));
        var patient = await _patientService.GetPatientByIdAsync(request.PatientId.ToString());

        var appointment = new Appointment
        {
            CreatedDate = DateTimeOffset.UtcNow,
            Id = Guid.NewGuid(),
            PatientId = request.PatientId,
            PatientName = $"{patient.FirstName} {patient.LastName}",
            ClinicId = clinic.Id,
            ClinicName = clinic.Name,
            DateTime = request.DateTime,
            DoctorId = request.DoctorId,
            DoctorName = $"{doctor.FirstName} {doctor.LastName}",
            Notes = request.Notes,
            Status = "Scheduled"
        };

        var created = await _appointmentService.CreateNewAppointment(appointment);

        if (!created)
            return BadRequest();

        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
        var locationUri = baseUrl + "/" + ApiRoutes.Doctors.Get.Replace("{doctorId}", appointment.Id.ToString());

        return Created(locationUri, appointment);
    }

    [HttpPut(ApiRoutes.Appointments.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid appointmentId, [FromBody] string status)
    {
        var appointment = await _appointmentService.GetAppointment(appointmentId);

        if (appointment == null)
        {
            return BadRequest();
        }
        var realId = HttpContext.GetUserId();
        var userIsPatient = appointment.DoctorId.ToString() == realId || appointment.PatientId.ToString() == realId;

        if (!userIsPatient)
            return BadRequest(new { error = "You do not have access to this user's appointments." });

        switch (status)
        {
            case "Checked In":
                return Ok(await _appointmentService.CheckInToAppointment(appointmentId));
            case "Complete":
                return Ok(await _appointmentService.CompleteAppointment(appointmentId));
            case "Cancelled":
                return Ok(await _appointmentService.CancelAppointment(appointmentId));

            default:
                return BadRequest();
        }
    }
}
