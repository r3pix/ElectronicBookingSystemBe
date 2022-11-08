using ElectronicBookingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicBookingSystem.Tests
{
    public class InMemorySeeds
    {
        public static List<Category> GetMockedCategorySet()
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

            return entities;
        }

        public static List<Equipment> GetMockedEquipmentSet()
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

            return entities;
        }

        public static List<Service> GetMockedServiceSet()
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
            return entities;
        }

        public static List<Identity> GetMockedIdentitySet()
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

            return entities;
        }

        public static List<Address> GetMockedAddressSet()
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

            return entities;
        }

        public static List<Room> GetMockedRoomSet()
        {
            var entities = new List<Room>
            {
                new Room
                {
                    CategoryId = Guid.Parse("0307b01f-8024-4b27-a407-3fcccc3d202b"),
                    Cost = 100,
                    CreateDate  = DateTime.UtcNow,
                    CreateEmail = "system",
                    LMDate = DateTime.UtcNow,
                    LMEmail = "system",
                    Description = "Test",
                    Height = 100,
                    IsActive = true,
                    Length = 100,
                    Name = "Test",
                    TotalMaxPlaces = 20,
                    TotalMaxTables = 20,
                    Width = 20,
                    Id = Guid.Parse("44031ee7-c9f1-4c7d-926c-df3aed775c55")
                    
                }
            };

            return entities;
        }

        public static List<Booking> GetMockedBookingSet()
        {
            var entities = new List<Booking>
            {
                new Booking
                {
                    CreateDate  = DateTime.UtcNow,
                    CreateEmail = "system",
                    Date = DateTime.Today,
                    Description = "Test",
                    IsActive = true,
                    LMDate = DateTime.UtcNow,
                    LMEmail = "system",
                    Name = "Test",
                    TotalCost = 1000,
                    TotalPlaces = 10,
                    TotalTables = 10,
                    DecorationId = Guid.Parse("83f8a698-2850-42f7-914a-0d7cc9a443ee"),
                    EquipmentId = Guid.Parse("39d5b378-8267-4555-b238-b6f2328a0d0f"),
                    RoomId = Guid.Parse("44031ee7-c9f1-4c7d-926c-df3aed775c55"),
                    Id = Guid.Parse("e287e24c-bbae-4dfc-8add-ea8eac3a6eb4"),
                    ServiceId = Guid.Parse("96f3601d-b152-4dbd-b60c-fecd2e73b59a"),
                    UserId = Guid.Parse("c9bb35f7-b4c0-4053-8ef7-2a1c59198f48"),
                }
            };

            return entities;
        }

        public static List<Decoration> GetMockedDecorationSet()
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

            return entities;
        }

        public static List<Role> GetMockedRoleSet()
        {
            var entities = new List<Role>
            {
                 new Role { Id = Guid.Parse("4be0058f-0e57-4c88-b455-d5b37bb71e0f"), Name = "Admin", CreateDate = DateTime.UtcNow, LMDate = DateTime.UtcNow, CreateEmail = "system", LMEmail = "system" },
                 new Role { Id = Guid.Parse("640f3f73-bf9b-4966-9202-2179425fb359"), Name = "User", CreateDate = DateTime.UtcNow, LMDate = DateTime.UtcNow, CreateEmail = "system", LMEmail = "system" }
            };

            return entities;
        }

        public static List<User> GetMockedUserSet()
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
            return entities;
        }

    }
}
