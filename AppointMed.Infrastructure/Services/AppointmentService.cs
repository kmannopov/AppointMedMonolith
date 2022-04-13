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
        return await UpdateAppointment(appointmentId, "Cancelled");
    }

    public async Task<bool> CheckInToAppointment(Guid appointmentId)
    {
        return await UpdateAppointment(appointmentId, "Checked In");
    }

    public async Task<bool> CompleteAppointment(Guid appointmentId)
    {
        return await UpdateAppointment(appointmentId, "Complete");
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

    public async Task<Appointment> GetAppointment(Guid appointmentId)
    {
        return await _dataContext.Appointments.FindAsync(appointmentId);
    }

    public async Task<IEnumerable<Appointment>> GetPatientAppointmentList(Guid patientId)
    {
        return await _dataContext.Appointments.Where(x => x.PatientId == patientId).ToListAsync();
    }


    private async Task<bool> UpdateAppointment(Guid appointmentId, string status)
    {
        var appointment = await _dataContext.Appointments.FindAsync(appointmentId);
        if (appointment == null) return false;

        appointment.Status = status;
        var updated = await _dataContext.SaveChangesAsync();
        return updated > 0;
    }

    public async Task<IEnumerable<DateTime>> GetFreeSlots(Guid doctorId)
    {
        var appointments = await _dataContext.Appointments.Where(x => x.DoctorId == doctorId && x.DateTime > DateTime.Today.AddDays(1)
        && x.DateTime <= DateTime.Today.AddDays(8)).ToListAsync();

        var freeSlots = new List<DateTime>();

        for (int i = 1; i < 8; i++)
        {
            var currentDate = DateTime.Today.AddDays(i);
            if (currentDate.DayOfWeek == DayOfWeek.Saturday
                || currentDate.DayOfWeek == DayOfWeek.Sunday)
            {
                continue;
            }

            var startTime = currentDate.AddHours(9);
            for (int j = 0; j < 16; j++)
            {
                var dateTime = startTime.AddMinutes(30 * j);
                if (appointments.Find(x => x.DateTime == dateTime) == default)
                    freeSlots.Add(dateTime);
            }
        }

        return freeSlots;
    }
}
