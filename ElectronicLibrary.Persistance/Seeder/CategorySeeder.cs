using System;
using System.Threading.Tasks;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBookingSystem.Persistance.Seeder
{
    public class CategorySeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public CategorySeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Seed()
        {
            using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<ElectronicBookingSystemDbContext>();

                if(!await _dbContext.Categories.AnyAsync())
                {
                    await _dbContext.Categories.AddRangeAsync(new System.Collections.Generic.List<Category>
                    {
                        new Category
                        {
                            Name = "Bardzo mała sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Name = "Mała sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Name = "Średnia sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Name = "Duża sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Name = "Bardzo duża sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        }
                    });
                    await _dbContext.SaveChangesAsyncWithoutUser();
                }

            }
        }
    }
}

