using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SimbirsoftDbRep.Authentication.Insfrastructure;
using SimbirsoftDbRep.Controllers;
using SimbirsoftDbRep.Database.Bootstrap;
using SimbirsoftDbRep.Repositories;
using SimbirsoftDbRep.Repositories.Bootstrap;
using SimbirsoftDbRep.Services;
using SimbirsoftDbRep.Services.Bootstrap;
using SimbirsoftDbRep.Services.Interfaces.Login;

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
            services.ConfigureDb(Configuration);
            services.AddControllers();
            var jwtTokenConfig = Configuration.GetSection("jwtTokenConfig").Get<JwtConfig>();
            services.AddSingleton(jwtTokenConfig);
            //add auth
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                // the authentication requires HTTPS for the metadata address or authority
                x.RequireHttpsMetadata = true;
                // saves the JWT access token in the current HttpContext,
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            services.ConfigureRepositories();
            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(PatientRepository).GetTypeInfo().Assembly,
                typeof(PatientsController).GetTypeInfo().Assembly
            );
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT Auth Demo", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }   
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowJwtDemo",
                    builder =>
                    {
                        // white list
                        builder.WithOrigins("http://localhost:4200");
                        // we have only 5 methods in app.
                        builder.WithMethods("GET", "POST","PUT","DELETE", "OPTIONS");
                        // in request head
                        builder.AllowAnyHeader();
                        // lifetime
                        builder.SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
            });

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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "JWT Auth Demo V1");
                c.DocumentTitle = "JWT Auth Demo";
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseCors("AllowJwtDemo");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
