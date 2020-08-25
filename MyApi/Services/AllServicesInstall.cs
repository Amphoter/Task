using AutoMapper;
using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyApi.Mapping;

namespace Main.Services
{
    public class AllServicesInstall : IServicesInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "First Task API", Version = "v1" });
            });

            

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IRepository<UserTask>, UserTaskRepository>();
            services.AddTransient<IRepository<Permission>, PermissionRepository>();
            services.AddTransient<IRepository<Office>, OfficeRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<ILogin<LoginModel>, LoginRepository>();
        }
    }
}
