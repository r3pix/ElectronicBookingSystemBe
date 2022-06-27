using ElectronicLibrary.Infrastructure.Models;
using ElectronicLibrary.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddTransient<IElectronicLibraryDbContext,ElectronicLibraryDbContext>();
            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            return services;
        }

        public static IServiceCollection AddConfigurationModels(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("FileUpload").Get<FileConfiguration>());
            return services;
        }

    }
}
