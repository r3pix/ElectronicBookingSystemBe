using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    /// <summary>
    /// Provides extensions for IServiceCollection
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Registers infrastructure services
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <returns>IServiceCollection</returns>
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddTransient<IElectronicLibraryDbContext,ElectronicLibraryDbContext>();
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<IDecorationRepository,DecorationRepository>();
            services.AddTransient<IEquipmentRepository,EquipmentRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IFileService,FileService>();
        }

        /// <summary>
        /// Registers configurations from Appsettings.json
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <returns>IServiceCollection</returns>
        public static void AddConfigurationModels(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("FileConfiguration").Get<FileConfiguration>());
        }

        public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(opt => opt.AddPolicy("AllowedHosts", builder =>
            {
                var allowedHosts = configuration.GetSection("CorsConfiguration:AllowedHosts").Get<string[]>();
                builder.WithOrigins(allowedHosts).AllowAnyHeader().AllowAnyMethod();
            }));
        }

        public static void ConfigureSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(builder => 
            {
                var key = Encoding.UTF8.GetBytes(configuration.GetSection("JWTConfiguration:SecretKey").Get<string>());
                builder.SaveToken = true;
                builder.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("JWTConfiguration:Issuer").Get<string>(),
                    ValidAudience = configuration.GetSection("JWTConfiguration:Audience").Get<string>(),
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            services.AddAuthorization();
  
        }

    }
}
