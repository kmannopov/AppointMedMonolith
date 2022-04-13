using AppointMed.Core.Entities.UserAggregate;

namespace AppointMed.Core.Interfaces
{
    public interface IDoctorService
    {
        Task<Doctor> GetDoctorByIdAsync(string userId);
        Task<IEnumerable<Doctor>> GetAllDoctorsByDeptInClinicAsync(string departmentId);
        Task<bool> CreateDoctorAsync(Doctor doctor);
        Task<bool> UpdateDoctorAsync(Doctor doctor);
        Task<bool> UserIsDoctorAsync(string userId);
    }
}
