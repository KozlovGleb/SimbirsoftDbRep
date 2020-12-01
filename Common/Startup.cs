using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimbirsoftDbRep.Common.Swagger;
using SimbirsoftDbRep.Controllers;
using SimbirsoftDbRep.Database.Bootstrap;
using SimbirsoftDbRep.Repositories;
using SimbirsoftDbRep.Repositories.Bootstrap;
using SimbirsoftDbRep.Services.Bootstrap;

namespace SimbirsoftDbRep
{
    /// <summary>
    /// Конфигурация приложения.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">Конфигурация.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Конфигурация.
        /// </summary>
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var cn = Configuration.GetConnectionString("HospitalContext");
            services.ConfigureDb(Configuration);
            services.AddControllers();
            services.ConfigureRepositories();
            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(PatientRepository).GetTypeInfo().Assembly,
                typeof(PatientsController).GetTypeInfo().Assembly
            );
            services.ConfigureSwagger();

        }
        // <summary>
        /// Mетод вызывается для средой исполнения. Используется для конфигурации окружения для обработки HTTP запроса.
        /// </summary>
        /// <param name="app">Средство конфигурации приложения.</param>
        /// <param name="env">Информация об окружении, в котором работает приложение.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            bool a = env.IsDevelopment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors();
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
