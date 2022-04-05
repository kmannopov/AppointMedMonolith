using AppointMed.Core.Entities.AppointmentAggregate;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.Infrastructure.Services;

public class AppointmentService : IAppointmentService
{
    private readonly DataContext _dataContext;
    public AppointmentService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<bool> CancelAppointment(Guid appointmentId)
    {
        return await UpdateAppointment(appointmentId, Appointment.AppointmentStatus.Cancelled);
    }

    public async Task<bool> CheckInToAppointment(Guid appointmentId)
    {
        return await UpdateAppointment(appointmentId, Appointment.AppointmentStatus.CheckedIn);
    }

    public async Task<bool> CompleteAppointment(Guid appointmentId)
    {
        return await UpdateAppointment(appointmentId, Appointment.AppointmentStatus.Complete);
    }

    public async Task<bool> CreateNewAppointment(Appointment appointment)
    {
        await _dataContext.Appointments.AddAsync(appointment);
        var created = await _dataContext.SaveChangesAsync();

        return created > 0;
    }

    public async Task<IEnumerable<Appointment>> GetDoctorAppointmentList(Guid doctorId)
    {
        return await _dataContext.Appointments.Where(x => x.DoctorId == doctorId).ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetPatientAppointmentList(Guid patientId)
    {
        return await _dataContext.Appointments.Where(x => x.PatientId == patientId).ToListAsync();
    }


    private async Task<bool> UpdateAppointment(Guid appointmentId, Appointment.AppointmentStatus status)
    {
        var appointment = await _dataContext.Appointments.FindAsync(appointmentId);
        if (appointment == null) return false;

        appointment.Status = status;
        var updated = await _dataContext.SaveChangesAsync();
        return updated > 0;
    }
}
