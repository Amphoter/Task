using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FirstTask.Services
{
    public interface IServicesInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
