using AppointMed.Core.Entities.UserAggregate;
using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.Infrastructure.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _dataContext;

        public DoctorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateDoctorAsync(Doctor doctor)
        {
            await _dataContext.Doctors.AddAsync(doctor);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsByDeptInClinicAsync(Guid clinicId, Guid departmentId)
        {
           return await _dataContext.Doctors.Where(x => x.ClinicId == clinicId && x.DepartmentId == departmentId).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(Guid id)
        {
            return await _dataContext.Doctors.FindAsync(id);
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            _dataContext.Doctors.Update(doctor);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> UserIsDoctorAsync(Guid userId)
        {
            var doctor = await _dataContext.Doctors.AsNoTracking().SingleOrDefaultAsync(x => x.UserId == userId);

            return doctor != null;
        }
    }
}
