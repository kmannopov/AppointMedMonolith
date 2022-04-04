using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorByIdAsync(string id);
        Task<IEnumerable<Doctor>> GetAllDoctorsInClinicAsync(string clinicId, string departmentId);
        Task<bool> CreateDoctorAsync(Doctor doctor);
        Task<bool> UpdateDoctorAsync(Doctor doctor);
        Task<bool> UserIsDoctorAsync(string userId);
    }
}
