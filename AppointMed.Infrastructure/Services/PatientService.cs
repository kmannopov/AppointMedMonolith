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
        return await _dataContext.Patients.SingleOrDefaultAsync(patient => patient.UserId == id.ToString());
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

    public async Task<bool> UserIsPatientAsync(string userId)
    {
        var patient = await _dataContext.Patients.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == userId);

        if (patient == null)
            return false;
        return true;
    }
}