using AppointMed.Core.Interfaces;
using AppointMed.Infrastructure.Data;
using AppointMed.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppointMed.API.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<DataContext>();

        services.AddScoped<IClinicService, ClinicService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IPatientService, PatientService>();
    }
}
