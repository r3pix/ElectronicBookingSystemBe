using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Persistance.Seeder
{
    public class RoleSeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public RoleSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; //kiwka bo async
        }

        public static async Task Seed(ElectronicBookingSystemDbContext context)
        {
            await context.Roles.AddRangeAsync(new Role[]
                    {
                        new Role { Name = "Admin", CreateDate = DateTime.UtcNow, LMDate = DateTime.UtcNow, CreateEmail = "system", LMEmail = "system" },
                        new Role { Name = "User", CreateDate = DateTime.UtcNow, LMDate = DateTime.UtcNow, CreateEmail = "system", LMEmail = "system" }
                    });
            await context.SaveChangesAsyncWithoutUser();
        }

        public async Task Seed()
        {
            using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<ElectronicBookingSystemDbContext>();

                if (!_dbContext.Roles.Any())
                {
                    await Seed(_dbContext);
                }
            }
        }
    }
}
