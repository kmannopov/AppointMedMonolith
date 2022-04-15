using Microsoft.AspNetCore.Identity;

namespace AppointMed.API.Installers;

public static class InstallerExtensions
{
    public static void InstallServicesInAssembly(this WebApplicationBuilder builder)
    {
        var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
    typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
        installers.ForEach(installer => installer.InstallServices(builder.Services, builder.Configuration));
    }

    public static async Task CreateIdentityRoles(this IServiceScope serviceScope)
    {
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            var adminRole = new IdentityRole("Admin");
            await roleManager.CreateAsync(adminRole);
        }

        if (!await roleManager.RoleExistsAsync("Manager"))
        {
            var managerRole = new IdentityRole("Manager");
            await roleManager.CreateAsync(managerRole);
        }

        if (!await roleManager.RoleExistsAsync("Doctor"))
        {
            var doctorRole = new IdentityRole("Doctor");
            await roleManager.CreateAsync(doctorRole);
        }

        if (!await roleManager.RoleExistsAsync("Patient"))
        {
            var patientRole = new IdentityRole("Patient");
            await roleManager.CreateAsync(patientRole);
        }
    }
}
