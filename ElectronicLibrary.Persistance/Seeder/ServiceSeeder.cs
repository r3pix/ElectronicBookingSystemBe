using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBookingSystem.Persistance.Seeder
{
    public class ServiceSeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Seed()
        {
            using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<ElectronicBookingSystemDbContext>();

                if(!await _dbContext.Services.AnyAsync())
                {
                    await _dbContext.Services.AddRangeAsync(new List<Service>
                    {
                        new Service
                        {
                             Name = "Serwis podstawowy",
                             Cost = 1000,
                             CreateDate = DateTime.UtcNow,
                             CreateEmail = "system@com.pl",
                             Description = "Podstawowa konfiguracja obsługi oferujący zestaw małego personelu dopasowanego do państwa oczekiwań.",
                             IsActive = true,
                             LMDate = DateTime.UtcNow,
                             LMEmail = "system@com.pl"
                        },
                        new Service
                        {
                            Name = "Serwis standardowy",
                             Cost = 2000,
                             CreateDate = DateTime.UtcNow,
                             CreateEmail = "system@com.pl",
                             Description = "Podstawowa konfiguracja obsługi oferujący zestaw personelu oraz dopasowanego do państwa oczekiwań.",
                             IsActive = true,
                             LMDate = DateTime.UtcNow,
                             LMEmail = "system@com.pl"
                        },
                        new Service
                        {
                            Name = "Serwis bogaty",
                             Cost = 3000,
                             CreateDate = DateTime.UtcNow,
                             CreateEmail = "system@com.pl",
                             Description = "Podstawowa konfiguracja obsługi oferujący zestaw profesjonalnego personelu,\nbaramanów oraz oddelegowanego szefa kuchni dopasowanego do państwa oczekiwań.",
                             IsActive = true,
                             LMDate = DateTime.UtcNow,
                             LMEmail = "system@com.pl"
                        },
                        new Service
                        {
                            Name = "Serwis bardzo bogaty",
                             Cost = 4000,
                             CreateDate = DateTime.UtcNow,
                             CreateEmail = "system@com.pl",
                             Description = "Podstawowa konfiguracja obsługi oferujący duży zestaw profesjonalnego personelu,\nbaramanów oraz oddelegowanegych szefów kuchni dopasowanego do państwa oczekiwań.",
                             IsActive = true,
                             LMDate = DateTime.UtcNow,
                             LMEmail = "system@com.pl"
                        },
                         new Service
                        {
                            Name = "Excelsior",
                             Cost = 5000,
                             CreateDate = DateTime.UtcNow,
                             CreateEmail = "system@com.pl",
                             Description = "Podstawowa konfiguracja obsługi oferujący bardzo duży zestaw profesjonalnego personelu,\nbaramanów oraz kilka zespołów gastronomicznych wraz z szefami kuchni dopasowanego do państwa oczekiwań.\n Opcja full wypas!!",
                             IsActive = true,
                             LMDate = DateTime.UtcNow,
                             LMEmail = "system@com.pl"
                        },
                    });
                    await _dbContext.SaveChangesAsyncWithoutUser();
                }
            }
        }
    }
}

