using AppointMed.Core.Entities;
using AppointMed.Core.Entities.UserAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.API.Data;

public class DataContext : IdentityDbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}
