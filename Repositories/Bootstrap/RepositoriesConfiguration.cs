using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Repositories.Bootstrap
{ 
    /// <summary>
    /// Расширения для конфигурации репозиториев.
    /// </summary>
public static class RepositoriesConfiguration
    {
    /// <summary>
    /// Конфигурирование репозиториев.
    /// </summary>
    /// <param name="services">Коллекция сервисов из Startup.</param>
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPatientRepository, PatientRepository>();
    }
}
}
