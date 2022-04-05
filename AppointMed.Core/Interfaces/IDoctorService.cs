using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorByIdAsync(Guid id);
        Task<IEnumerable<Doctor>> GetAllDoctorsByDeptInClinicAsync(Guid clinicId, Guid departmentId);
        Task<bool> CreateDoctorAsync(Doctor doctor);
        Task<bool> UpdateDoctorAsync(Doctor doctor);
        Task<bool> UserIsDoctorAsync(Guid userId);
    }
}
