using DataLayer.Interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace Main.Services
{
    public class AllServicesInstall : IServicesInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "First Task API", Version = "v1" });
            });

            services.AddTransient<IRepository<UserTask>, UserTaskRepository>();
            services.AddTransient<IRepository<Permission>, PermissionRepository>();
            services.AddTransient<IRepository<Office>, OfficeRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();
        }
    }
}
