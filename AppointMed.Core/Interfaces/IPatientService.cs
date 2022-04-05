﻿using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Interfaces;

public interface IPatientService
{
    Task<Patient> GetPatientByIdAsync(Guid userId);
    Task<bool> CreatePatientAsync(Patient patient);
    Task<bool> UpdatePatientAsync(Patient patient);
    Task<bool> UserIsPatientAsync(Guid UserId);
}