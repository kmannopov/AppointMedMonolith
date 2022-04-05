using AppointMed.Core.Entities.ClinicAggregate;

namespace AppointMed.Core.Interfaces;

public interface IClinicService
{
    Task<Clinic> GetClinicByIdAsync(Guid clinicId);
    Task<IEnumerable<Clinic>> GetClinicsAsync();
    Task<IEnumerable<Clinic>> GetClinicsByDepartmentAsync(string departmentName);
    Task<bool> CreateClinicAsync(Clinic clinic);
    Task<bool> UpdateClinicAsync(Clinic clinic);
    Task<bool> DeleteClinicAsync(Guid id);
}
