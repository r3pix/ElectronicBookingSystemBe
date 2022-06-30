using ElectronicLibrary.Application.Interfaces;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddTransient<IElectronicLibraryDbContext,ElectronicLibraryDbContext>();
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<IDecorationRepository,DecorationRepository>();
            return services;
        }

        /// <summary>
        /// Registers configurations from Appsettings.json
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddConfigurationModels(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("FileConfiguration").Get<FileConfiguration>());
            return services;
        }

    }
}
