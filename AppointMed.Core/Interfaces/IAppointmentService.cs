﻿using AppointMed.Core.Entities.AppointmentAggregate;

namespace AppointMed.Core.Interfaces;

public interface IAppointmentService
{
    Task<bool> CreateNewAppointment(Appointment appointment);
    Task<bool> CheckInToAppointment(Guid appointmentId);
    Task<bool> CompleteAppointment(Guid appointmentId);
    Task<bool> CancelAppointment(Guid appointmentId);
    Task<IEnumerable<Appointment>> GetPatientAppointmentList(Guid patientId);
    Task<IEnumerable<Appointment>> GetDoctorAppointmentList(Guid doctorId);

}
