using AppointMed.Core.Entities;

namespace AppointMed.API.Repositories;

public interface IClinicService
{
    Task<Clinic> GetClinicByIdAsync(Guid clinicId);
    Task<IEnumerable<Clinic>> GetClinicsAsync();
    Task<bool> CreateClinicAsync(Clinic clinic);
    Task<bool> UpdateClinicAsync(Clinic clinic);
    Task<bool> DeleteClinicAsync(Guid id);
}
