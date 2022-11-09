using ElectronicBookingSystem.Domain.Entities;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Tests
{
    public class DbContextHelper
    {
        public static Mock<ElectronicBookingSystemDbContext> GetMockedDbContext()
        {
            var dbContext = new Mock<ElectronicBookingSystemDbContext>();
            dbContext.Setup(x=>x.Set<Category>()).Returns(GetMockedCategorySet().Object);
            dbContext.Setup(x => x.Set<Decoration>()).Returns(GetMockedDecorationSet().Object);
            dbContext.Setup(x => x.Set<Equipment>()).Returns(GetMockedEquipmentSet().Object);
            dbContext.Setup(x => x.Set<Service>()).Returns(GetMockedServiceSet().Object);
            dbContext.Setup(x => x.Set<Role>()).Returns(GetMockedRoleSet().Object);
            dbContext.Setup(x => x.Set<Identity>()).Returns(GetMockedIdentitySet().Object);
            dbContext.Setup(x => x.Set<Address>()).Returns(GetMockedAddressSet().Object);
            dbContext.Setup(x => x.Set<User>()).Returns(GetMockedUserSet().Object);
            dbContext.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(Task.FromResult(1));

            return dbContext;
        }

        protected static Mock<DbSet<Category>> GetMockedCategorySet()
        {
            var entities = new List<Category>
            {
                 new Category
                        {
                            Id = Guid.Parse("01954974-d407-4508-a301-b8c0b13f5f73"),
                            Name = "Bardzo mała sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Id = Guid.Parse("cc58fff7-64ca-4e67-bc82-a6ed9ec127c8"),
                            Name = "Mała sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Id = Guid.Parse("3a6f6829-ffd8-4680-8453-c643d981a0f4"),
                            Name = "Średnia sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Id = Guid.Parse("5d18973e-5b86-4123-9c3e-9309cb0b9b1e"),
                            Name = "Duża sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        },
                        new Category
                        {
                            Id = Guid.Parse("0307b01f-8024-4b27-a407-3fcccc3d202b"),
                            Name = "Bardzo duża sala",
                            CreateDate = DateTime.UtcNow,
                            CreateEmail = "system@com.pl",
                            IsActive = true,
                            LMDate = DateTime.UtcNow,
                            LMEmail = "system@com.pl"
                        }
            };

            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<Equipment>> GetMockedEquipmentSet()
        {
            var entities = new List<Equipment>
            {
                new Equipment
                {
                    Cost = 1000,
                    CreateDate = DateTime.UtcNow,
                    LMDate = DateTime.UtcNow,
                    CreateEmail = "system",
                    LMEmail = "system",
                    IsActive = true,
                    Name = "Test Name",
                    Id = Guid.Parse("39d5b378-8267-4555-b238-b6f2328a0d0f")
                }
            };

            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<Service>> GetMockedServiceSet()
        {
            var entities = new List<Service>
            {
                new Service
                        {
                            Id = Guid.Parse("77811725-b5fb-4840-9c6c-8ac41423757b"),
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
                            Id = Guid.Parse("d31573a8-edcc-4723-8607-c9ab821feefa"),
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
                            Id = Guid.Parse("09dd7a46-3455-4e7e-a6d7-8520dd995e8e"),
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
                            Id = Guid.Parse("b5b07f5a-3ba4-4f41-b663-89516394d957"),
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
                             Id = Guid.Parse("96f3601d-b152-4dbd-b60c-fecd2e73b59a"),
                            Name = "Excelsior",
                             Cost = 5000,
                             CreateDate = DateTime.UtcNow,
                             CreateEmail = "system@com.pl",
                             Description = "Podstawowa konfiguracja obsługi oferujący bardzo duży zestaw profesjonalnego personelu,\nbaramanów oraz kilka zespołów gastronomicznych wraz z szefami kuchni dopasowanego do państwa oczekiwań.\n Opcja full wypas!!",
                             IsActive = true,
                             LMDate = DateTime.UtcNow,
                             LMEmail = "system@com.pl"
                        }
            };
            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<Identity>> GetMockedIdentitySet()
        {
            var entities = new List<Identity>
            {
                new Identity
                {
                    Id = Guid.Parse("6c77009a-bdf4-4881-8e73-cbf06b075bc3"),
                    CreateDate = DateTime.UtcNow,
                    LMDate = DateTime.UtcNow,
                    CreateEmail = "system@com.pl",
                    LMEmail = "system@com.pl",
                    Name = "Super",
                    LastName = "Admin",
                    IsActive = true,
                    UserId = Guid.Parse("c9bb35f7-b4c0-4053-8ef7-2a1c59198f48")
                }
            };

            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<Address>> GetMockedAddressSet()
        {
            var entities = new List<Address>
            {
                new Address
                {
                    Id = Guid.Parse("c9bb35f7-b4c0-4053-8ef7-2a1c59198f48"),
                    City = "Kielce",
                    CreateDate = DateTime.UtcNow,
                    LMDate = DateTime.UtcNow,
                    CreateEmail = "system@com.pl",
                    LMEmail = "system@com.pl",
                    IsActive = true,
                    Number = "36",
                    PostalCode = "26-556",
                    Street = "Mała",
                    UserId = Guid.Parse("c9bb35f7-b4c0-4053-8ef7-2a1c59198f48")
                }
            };

            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<Decoration>> GetMockedDecorationSet()
        {
            var entities = new List<Decoration>
            {
                new Decoration
                {
                    Cost = 1000,
                    CreateDate = DateTime.UtcNow,
                    LMDate = DateTime.UtcNow,
                    CreateEmail = "system",
                    LMEmail = "system",
                    IsActive = true,
                    Name = "Test Decoration",
                    Id = Guid.Parse("83f8a698-2850-42f7-914a-0d7cc9a443ee"),

                }
            };

            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<Role>> GetMockedRoleSet()
        {
            var entities = new List<Role>
            {
                 new Role { Id = Guid.Parse("4be0058f-0e57-4c88-b455-d5b37bb71e0f"), Name = "Admin", CreateDate = DateTime.UtcNow, LMDate = DateTime.UtcNow, CreateEmail = "system", LMEmail = "system" },
                 new Role { Id = Guid.Parse("640f3f73-bf9b-4966-9202-2179425fb359"), Name = "User", CreateDate = DateTime.UtcNow, LMDate = DateTime.UtcNow, CreateEmail = "system", LMEmail = "system" }
            };

            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<User>> GetMockedUserSet()
        {
            var entities = new List<User>
            {
                 new User
                        {
                            Id = Guid.Parse("c9bb35f7-b4c0-4053-8ef7-2a1c59198f48"),
                            Email = "admin@com.pl",
                            PasswordHash = "AQAAAAEAACcQAAAAEBaEMPUzQ5i1WkTaZ0VMolEIb0TO8Nq2dKV7shMJOMAYYLPyCRRb31ulzwF0lr4rAA==",
                            RoleId = Guid.Parse("4be0058f-0e57-4c88-b455-d5b37bb71e0f"),
                            CreateDate = DateTime.UtcNow,
                            LMDate = DateTime.UtcNow,
                            IsActive = true,
                            CreateEmail = "system@com.pl",
                            LMEmail = "system@com.pl"
                    }
            };
            return GetMockDbSet(entities);
        }

        protected static Mock<DbSet<T>> GetMockDbSet<T>(ICollection<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
            mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(entities.Add);
            mockSet.Setup(m => m.AddAsync(It.IsAny<T>(), It.IsAny<CancellationToken>()))
                .Callback((T model, CancellationToken token) => { entities.Add(model); });
            mockSet.Setup(m => m.Update(It.IsAny<T>())).Verifiable();

            return mockSet;
        }
    }
}
