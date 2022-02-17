using AppointMed.Core.Entities.ClinicAggregate;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.Infrastructure.Services;

public class ClinicService : IClinicService
{
    private readonly DataContext _dataContext;

    public ClinicService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task<IEnumerable<Clinic>> GetClinicsAsync()
    {
        return await _dataContext.Clinics.ToListAsync();
    }

    public async Task<Clinic> GetClinicByIdAsync(Guid clinicId)
    {
        return await _dataContext.Clinics.SingleOrDefaultAsync(x => x.Id == clinicId);
    }

    public async Task<bool> CreateClinicAsync(Clinic clinic)
    {
        await _dataContext.Clinics.AddAsync(clinic);
        var created = await _dataContext.SaveChangesAsync();

        return created > 0;
    }

    public async Task<bool> UpdateClinicAsync(Clinic clinic)
    {
        _dataContext.Clinics.Update(clinic);
        var updated = await _dataContext.SaveChangesAsync();

        return updated > 0;
    }

    public async Task<bool> DeleteClinicAsync(Guid id)
    {
        var clinic = await GetClinicByIdAsync(id);

        if (clinic is null)
            return false;

        _dataContext.Clinics.Remove(clinic);
        var deleted = await _dataContext.SaveChangesAsync();

        return deleted > 0;
    }
}
