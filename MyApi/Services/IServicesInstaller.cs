using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Main.Services
{
    public interface IServicesInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
