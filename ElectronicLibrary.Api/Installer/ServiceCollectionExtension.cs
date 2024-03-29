﻿using ElectronicBookingSystem.Application.Interfaces;
using ElectronicBookingSystem.Application.Repositories;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Models;
using ElectronicBookingSystem.Infrastructure.Services;
using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary.Persistance;

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
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IElectronicBookingSystemDbContext,ElectronicBookingSystemDbContext>()   
                .AddTransient<IDecorationRepository, DecorationRepository>()
                .AddTransient<IEquipmentRepository, EquipmentRepository>()
                .AddTransient<IServiceRepository, ServiceRepository>()
                .AddTransient<IRoomRepository, RoomRepository>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<ICurrentUserService, CurrentUserService>()
                .AddTransient<ICategoryPageableRepository, CategoryPageableRepository>()
                .AddTransient<IRoomPageableRepository, RoomPageableRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IPageableDecorationsRepository, PageableDecorationsRepository>()
                .AddTransient<IPageableEquipmentRepository, PageableEquipmentRepository>()
                .AddTransient<IPageableServicesRepository, PageableServicesRepository>()
                .AddTransient<IUserPageableRepository, UserPageableRepository>()
                .AddTransient<IBookingPageableRepository, BookingPageableRepository>()
                .AddTransient<IInlineEmailMessageService, InlineEmailMessageService>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddSignalR();
            //services.AddTransient(typeof(IPageableRepository<,>), typeof(PageableRepository<,>));

        }

        /// <summary>
        /// Registers configurations from Appsettings.json
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <returns>IServiceCollection</returns>
        public static void AddConfigurationModels(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("FileConfiguration").Get<FileConfiguration>())
                    .AddSingleton(configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>())
                    .AddSingleton(configuration.GetSection("AppData").Get<AppData>());
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
                    ValidateIssuer = true,
                    ValidateAudience = true,
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
