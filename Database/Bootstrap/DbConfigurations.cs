using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimbirsoftDbRep.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Bootstrap
{
    /// <summary>
    /// Конфигурации БД.
    /// </summary>
    public static class DbConfigurations
    {
        /// <summary>
        /// Подключение DbContext.
        /// </summary>
        /// <param name="services">Коллекция сервисов.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HospitalContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString(nameof(HospitalContext)),
                    builder => builder.MigrationsAssembly(typeof(HospitalContext).Assembly.FullName))
            );
        }
    }
}
