using AppointMed.API.Settings;

namespace AppointMed.API.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMvc();
        services.AddControllers(options => options.SuppressAsyncSuffixInActionNames = false);
    }
}
