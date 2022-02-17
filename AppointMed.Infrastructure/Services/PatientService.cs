using AppointMed.Core.Entities.UserAggregate;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.Infrastructure.Services;

public class PatientService : IPatientService
{
    private readonly DataContext _dataContext;

    public PatientService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<Patient> GetPatientByIdAsync(Guid id)
    {
        return await _dataContext.Patients.SingleOrDefaultAsync(patient => patient.Id == id);
    }

    public async Task<bool> CreatePatientAsync(Patient patient)
    {
        await _dataContext.Patients.AddAsync(patient);
        var created = await _dataContext.SaveChangesAsync();

        return created > 0;
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        _dataContext.Patients.Update(patient);
        var updated = await _dataContext.SaveChangesAsync();

        return updated > 0;
    }
}