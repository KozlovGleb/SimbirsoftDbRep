using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Bootstrap
{
    public class DbConfigurations
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AspNetLectionsContext>(
                options => options.UseNpgsql(
                    configuration.GetConnectionString(nameof(AspNetLectionsContext)),
                    builder => builder.MigrationsAssembly(typeof(AspNetLectionsContext).Assembly.FullName))
            );
        }
    }
}
