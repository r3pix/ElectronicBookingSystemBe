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
    public class UserSeeder
    {
        private readonly IServiceProvider _service;

        public UserSeeder(IServiceProvider service)
        {
            _service = service;
        }

        public static async Task Seed(ElectronicBookingSystemDbContext context)
        {
            await context.Users.AddRangeAsync(
                       new User
                       {
                           Email = "admin@com.pl",
                           PasswordHash = "AQAAAAEAACcQAAAAEBaEMPUzQ5i1WkTaZ0VMolEIb0TO8Nq2dKV7shMJOMAYYLPyCRRb31ulzwF0lr4rAA==",
                           RoleId = (await context.Roles.FirstOrDefaultAsync(x => x.Name == "Admin")).Id,
                           Address = new Address
                           {
                               City = "Kielce",
                               CreateDate = DateTime.UtcNow,
                               LMDate = DateTime.UtcNow,
                               CreateEmail = "system@com.pl",
                               LMEmail = "system@com.pl",
                               IsActive = true,
                               Number = "36",
                               PostalCode = "26-556",
                               Street = "Mała"
                           },
                           Identity = new Identity
                           {
                               CreateDate = DateTime.UtcNow,
                               LMDate = DateTime.UtcNow,
                               CreateEmail = "system@com.pl",
                               LMEmail = "system@com.pl",
                               Name = "Super",
                               LastName = "Admin",
                               IsActive = true
                           },
                           CreateDate = DateTime.UtcNow,
                           LMDate = DateTime.UtcNow,
                           IsActive = true,
                           CreateEmail = "system@com.pl",
                           LMEmail = "system@com.pl"
                       });
            await context.SaveChangesAsyncWithoutUser();
        }

        public async Task Seed()
        {
            using (var scope = _service.CreateAsyncScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<ElectronicBookingSystemDbContext>();
                
                if(!await _dbContext.Users.AnyAsync())
                {
                    await Seed(_dbContext);
                }
            }
        }
    }
}
