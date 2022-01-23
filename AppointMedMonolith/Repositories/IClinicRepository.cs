using AppointMed.Core.Entities;

namespace AppointMed.API.Repositories;

public interface IClinicRepository
{
    Task<Clinic> GetClinicAsync(Guid id);
    Task<IEnumerable<Clinic>> GetClinicsAsync();
    Task CreateClinicAsync(Clinic clinic);
    Task UpdateClinicAsync(Clinic clinic);
    Task DeleteClinicAsync(Guid id);
}
