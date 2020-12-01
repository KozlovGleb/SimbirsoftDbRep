using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Services.Bootstrap
{
    /// <summary>
    /// Методы засширения для конфигурации сервисов.
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Конфигурация сервисов.
        /// </summary>
        /// <param name="services">Коллекция сервисов из Startup.</param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IPatientService, PatientService>();
        }
    }
}
