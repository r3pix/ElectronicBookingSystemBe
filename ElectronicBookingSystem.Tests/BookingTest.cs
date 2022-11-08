using AutoMapper;
using ElectronicBookingSystem.Application.CQRS.Booking.Queries;
using ElectronicBookingSystem.Domain.Entities;
using ElectronicBookingSystem.Infrastructure.Interfaces;
using ElectronicBookingSystem.Infrastructure.Services;
using ElectronicLibrary.Application.Profiles;
using ElectronicLibrary.Application.Repositories;
using ElectronicLibrary.Persistance;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ElectronicBookingSystem.Tests
{
    public class BookingTest
    {
        private readonly DbContextOptions<ElectronicBookingSystemDbContext> _options = new DbContextOptionsBuilder<ElectronicBookingSystemDbContext>()
          .UseInMemoryDatabase(databaseName: "Test_Booking_Booking").Options;

        [Fact]
        public async Task WhenDataNotPresent_ShouldThrowError()
        {
            //arrage
            var profile = new BookingAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new Repository<Booking>(dbContext, mapper);

            //act
            var query = new GetBookingInvoiceDataQuery
            {
                Id = Guid.NewGuid()
            };

            var queryHandler = new GetBookingInvoiceDataQueryHandler(repository, mapper);

            //assert
           await Assert.ThrowsAsync<Exception>(async () => await queryHandler.Handle(query, CancellationToken.None));
        }

        [Fact]
        public async Task WhenGettingInvoiceData_ItShouldReturnData()
        {
            //arrage
            var profile = new BookingAutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            var mapper = new Mapper(configuration);
            var currentUser = new Mock<ICurrentUserService>();
            currentUser.Setup(x => x.Email).Returns("system");
            var dbContext = new ElectronicBookingSystemDbContext(_options, currentUser.Object);
            var repository = new Repository<Booking>(dbContext, mapper);
            //act
            await dbContext.Decorations.AddRangeAsync(InMemorySeeds.GetMockedDecorationSet());
            await dbContext.Equipment.AddRangeAsync(InMemorySeeds.GetMockedEquipmentSet());
            await dbContext.Rooms.AddRangeAsync(InMemorySeeds.GetMockedRoomSet());
            await dbContext.Services.AddRangeAsync(InMemorySeeds.GetMockedServiceSet());
            await dbContext.Users.AddRangeAsync(InMemorySeeds.GetMockedUserSet());
            await dbContext.Identities.AddRangeAsync(InMemorySeeds.GetMockedIdentitySet());
            await dbContext.Bookings.AddRangeAsync(InMemorySeeds.GetMockedBookingSet());
            await dbContext.SaveChangesAsyncWithoutUser();

            var query = new GetBookingInvoiceDataQuery
            {
                Id = Guid.Parse("e287e24c-bbae-4dfc-8add-ea8eac3a6eb4")
            };

            var queryHandler = new GetBookingInvoiceDataQueryHandler(repository, mapper);

            var result = await queryHandler.Handle(query, CancellationToken.None);
            //assert
            Assert.NotNull(result.Result);
        }
    }
}
