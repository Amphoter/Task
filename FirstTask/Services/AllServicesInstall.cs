using AutoMapper;
using FirstTask.EF;
using FirstTask.Interfaces;
using FirstTask.Models;
using FirstTask.Repositories;
using FirstTask.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Services
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


            services.AddTransient<IRepository<Models.UserTask>, UserTaskRepository>();
            services.AddTransient<IRepository<Models.Permission>, PermissionRepository>();
            services.AddTransient<IRepository<Office>, OfficeRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}
