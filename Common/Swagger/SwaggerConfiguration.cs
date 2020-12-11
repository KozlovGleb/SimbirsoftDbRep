using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Common.Swagger
{
    /// <summary>
    /// Расширения для конфигурации Swagger.
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Настройка документов Swagger.
        /// </summary>
        /// <param name="services">Коллекция сервисов для DI.</param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerDocument(c =>
            {
                c.Title = "Patients";
                c.DocumentName = SwaggerDocParts.Patients;
                c.ApiGroupNames = new[] { SwaggerDocParts.Patients };
                c.GenerateXmlObjects = true;
            })
            .AddSwaggerDocument(c =>
            {
                c.Title = "Doctors";
                c.DocumentName = SwaggerDocParts.Doctors;
                c.ApiGroupNames = new[] { SwaggerDocParts.Doctors };
                c.GenerateXmlObjects = true;
            })
            .AddSwaggerDocument(c =>
            {
                c.Title = "Cards";
                c.DocumentName = SwaggerDocParts.Cards;
                c.ApiGroupNames = new[] { SwaggerDocParts.Cards };
                c.GenerateXmlObjects = true;
            });



        }
    }
}
