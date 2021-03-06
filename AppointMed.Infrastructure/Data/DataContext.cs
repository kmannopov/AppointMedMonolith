using AppointMed.Core.Entities;
using AppointMed.Core.Entities.AppointmentAggregate;
using AppointMed.Core.Entities.AuthAggregate;
using AppointMed.Core.Entities.ClinicAggregate;
using AppointMed.Core.Entities.UserAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.Infrastructure.Data;

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
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().Property(m => m.ClinicId).IsRequired(false);
        modelBuilder.Entity<Doctor>().Property(m => m.DepartmentId).IsRequired(false);
        base.OnModelCreating(modelBuilder);
    }
}
